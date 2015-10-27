using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    static class Common
    {
        /// <summary>
        /// 返回大于a / b的最小整数
        /// </summary>
        public static int Ceil(int a, int b)
        {
            if (a % b == 0)
            {
                return a / b;
            }
            return a / b + 1;
        }

        /// <summary>
        /// 根据绝对位置计算所在的格子坐标
        /// </summary>
        /// <param name="p">绝对位置</param>
        public static Coord GetStation(Point p)
        {
            int row, col;
            if (p.Y < 0)
            {
                row = -Common.Ceil(-p.Y, GameIni.ElementHeight);
            }
            else
            {
                row = p.Y / GameIni.ElementHeight;
            }

            if (p.X < 0)
            {
                col = -Common.Ceil(-p.X, GameIni.ElementWidth);
            }
            else
            {
                col = p.X / GameIni.ElementWidth;
            }

            return new Coord(col, row);
        }

        /// <summary>
        /// 根据单位坐标获取地图上的点
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <returns>点</returns>
        public static Point GetPointFromCoord(Coord pos)
        {
            return new Point(pos.Col * GameIni.ElementWidth, pos.Row * GameIni.ElementHeight);
        }

        /// <summary>
        /// 根据单位坐标获取地图上的点
        /// </summary>
        /// <param name="posX">x坐标</param>
        /// <param name="posY">y坐标</param>
        /// <returns>点</returns>
        public static Point GetPointFromCoord(int posX, int posY)
        {
            return GetPointFromCoord(new Coord(posX, posY));
        }

        public static string ToXmlString(this Size aSize)
        {
            return aSize.Width + "," + aSize.Height;
        }
    }
}








