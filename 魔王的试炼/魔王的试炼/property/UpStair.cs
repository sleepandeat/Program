using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 上楼器,上楼器可以无视当前楼层的任何阻碍而进入下一层，按U使用此道具.
    /// </summary>
    class UpStair : Property
    {
        /// <summary>
        /// 创建上楼器的实例
        /// </summary>
        /// <param name="number">楼层跳转器拥有数量, 默认为0</param>
        public UpStair(int number = 0)
            : base(MotaElement.上楼器, PropName.上楼器, true, System.Windows.Forms.Keys.U, number)
        {
        }

        /// <summary>
        /// 使用上楼器
        /// </summary>
        public override void Use(IPropUser user) 
        {
            //小于最大楼层
            if (MotaWorld.GetInstance().MapManager.CurFloorIndex < MotaWorld.GetInstance().MapManager.Tower.MaxFloor - 1)
            {
                MotaWorld.GetInstance().MapManager.CurFloorIndex = MotaWorld.GetInstance().MapManager.CurFloorNode.NextFloor;
                this.CutDown();
            }
        }

    }
}










