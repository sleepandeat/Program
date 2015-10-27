using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 表示元素在魔塔地图中的位置
    /// </summary>
    struct Posation
    {
        /// <summary>
        /// 创建一个实例，标示元素在魔塔上的位置
        /// </summary>
        /// <param name="floor">出现的楼层</param>
        /// <param name="seat">出现的位置</param>
        public Posation(int floor, Coord seat) 
        {
            this.Floor = floor;
            this.Seat = seat;
        }

        /// <summary>
        /// 魔塔的楼层
        /// </summary>
        public int Floor;

        /// <summary>
        /// 地图上的坐标
        /// </summary>
        public Coord Seat;

        /// <summary>
        /// 从字符串描述中创建位置对象
        /// </summary>
        /// <param name="desc">字符串描述</param>
        /// <returns>位置对象</returns>
        public static Posation GetPosation(string desc)
        {
            string[] strs = desc.Split(',');
            if (strs.Length != 3)
            {
                throw new Exception("不合适的位置数据");
            }

            int floor = int.Parse(strs[0]);
            int row = int.Parse(strs[1]);
            int col = int.Parse(strs[2]);
            return new Posation(floor, new Coord(col, row));
        }

        public override string ToString()
        {
            return this.Floor + "," + this.Seat.Row + "," + this.Seat.Col;
        }
    }
}








