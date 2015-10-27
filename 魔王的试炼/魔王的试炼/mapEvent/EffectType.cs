using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 获取物品的物品类型
    /// </summary>
    enum EffectType
    {
        /// <summary>
        /// 获取道具
        /// </summary>
        Prop = 0,

        /// <summary>
        /// 获取物品
        /// </summary>
        Goods = 1,

        /// <summary>
        /// 获取血瓶
        /// </summary>
        Blood = 2,

        /// <summary>
        /// 获得升级物品
        /// </summary>
        LevelUp = 3,

        /// <summary>
        /// 缺省
        /// </summary>
        Default = 100,
    }
}
