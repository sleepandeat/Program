using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 路径计算类，辅助Floor对象完成路径的计算
    /// </summary>
    class PathCaculator
    {
        /// <summary>
        /// 创建路径计算对象
        /// </summary>
        /// <param name="sourceObj">源对象的引用</param>
        /// <param name="startPos">起点坐标</param>
        /// <param name="endPos">终点坐标</param>
        public PathCaculator(FloorNode sourceObj, Coord startPos, Coord endPos)
        {
            this.CurFloor = sourceObj;
            this.StartPos = startPos;
            this.TargetPos = endPos;

            //初始化内部字段
            Passed = new bool[this.CurFloor.FloorSize.Row, this.CurFloor.FloorSize.Col];
        }

        /// <summary>
        /// 楼层对象(源对象)的引用
        /// </summary>
        readonly private FloorNode CurFloor;

        /// <summary>
        /// 开始搜索的其他位置
        /// </summary>
        readonly private Coord StartPos;

        /// <summary>
        /// 标志搜索结束的目标位置
        /// </summary>
        readonly private Coord TargetPos;

        /// <summary>
        /// 一个布尔矩阵，标示矩阵中的点是否被标记过
        /// </summary>
        private bool[,] Passed;

        /// <summary>
        /// 记录BFS搜索状态的路径队列
        /// </summary>
        private Queue<Queue<Coord>> PathQueue = new Queue<Queue<Coord>>();

        /// <summary>
        /// 搜索完毕获得的目标路径
        /// </summary>
        private Queue<Coord> TargetPath = null;

        /// <summary>
        /// 获取初始路径(包含一个初始点的路径)
        /// </summary>
        private Queue<Coord> StartPath
        {
            get
            {
                Queue<Coord> startPath = new Queue<Coord>();
                startPath.Enqueue(StartPos);
                return startPath;
            }
        }

        /// <summary>
        /// 标示四周的搜索方向的方向数组
        /// </summary>
        readonly private Direction[] Around = new Direction[]
        {
            Direction.Up, Direction.Right, Direction.Down, Direction.Left,
        };

        /// <summary>
        /// 判断点坐标是否在楼层地图上
        /// </summary>
        /// <param name="pos">点坐标</param>
        /// <returns>如果不在地图上，返回false</returns>
        private bool InMap(Coord pos)
        {
            return CurFloor.InFloor(pos);
        }

        /// <summary>
        /// 检测某位置在某方向在楼层地图上是否是可以通行的
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <param name="dir">方向</param>
        /// <returns>返回一个布尔值，如果不可通行，为false</returns>
        private bool Passable(Coord pos, Direction dir)
        {
            //如果pos是结束位置，为了获取通向其的路径，需要临时标示为通行
            if (pos.CompareTo(TargetPos) == 0)
            {
                return true;
            }

            //需要检测其他约定需要跳过的图块
            if (CurFloor.EventMap[pos.Row, pos.Col] != null && CurFloor.EventMap[pos.Row, pos.Col].Exist && CurFloor.EventMap[pos.Row, pos.Col].EventName.CompareTo("楼梯") == 0)
            {
                return false;
            }

            return CurFloor.IsPassable(pos, dir);
        }

        /// <summary>
        /// 获取楼层对象中两点之间的路径(用坐标队列表示)
        /// </summary>
        /// <returns>返回从起点到终点的移动方向的队列，如果没有通行的路线，返回null</returns>
        public Queue<Coord> Compute()
        {
            if (!InMap(StartPos) || !InMap(TargetPos))
            {
                return null;
            }

            //设置起始搜索路径开始搜索
            PathQueue.Enqueue(StartPath);

            //只要搜索队列中存在一条路径，就继续搜索
            while (PathQueue.Count > 0)
            {
                //从路径队列中获取当前搜索的路线
                Queue<Coord> curPath = PathQueue.Dequeue();

                //从当前路线中获取当前的搜索点
                Coord curPos = curPath.ElementAt(curPath.Count - 1);

                //检查是否为终点坐标，如果搜索到终点，退出循环
                if (curPos.CompareTo(TargetPos) == 0)
                {
                    TargetPath = curPath;
                    break;
                }

                //向四个方向扩展搜索
                foreach (var searchDirection in Around)
                {
                    Coord newPos = curPos;
                    newPos.Offset(searchDirection);

                    //如果新的搜索点未曾搜索过，加入队列以待之后的搜索
                    if (InMap(newPos) && !Passed[newPos.Row, newPos.Col] && Passable(newPos, searchDirection))
                    {
                        Passed[newPos.Row, newPos.Col] = true;

                        Queue<Coord> newPath = new Queue<Coord>(curPath);
                        newPath.Enqueue(newPos);
                        PathQueue.Enqueue(newPath);
                    }
                }
            }

            return TargetPath;
        }
    }
}












