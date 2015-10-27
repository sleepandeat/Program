using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 楼层跳转器类，非消耗类道具，主动使用
    /// </summary>
    class SkipProp : Property
    {
        /// <summary>
        /// 创建楼层跳转器的实例
        /// </summary>
        /// <param name="number">楼层跳转器拥有数量, 默认为0</param>
        public SkipProp(int number = 0)
            : base(MotaElement.楼层传送器, PropName.楼层传送器, false, System.Windows.Forms.Keys.J, number)
        {
        }

        /// <summary>
        /// 使用楼层跳转器, 打开楼层跳转窗口
        /// </summary>
        public override void Use(IPropUser user) 
        {
            MotaWorld.GetInstance().FloorSkipWindow.Open(null);
        }

    }
}










