using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 枚举事件接触方法
    /// </summary>
    enum TouchMethod
    {
        /// <summary>
        /// 直接接触触发
        /// </summary>
        ImmediatelyTouch = 0,

        /// <summary>
        /// 位置接触时触发
        /// </summary>
        StationTouch = 1,
    }
}
