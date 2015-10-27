using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 楼层跳转时出现的过场动画
    /// </summary>
    class FloorFlash : TimingWindow
    {
        /// <summary>
        /// 创建过场动画窗口实例
        /// </summary>
        /// <param name="picture">过场图像</param>
        public FloorFlash(Bitmap picture)
            : base(20)
        {
            FlashPicture = picture;
        }

        /// <summary>
        /// 魔塔楼层跳转图像
        /// </summary>
        Bitmap FlashPicture;

        /// <summary>
        /// 绘制过场动画
        /// </summary>
        protected override void ReDraw()
        {
            Graphics.FromImage(WindowFace).Clear(Color.Transparent);
            
            if (Valid)
            {
                Bitmap temp = new Bitmap(FlashPicture);
                Graphics.FromImage(temp).DrawString("魔 塔", new Font(new FontFamily("宋体"), 30, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(70, 70));
                Graphics.FromImage(temp).DrawString(Message.Mesg, new Font(new FontFamily("宋体"), 28, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(50, 110));

                temp.SetOpacity(Opacity);
                Graphics.FromImage(WindowFace).DrawImage(temp, FrmMain.DesWindow, new Rectangle(new Point(0, 0), FlashPicture.Size), GraphicsUnit.Pixel);
                TimeCount++;
            }  
        }

        /// <summary>
        /// 获取实时显示的图像透明度
        /// </summary>
        protected float Opacity
        {
            get { return (float)Math.Cos((double)TimeCount / (double)SumCount * Math.PI / 2); }
        }
    }
}








