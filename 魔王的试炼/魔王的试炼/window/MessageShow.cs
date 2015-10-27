using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 消息显示窗口
    /// </summary>
    class MessageShow : GameWindow
    {
        /// <summary>
        /// 创建消息显示窗口实例
        /// </summary>
        public MessageShow()
            : base(380, 150)
        {
            ExistStation = new System.Drawing.Point(150, 180);
        }

        /// <summary>
        /// 获取或设置显示的消息
        /// </summary>
        private string Message { get; set; }

        /// <summary>
        /// 更新message以展示新的消息
        /// </summary>
        /// <param name="data">消息内容</param>
        public override void Open(object data)
        {
            string mesg = data as string;
            if (mesg != null)
            {
                this.Message = mesg;

                Enable = true;
                ReDraw();
            }
        }

        /// <summary>
        /// 重写基类方法，每次刷新时不重新绘制图形
        /// </summary>
        public override void NextFrame() { }

        /// <summary>
        /// 绘制消息提示框到画布
        /// </summary>
        protected override void ReDraw()
        {
            Bitmap canvas = new Bitmap(WindowFace);

            //填充背景
            Graphics.FromImage(canvas).DrawImage(MotaImage.BackWindow, new Rectangle(0, 0, this.WindowFace.Width, this.WindowFace.Height), new Rectangle(0, 0, MotaImage.BackWindow.Width, MotaImage.BackWindow.Height), GraphicsUnit.Pixel);

            Font descFont = new Font(new FontFamily("微软雅黑"), 14, FontStyle.Regular);
            SolidBrush descBrush = new SolidBrush(Color.Black);
            
            //显示消息
            Graphics.FromImage(canvas).DrawString(Message, descFont, descBrush, new Rectangle(15, 15, WindowFace.Width - 15, 90));
            
            Graphics.FromImage(canvas).DrawString("按Enter键确认", descFont, descBrush, new PointF(230, 110));

            canvas.SetOpacity(0.8F);

            WindowFace = canvas;
        }

        /// <summary>
        /// 处理按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.Enter)
            {
                this.Enable = false;
            }

            return true;
        }

    }
}










