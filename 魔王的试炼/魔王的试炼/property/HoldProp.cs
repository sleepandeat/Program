using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 持有类道具，获得后可以实现某种效果，非消耗品
    /// </summary>
    class HoldProp : Property
    {
        /// <summary>
        /// 创建持有类的实例
        /// </summary>
        /// <param name="face">道具图像</param>
        /// <param name="number">拥有数量, 默认为0</param>
        public HoldProp(PropName name, MotaElement face, int number = 0)
            : base(face, name, false, System.Windows.Forms.Keys.None, number)
        {
        }

        /// <summary>
        /// 无法主动使用
        /// </summary>
        public override void Use(IPropUser user)
        {
        }
    }
}










