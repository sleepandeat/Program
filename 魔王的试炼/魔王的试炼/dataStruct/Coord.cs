using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔地图中的坐标
    /// </summary>
    public struct Coord : IComparable
    {
        /// <summary>
        /// 创建魔塔地图中的坐标
        /// </summary>
        /// <param name="col">横坐标</param>
        /// <param name="row">纵坐标</param>
        public Coord(int col, int row)
        {
            Col = col;
            Row = row;
        }

        /// <summary>
        /// 获取空坐标实例(0, 0)
        /// </summary>
        public static Coord Empty
        {
            get { return new Coord(0, 0); }
        }

        /// <summary>
        /// 把对象的行列坐标作为位移分析出其所代表的方向
        /// </summary>
        public Direction GetDirection
        {
            get
            {
                Direction[] Around = new Direction[]
                {
                    Direction.Up,
                    Direction.Right,
                    Direction.Down,
                    Direction.Left,
                };

                foreach (var item in Around)
                {
                    if (this.CompareTo(GetOffset(item)) == 0)
                    {
                        return item;
                    }
                }

                return Direction.No;
            }
        }

        /// <summary>
        /// 获取列坐标
        /// </summary>
        public int Col;

        /// <summary>
        /// 获取行坐标
        /// </summary>
        public int Row;

        /// <summary>
        /// 拷贝坐标的行和列
        /// </summary>
        /// <param name="newPos">坐标</param>
        public void Copy(Coord newPos)
        {
            this.Col = newPos.Col;
            this.Row = newPos.Row;
        }

        /// <summary>
        /// 获取某一方向的位移向量
        /// </summary>
        /// <param name="dir">位移方向</param>
        /// <returns>位移向量</returns>
        public static Coord GetOffset(Direction dir)
        {
            Coord offset = Coord.Empty;
            if (dir == Direction.Right)
            {
                offset = new Coord(1, 0);
            }
            else if (dir == Direction.Left)
            {
                offset = new Coord(-1, 0);
            }
            else if (dir == Direction.Down)
            {
                offset = new Coord(0, 1);
            }
            else if (dir == Direction.Up)
            {
                offset = new Coord(0, -1);
            }
            return offset;
        }

        /// <summary>
        /// 将坐标位移一个方向
        /// </summary>
        /// <param name="dir">位移方向</param>
        public void Offset(Direction dir)
        {
            this.Copy(this + GetOffset(dir));
        }

        /// <summary>
        /// 获取两个坐标进行减法运算后的新坐标
        /// </summary>
        /// <param name="posA">被减坐标</param>
        /// <param name="posB">减坐标</param>
        /// <returns>新坐标</returns>
        public static Coord operator -(Coord posA, Coord posB)
        {
            return new Coord(posA.Col - posB.Col, posA.Row - posB.Row);
        }

        /// <summary>
        /// 获取两个坐标进行加法运算后的新坐标
        /// </summary>
        /// <param name="posA">被加坐标</param>
        /// <param name="posB">加坐标</param>
        /// <returns>新坐标</returns>
        public static Coord operator +(Coord posA, Coord posB)
        {
            return new Coord(posA.Col + posB.Col, posA.Row + posB.Row);
        }

        /// <summary>
        /// 设置列坐标在某一范围。如果小于最小列，设置列坐标为最小列；
        /// 如果大于最大列，设置列坐标为最大列
        /// </summary>
        /// <param name="minCol">允许的最小列</param>
        /// <param name="maxCol">允许的最大列</param>
        public void SetColInRange(int minCol, int maxCol)
        {
            Col = Col < minCol ? minCol : Col;
            Col = Col > maxCol ? maxCol : Col;
        }

        /// <summary>
        /// 设置行坐标在某一范围。如果小于最小行，设置行坐标为最小行；
        /// 如果大于最大行，设置行坐标为最大行
        /// </summary>
        /// <param name="minRow">允许的最小行</param>
        /// <param name="maxRow">允许的最大行</param>
        public void SetRowInRange(int minRow, int maxRow)
        {
            Row = Row < minRow ? minRow : Row;
            Row = Row > maxRow ? maxRow : Row;
        }

        /// <summary>
        /// 比较坐标大小，如果相同，返回0
        /// </summary>
        public int CompareTo(object obj)
        {
            Coord o = (Coord)obj;
            if (o.Row != this.Row || o.Col != this.Col)
            {
                //不相同
                if (o.Row > this.Row || (o.Row == this.Row && o.Col > this.Col))
                {
                    //小于
                    return -1;
                }
                else
                {
                    //大于
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return Row + "," + Col;
        }

        /// <summary>
        /// 根据字符串换取坐标对象
        /// </summary>
        public static Coord CreateFromString(string str)
        {
            string[] strs = str.Split(',');
            if (strs.Length != 2)
            {
                throw new Exception("错误的坐标数据");
            }
            else
            {
                return new Coord(int.Parse(strs[1]), int.Parse(strs[0]));
            }
        }
    }
}







