using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    //摘要:
    //  这是一个基础的数据结构类，用于存储数据和提供管理数据的基础方法  
    //
    //设计思路:
    //  基础类不参与游戏逻辑的管理，只提供游戏逻辑功能的背后支持(底层逻辑)
    //
    //特征:
    //  不记录当前楼层等游戏状态，这些是游戏逻辑管理类的责任
    //

    /// <summary>
    /// 由楼层节点组成的魔塔类，用于记录和管理魔塔地图信息
    /// </summary>
    class MagicTower
    {
        /// <summary>
        /// 魔塔中的全部楼层节点
        /// </summary>
        private List<FloorNode> Floors = new List<FloorNode>(0);

        /// <summary>
        /// 添加新的楼层
        /// </summary>
        public void AddFloor(FloorNode newFloor)
        {
            Floors.Add(newFloor);
        }

        /// <summary>
        /// 清空楼层
        /// </summary>
        public void Clear() { this.Floors.Clear(); }

        /// <summary>
        /// 获取总楼层数,也是最大楼层数
        /// </summary>
        public int MaxFloor
        {
            get { return Floors.Count; }
        }

        /// <summary>
        /// 根据楼层索引值获取对于的楼层节点
        /// </summary>
        /// <param name="floorIndex">楼层索引</param>
        /// <returns>对于的楼层节点</returns>
        public FloorNode this[int floorIndex]
        {
            get {
                foreach (var item in Floors)
                {
                    if (item.FloorIndex == floorIndex)
                    {
                        return item;
                    }
                }
                return null;
            }
        }


    }
}








