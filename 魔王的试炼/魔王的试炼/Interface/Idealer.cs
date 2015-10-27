using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 交易者接口，可以进行商店交易
    /// </summary>
    interface Idealer
    {
        /// <summary>
        /// 获取或设置交易对象的生命值
        /// </summary>
        int Hp { get; set; }

        /// <summary>
        /// 获取或设置交易对象的攻击力
        /// </summary>
        int Attack { get; set; }

        /// <summary>
        /// 获取或设置交易对象的防御力
        /// </summary>
        int Defence { get; set; }

        /// <summary>
        /// 获取或设置交易对象的金币
        /// </summary>
        int Coin { get; set; }

        /// <summary>
        /// 获取或设置交易对象的经验
        /// </summary>
        int Exp { get; set; }

        /// <summary>
        /// 获取或设置交易对象的等级
        /// </summary>
        int Level { get; set; }

        /// <summary>
        /// 获取或设置交易对象的敏捷
        /// </summary>
        int Agility { get; set; }

        /// <summary>
        /// 获取或设置交易对象的魔法
        /// </summary>
        int Magic { get; set; }

    }
}
