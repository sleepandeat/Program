using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    //摘要:
    //  运用Replace Data Value with Object重构手法将于路径有关的字段和方法封装成类
    //

    /// <summary>
    /// 路径类
    /// </summary>
    class Path
    {
        /// <summary>
        /// 创建路径实例
        /// </summary>
        /// <param name="path">坐标队列</param>
        public Path(Queue<Coord> path)
        {
            SetPath(path);
        }

        /// <summary>
        /// 设置新路径
        /// </summary>
        public void SetPath(Queue<Coord> path)
        {
            //从path的副本中设置路径，防止外界的修改
            if (path != null)
            {
                this.PathQueue = new Queue<Coord>(path);
            }

            if (ExistPath)
            {
                TargetPos = PathQueue.Peek();
                StartPos = PathQueue.Peek();
                EndTargetPos = PathQueue.ElementAt(PathQueue.Count - 1);
                if (this.PathQueue.Count < 2)
                {
                    EndDrection = Direction.No;
                }
                else
                {
                    EndDrection = (EndTargetPos - this.PathQueue.ElementAt(this.PathQueue.Count - 2)).GetDirection;
                }
            }
            else
            {
                TargetPos = Coord.Empty;
                StartPos = Coord.Empty;
                EndTargetPos = Coord.Empty;
                EndDrection = Direction.No;
            }
        }

        /// <summary>
        /// 指导自动移动方向的队列
        /// </summary>
        private Queue<Coord> PathQueue;

        /// <summary>
        /// 获取一个布尔值，标示是否存在路径
        /// </summary>
        public bool ExistPath
        {
            get
            {
                return PathQueue != null && PathQueue.Count > 0;
            }
        }

        /// <summary>
        /// 获取或设置当前路径的下一个目标位置
        /// </summary>
        public Coord TargetPos { get; set; }

        /// <summary>
        /// 获取路径的最终位置
        /// </summary>
        public Coord EndTargetPos { get; set; }

        /// <summary>
        /// 获取或设置初始位置
        /// </summary>
        public Coord StartPos { get; set; }

        /// <summary>
        /// 获取路径最终的移动方向
        /// </summary>
        public Direction EndDrection { get; set; }

        /// <summary>
        /// 获取或设置当前路径的目标方向
        /// </summary>
        public Direction CurPathDiection { get; set; }

        /// <summary>
        /// 如果当前路径不为空，更新下一个目标位置
        /// </summary>
        public void NextPos()
        {
            if (ExistPath)
            {
                PathQueue.Dequeue();
            }

            if (ExistPath)
            {
                CurPathDiection = (PathQueue.Peek() - TargetPos).GetDirection;
                TargetPos = PathQueue.Peek();
            }
        }

        /// <summary>
        /// 移除路径
        /// </summary>
        public void ClearPath()
        {
            PathQueue = null;
        }

        /// <summary>
        /// 判断当前的目标位置在制定的楼层中是否可以通行
        /// </summary>
        /// <param name="floor">楼层</param>
        /// <returns>返回一个布尔值，标示是否可以通行</returns>
        public bool PassableIn(FloorNode floor)
        { 
            //委托楼层对象计算
            return floor.IsPassable(TargetPos, CurPathDiection);
        }
    }
}







