using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 道具使用者，可以使用道具的人
    /// </summary>
    interface IPropUser
    {
        /// <summary>
        /// 使用者的位置
        /// </summary>
        Coord Station { get; set; }

        /// <summary>
        /// 使用者的朝向
        /// </summary>
        Direction FaceTo { get; }

        /// <summary>
        /// 使用道具
        /// </summary>
        /// <param name="keyCode">道具的使用按键</param>
        void UseProp(System.Windows.Forms.Keys keyCode);
    }
}




















