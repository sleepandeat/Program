using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 破墙镐，消耗类道具，主动使用
    /// </summary>
    class DestroyProp : Property
    {
        /// <summary>
        /// 创建破墙镐的实例
        /// </summary>
        /// <param name="number">破墙镐拥有数量, 默认为0</param>
        public DestroyProp(int number = 0)
            : base(MotaElement.破墙镐, PropName.破墙镐, true, System.Windows.Forms.Keys.P, number)
        {
        }

        /// <summary>
        /// 使用破墙镐消除使用者前方的障碍物，如果消去成功，物品数量减1
        /// </summary>
        public override void Use(IPropUser user) 
        {
            //打破前面的一堵墙
            Coord station = user.Station;
            station.Offset(user.FaceTo);
            if (MotaWorld.GetInstance().MapManager.Destroy(station))
            {
                //如果破坏成功，减掉道具
                this.CutDown();
            }
        }



    }
}










