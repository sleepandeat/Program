using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏选择窗口
    /// </summary>
    class GameSelector : Selector
    {
        /// <summary>
        /// 创建窗口实例
        /// </summary>
        /// <param name="width">窗口宽度</param>
        /// <param name="height">窗口高度</param>
        public GameSelector(int width, int height) : base(width, height) { }

        /// <summary>
        /// 重新绘制窗口图像
        /// </summary>
        protected override void ReDraw()
        {
            Graphics vGraphics = Graphics.FromImage(WindowFace);

            //清空图像
            vGraphics.Clear(Color.Transparent);

            //vGraphics.FillRectangle(new SolidBrush(Color.YellowGreen), 0, 0, WindowFace.Width, WindowFace.Height);

            //绘制选项文字
            for (int i = 0; i < Options.Count; i++)
            {
                Options[i].Draw(vGraphics, new Point(50, i * 50));
            }
        }

    }

    /// <summary>
    /// 游戏选项类，为有效选项窗口提供数据单元
    /// </summary>
    class GameOption : Option
    {
        /// <summary>
        /// 创建游戏选项实例
        /// </summary>
        /// <param name="name">选项名称</param>
        /// <param name="valid">选项是否可以被选中</param>
        public GameOption(string name, bool valid = true) : base(name, valid) { }

        public override void Draw(Graphics g, Point startPoint)
        {
            if (Selected)
            {
                g.FillRectangle(new SolidBrush(Color.Tomato), new Rectangle(startPoint.X, startPoint.Y, 95, 30));

                g.DrawRectangle(new Pen(Color.White, 2), new Rectangle(startPoint.X, startPoint.Y, 95, 30));
                g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 16), new SolidBrush(Color.Yellow), startPoint);
            }
            else
            {
                g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 16), new SolidBrush(Color.White), startPoint);
            }

        }
    }

}







