using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 破防攻击, 每次攻击时附加1~2点无视防御的伤害
    /// 每高于敌人一个等级，增加无视防御伤害1点.
    /// </summary>
    class HelmSplitter : Skill
    {
        /// <summary>
        /// 创建破防技能
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        public HelmSplitter(bool isHero)
            : base(isHero, true, string.Empty, string.Empty, 1.0, false)
        { }

        /// <summary>
        /// 进行破防攻击，附加一定伤害
        /// </summary>
        /// <param name="harm">原始伤害</param>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        /// <param name="messageQueue">消息队列，用于输出技能释放消息</param>
        /// <returns>标示是否发动成功</returns>
        public override bool Onset(ref int harm, IFighter attacker, IFighter defencer, Queue<string> messageQueue)
        {
            if (attacker.Level >= defencer.Level)
            {
                harm += (attacker.Level - defencer.Level) + RP.Next(1, 3);
            }

            base.Onset(ref harm, attacker, defencer, messageQueue);

            return false;
        }

        protected override SoundType GetSound(bool isHero)
        {
            return SoundType.NULL; ;
        }
    }
}
