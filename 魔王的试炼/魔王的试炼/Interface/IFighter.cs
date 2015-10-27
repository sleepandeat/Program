using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 战斗员接口，用于提供对战窗口的战斗成员
    /// </summary>
    interface IFighter : ICanShowData
    {
        /// <summary>
        /// 获取或设置战斗员的生命值
        /// </summary>
        new int Hp { get; set; }

        /// <summary>
        /// 获取或设置战斗员的金币
        /// </summary>
        new int Coin { get; set; }

        /// <summary>
        /// 获取或设置战斗员的经验
        /// </summary>
        new int Exp { get; set; }

        /// <summary>
        /// 设置战斗员的是否处于战斗状态
        /// </summary>
        bool InBattle { set; }

        /// <summary>
        /// 设置人物死亡
        /// </summary>
        void Death();

        /// <summary>
        /// 获取或设置攻击时的音效
        /// </summary>
        SoundType AttackSound { get; set; }

        /// <summary>
        /// 获取技能列表
        /// </summary>
        List<Skill> Skills { get; }

        /// <summary>
        /// 获取或设置展示在人物上的技能特效
        /// </summary>
        Bitmap SkillOnIt { get; set; }

        /// <summary>
        /// 获取怪物是否允许撤退
        /// </summary>
        bool AllowQuit { get; }

        /// <summary>
        /// 在战斗中撤退一次
        /// </summary>
        void Quit();
    }
}






