using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 怪物手册类，非消耗类道具，主动使用
    /// </summary>
    class BookProp : Property
    {
        /// <summary>
        /// 创建BookProp的实例
        /// </summary>
        /// <param name="number">怪物手册拥有数量, 默认为0</param>
        public BookProp(int number = 0)
            : base(MotaElement.怪物手册, PropName.怪物手册, false, System.Windows.Forms.Keys.Space, number)
        {
        }

        /// <summary>
        /// 使用怪物手册, 打开怪物手册窗口
        /// </summary>
        public override void Use(IPropUser user) 
        {
            MotaWorld.GetInstance().BookWindow.Open(null);
        }

    }
}










