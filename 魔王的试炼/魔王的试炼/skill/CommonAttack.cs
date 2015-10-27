using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 普通攻击
    /// </summary>
    class CommonAttack : Skill
    {
        /// <summary>
        /// 创建普通攻击技能
        /// </summary>
        /// <param name="isHero">是否是勇士</param>
        public CommonAttack(bool isHero)
            : base(isHero, true, string.Empty, isHero ? "images/skill/勇士普通攻击.png" : "images/skill/怪物普通攻击.png", 1.0, false)
        { }

        /// <summary>
        /// 进行普通攻击
        /// </summary>
        /// <param name="harm">原始伤害</param>
        /// <param name="attacker">攻击者</param>
        /// <param name="defencer">防御者</param>
        /// <param name="messageQueue">消息队列，用于输出技能释放消息</param>
        /// <returns>标示是否发动成功</returns>
        public override bool Onset(ref int harm, IFighter attacker, IFighter defencer, Queue<string> messageQueue)
        {
            if (attacker.Attack > defencer.Defence)
            {
                harm += attacker.Attack - defencer.Defence;
            }

            base.Onset(ref harm, attacker, defencer, messageQueue);

            //普通攻击
            return false;
        }

        protected override SoundType GetSound(bool isHero)
        {
            return isHero ? SoundType.剑击 : SoundType.普通攻击;
        }
    }
}
