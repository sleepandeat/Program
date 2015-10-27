using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 绘制道具背包到界面窗口
    /// </summary>
    class PacketBox : GameWindow
    {
        /// <summary>
        /// 创建道具展示窗口实例
        /// </summary>
        public PacketBox(int width, int height)
            : base(width, height)
        {
            Open(null);
        }

        public override void Open(object data)
        {
            Enable = true;
        }

        /// <summary>
        /// 绘制钥匙图像到窗口
        /// </summary>
        protected override void ReDraw()
        {
            Coord coordSize = new Coord(WindowFace.Width / GameIni.PropIcon.Width, WindowFace.Height / GameIni.PropIcon.Height);

            MotaWorld.GetInstance().MapManager.CurHero.Pack.DrawPacket(Graphics.FromImage(WindowFace), coordSize);
        }
    }
}







