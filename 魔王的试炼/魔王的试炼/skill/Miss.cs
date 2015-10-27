using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 闪避：被攻击时有5%的几率，闪避敌人的攻击，减少100%的伤害
    /// 防御性的技能
    /// </summary>
    class Miss : Skill
    {
        /// <summary>
        /// 创建防御屏障
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        public Miss(bool isHero)
            : base(isHero, false, "防御屏障", "images/skill/闪避.png", 0.03, false)
        { }

        /// <summary>
        /// 被攻击时，减少全部伤害
        /// </summary>
        /// <param name="harm">原始伤害</param>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        /// <param name="messageQueue">消息队列，用于输出技能释放消息</param>
        /// <returns>标示是否发动成功</returns>
        public override bool Onset(ref int harm, IFighter attacker, IFighter defencer, Queue<string> messageQueue)
        {
            //只要对方对自己造成伤害时才会发动
            if (!TestProbability(OnsetProbability + 0.001 * defencer.Agility) || harm <= 0)
            {
                return false;
            }

            harm = 0;

            return base.Onset(ref harm, attacker, defencer, messageQueue);
        }

        protected override SoundType GetSound(bool isHero)
        {
            return SoundType.防御屏障;
        }
    }
}
