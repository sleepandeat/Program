using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 暴击: 每次攻击时有10%的几率附加30%的伤害
    /// 每高于敌人一个等级，暴击伤害提升1%
    /// 敏捷影响暴击发动几率
    /// </summary>
    class GoodAttack : Skill
    {
        /// <summary>
        /// 创建暴击技能
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        public GoodAttack(bool isHero)
            : base(isHero, true, "暴击", isHero ? "images/skill/勇士暴击.png" : "images/skill/怪物暴击.png", 0.03, true)
        { }

        /// <summary>
        /// 暴击: 每次攻击时有10%的几率附加30%的伤害
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
            int upLevel = attacker.Level - defencer.Level;
            if (upLevel < 0)
            {
                upLevel = 0;
            }

            harm = (int)(harm * (double)(130 + upLevel) / 100.0);

            return base.Onset(ref harm, attacker, defencer, messageQueue);
        }

        protected override SoundType GetSound(bool isHero)
        {
            return isHero ? SoundType.暴击 : SoundType.怪物暴击;
        }
    }
}
