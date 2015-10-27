using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 由两个坐标表示的坐标范围
    /// </summary>
    class CoordRange
    {
        /// <summary>
        /// 创建描述目标窗口坐标范围的实例
        /// </summary>
        /// <param name="desWindow">目标窗口</param>
        /// <param name="mapSize">地图坐标尺寸，不可取得最大坐标</param>
        public CoordRange(Rectangle desWindow, Coord mapSize)
        {
            startPos = new Coord(desWindow.Left / GameIni.ElementWidth, desWindow.Top / GameIni.ElementHeight);
            endPos = new Coord(Common.Ceil(desWindow.Right, GameIni.ElementWidth), Common.Ceil(desWindow.Bottom, GameIni.ElementHeight));

            //维护起止坐标在合理的范围
            startPos.SetColInRange(0, mapSize.Col - 1);
            startPos.SetRowInRange(0, mapSize.Row - 1);
            endPos.SetColInRange(0, mapSize.Col - 1);
            endPos.SetRowInRange(0, mapSize.Row - 1);
        }

        /// <summary>
        /// 起始坐标
        /// </summary>
        public Coord startPos { get; set; }

        /// <summary>
        /// 结束坐标
        /// </summary>
        public Coord endPos { get; set; }
    }
}







