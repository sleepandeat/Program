using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 物品获取消息窗口
    /// </summary>
    class GoodsMessage : TimingWindow
    {
        /// <summary>
        /// 创建道具获取消息窗口实例
        /// </summary>
        public GoodsMessage():base(20)
        {
            Solo = false;
        }

        /// <summary>
        /// 绘制消息到界面
        /// </summary>
        protected override void ReDraw()
        {
            Graphics.FromImage(WindowFace).Clear(Color.Transparent);

            if (Valid)
            {
                //Bitmap icon = new Bitmap(WindowFace);
                //Graphics.FromImage(icon).Clear(Color.Transparent);

                Font mesgFont = new Font(new FontFamily("宋体"), 18, FontStyle.Regular);
                SolidBrush mesgBrush = new SolidBrush(Color.WhiteSmoke);
                Graphics.FromImage(WindowFace).DrawString(Message.Mesg, mesgFont, mesgBrush, ShowPoint);

                //设置透明度
                //ImageOpacity.SetOpacity(ref icon, Opacity);
                //WindowFace = icon;

                //计数
                TimeCount++;
            }
        }

        /// <summary>
        /// 获取消息播放的实时透明度
        /// </summary>
        private float Opacity
        {
            get
            {
                if (TimeCount < 10)
                {
                    return 1;
                }
                else
                {
                    return (float)Math.Cos((double)(TimeCount - 10) / 10.0 * Math.PI / 2.0);
                }
            }
        }

        /// <summary>
        /// 获取显示动态消息的实时位置
        /// </summary>
        private Point ShowPoint
        {
            get
            {
                Point desPoint = Message.WindowStation;
                if (TimeCount <= 2)
                {
                    desPoint.Y -= TimeCount * 4;
                }
                else if(TimeCount <= 15)
                {
                    desPoint.Y -= 10 - TimeCount * 2;
                }
                else
                {
                    desPoint.Y += 20;
                }
                return desPoint;
            }
        }
    }
}




