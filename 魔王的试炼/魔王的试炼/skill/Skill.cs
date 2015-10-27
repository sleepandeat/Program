using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 战斗技能抽象类
    /// 创建时加载固有技能特效图
    /// </summary>
    abstract class Skill : DynamicElement
    {
        /// <summary>
        /// 创建技能
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        /// <param name="isAttack">是否是攻击技能</param>
        /// <param name="name">技能名称</param>
        /// <param name="faceFile">技能的初始图像文件名</param>
        /// <param name="probability">初始发动概率</param>
        /// <param name="magicAble">技能是否受到魔法的加成</param>
        public Skill(bool isHero, bool isAttack, string name, string faceFile, double probability, bool magicAble)
            :base(false, 2, faceFile, GameIni.SkillFrameSize)
        {
            this.AttackSound = GetSound(isHero);
            this.IsAttackSkill = isAttack;
            this.SkillName = name;
            this.OnsetProbability = probability;
            this.MagicAble = magicAble;
            IsValid = false;
        }

        /// <summary>
        /// 获取或设置技能是否正在启用
        /// </summary>
        private bool IsValid { get; set; }

        /// <summary>
        /// 重新设置技能动画
        /// </summary>
        /// <param name="fileName">技能动画图像文件</param>
        public void ResetFlash(string fileName)
        {
            base.FaceIndex = MotaImage.GetFaceIndex(fileName, GameIni.SkillFrameSize);
        }

        /// <summary>
        /// 播放技能特性
        /// </summary>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        public void Flash(IFighter attacker, IFighter defencer)
        {
            if (!IsValid)
            {
                return;
            }

            TimeCount++;
            if (TimeCount > FrameCount)
            {
                TimeCount = 0;
                CurFrame++;
                SetFace(attacker, defencer);
            }
        }

        /// <summary>
        /// 重置技能回到初始状态
        /// </summary>
        public void Reset()
        {
            CurFrame = 0;
            IsValid = false;
            TimeCount = 0;
        }

        /// <summary>
        /// 技能动画播放一次后就不会播放了
        /// </summary>
        protected override void StopFlash()
        {
            IsValid = false;
            base.StopFlash();
        }

        /// <summary>
        /// 获取技能音效,勇士与怪物有所区别
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        /// <returns>攻击音效</returns>
        protected abstract SoundType GetSound(bool isHero);

        /// <summary>
        /// 随机数生成器
        /// </summary>
        protected static Random RP = new Random();

        /// <summary>
        /// 技能的攻击音效
        /// </summary>
        private SoundType AttackSound;

        /// <summary>
        /// 获取或设置是否是攻击技能
        /// </summary>
        public bool IsAttackSkill { get; set; }

        /// <summary>
        /// 初始的发动概率
        /// </summary>
        protected double OnsetProbability;

        /// <summary>
        /// 获取或设置技能是否受到魔法的加成
        /// </summary>
        private bool MagicAble { get; set; }

        /// <summary>
        /// 测试技能发动的可能性，如果测试成功，返回true
        /// <param name="prob">技能的实际发动几率</param>
        /// </summary>
        protected bool TestProbability(double prob)
        {
            int testNum = 1000000;
            if (RP.Next(0, testNum) < prob * testNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取或设置技能名称
        /// </summary>
        private string SkillName { get; set; }

        /// <summary>
        /// 获取技能的即时图像
        /// </summary>
        public override Bitmap CurFace
        {
            get
            {
                if (IsValid)
                {
                    return base.CurFace;
                }
                return null;
            }
        }

        /// <summary>
        /// 发动技能
        /// </summary>
        /// <param name="harm">伤害设置</param>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        /// <param name="messageQueue">消息队列，用于输出技能释放消息</param>
        /// <returns>表示是否发动成功</returns>
        public virtual bool Onset(ref int harm, IFighter attacker, IFighter defencer, Queue<string> messageQueue)
        {
            IsValid = true;
            CurFrame = 0;
            TimeCount = 0;

            SetFace(attacker, defencer);

            //输出技能释放消息
            if (SkillName.CompareTo(string.Empty) != 0)
            {
                if (messageQueue.Count > 5)
                {
                    messageQueue.Clear();
                }
                string desc;
                if (IsAttackSkill)
                {
                    desc = attacker.Name + "使出【" + SkillName + "】";
                }
                else
                {
                    desc = defencer.Name + "使出【" + SkillName + "】";
                }
                messageQueue.Enqueue(desc);
            }
            
            //更新攻击者的攻击音效
            if (this.AttackSound != SoundType.NULL)
            {
                attacker.AttackSound = this.AttackSound;
            }

            //根据魔法提升技能伤害
            if (MagicAble)
            {
                harm = (int)(harm * (1 + 0.0001 * attacker.Magic));
            }
            return true;
        }

        /// <summary>
        /// 设计技能特效
        /// </summary>
        protected virtual void SetFace(IFighter attacker, IFighter defencer)
        {
            if (this.CurFace != null)
            {
                defencer.SkillOnIt = this.CurFace;
            }
            else
            {
                if (MotaImage.GetImage(FaceIndex) != null)
                {
                    defencer.SkillOnIt = null;
                }
            }
        }
    }

}



