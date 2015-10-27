using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 短消息结构,为道具消息窗口提供成员
    /// </summary>
    class ShortMessage
    {
        /// <summary>
        /// 创建消息实例
        /// </summary>
        /// <param name="Str">消息内容</param>
        /// <param name="p">出现在地图上的坐标</param>
        public ShortMessage(string Str, Coord p)
        {
            Mesg = Str;
            Station = new Point(p.Col * GameIni.ElementWidth, p.Row * GameIni.ElementHeight);
        }

        /// <summary>
        /// 消息
        /// </summary>
        public string Mesg { get; set; }

        /// <summary>
        /// 消息出现在地图中的位置
        /// </summary>
        private Point Station;

        /// <summary>
        /// 消息出现在窗口中位置
        /// </summary>
        public Point WindowStation
        {
            get
            {
                return MotaWorld.GetInstance().MapManager.GetWindowPosation(Station);
            }
        }
    }
}










