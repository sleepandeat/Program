using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 恢复:攻击时有5%的几率，提升5%的生命,最多可以一次提升1000点.(但会丧失一次攻击机会)
    /// </summary>
    class Recover : Skill
    {
        /// <summary>
        /// 创建暴击技能:攻击时有5%的几率，附加50%的伤害
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        public Recover(bool isHero)
            : base(isHero, true, "恢复", "images/skill/恢复.png", 0.03, false)
        { }

        /// <summary>
        /// 愤怒一击
        /// </summary>
        /// <param name="harm">原始伤害</param>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        /// <param name="messageQueue">消息队列，用于输出技能释放消息</param>
        /// <returns>标示是否发动成功</returns>
        public override bool Onset(ref int harm, IFighter attacker, IFighter defencer, Queue<string> messageQueue)
        {
            if (!TestProbability(OnsetProbability + 0.001 * attacker.Agility))
            {
                return false;
            }

            //高出的等级
            int hpUp = (int)(attacker.Hp * 0.05);
            if (hpUp > 1000)
            {
                hpUp = 1000;
            }
            attacker.Hp += hpUp;

            harm = 0;

            return base.Onset(ref harm, attacker, defencer, messageQueue);
        }

        protected override SoundType GetSound(bool isHero)
        {
            return SoundType.恢复;
        }

        /// <summary>
        /// 设计技能特效
        /// </summary>
        protected override void SetFace(IFighter attacker, IFighter defencer)
        {
            if (this.CurFace != null)
            {
                attacker.SkillOnIt = this.CurFace;
                defencer.SkillOnIt = null;
            }
            else
            {
                if (MotaImage.GetImage(FaceIndex) != null)
                {
                    attacker.SkillOnIt = null;
                    return;
                }
            }
        }
    }
}
