using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 钥匙类，消耗类道具，被动使用
    /// </summary>
    class KeyProp : Property
    {
        /// <summary>
        /// 以道具名称创建钥匙的实例
        /// </summary>
        /// <param name="name">钥匙名称</param>
        /// <param name="number">钥匙拥有数量, 默认为0</param>
        public KeyProp(MotaElement index, PropName name, int number = 0)
            : base(index, name, true,  System.Windows.Forms.Keys.None, number)
        {
        }

        /// <summary>
        /// 无法主动使用道具
        /// </summary>
        public override void Use(IPropUser user) { }
    }
}










