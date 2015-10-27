using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 所有地图元素的抽象基类
    /// </summary>
    abstract class MapElement : PassElement
    {
        /// <summary>
        /// 以原有的图像设置地图元素实例
        /// </summary>
        /// <param name="faceIndex">图像索引</param>
        /// <param name="showPosation">元素在地图上的坐标</param>
        public MapElement(MotaElement faceIndex, Coord showPosation)
            : base(true, GameIni.DefaultInterval, faceIndex)
        {
            location = new Point(showPosation.Col * GameIni.ElementWidth, showPosation.Row * GameIni.ElementHeight);
        }

        /// <summary>
        /// 以自定义的图像设置地图元素实例
        /// </summary>
        /// <param name="fileName">图像文件名</param>
        /// <param name="showPosation">元素在地图上的坐标</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        public MapElement(string fileName, Coord showPosation, Size unitSize)
            : base(true, GameIni.DefaultInterval, fileName, unitSize)
        {
            location = new Point(showPosation.Col * GameIni.ElementWidth, showPosation.Row * GameIni.ElementHeight);
        }

        private Point location = Point.Empty;
        /// <summary>
        /// 获取或设置游戏元素距离地图左上角的绝对位置,Y表示竖直方向高度
        /// 这是元素左上角的位置而非元素图像左上角的位置
        /// </summary>
        public Point Location
        {
            get { 
                return location; 
            }
            set {
                location = value;
            }
        }

        private bool exist = true;
        /// <summary>
        /// 游戏元素的存在性
        /// </summary>
        public virtual bool Exist
        {
            get { 
                return exist; 
            }
            set { 
                exist = value;
            }
        }

        /// <summary>
        /// 打开元素
        /// </summary>
        public virtual void Open()
        {
            this.Exist = true;
        }

        /// <summary>
        /// 关闭元素
        /// </summary>
        public virtual void Close()
        {
            this.Exist = false;
        }

        /// <summary>
        /// 获取元素图像的绘制点
        /// </summary>
        protected Point PaintPoint
        {
            get
            {
                //有些图像的左上角的位置并不是元素左上角的位置，需要动态计算偏移距离
                Point paintPoint = Location;
                paintPoint.Y += GameIni.ElementHeight - CurFace.Height;
                paintPoint.X += GameIni.ElementWidth / 2 - CurFace.Width / 2;
                return paintPoint;
            }
        }

        /// <summary>
        /// 绘制自身到画布，绘制的位置与自身的坐标有关
        /// </summary>
        /// <param name="canvas">画布(游戏的全景地图)</param>
        public virtual void Draw(Graphics canvas)
        {
            if (Exist && CurFace != null)
            {
                canvas.DrawImage(CurFace, PaintPoint);
            }
        }

        /// <summary>
        /// 获取一个布尔值，标示元素是否可以刷新
        /// </summary>
        protected override bool CanRefresh
        {
            get
            {
                return base.CanRefresh && Exist;
            }
        }

        /// <summary>
        /// 停止播放图像时直接消失
        /// </summary>
        protected override void StopFlash()
        {
            base.StopFlash();
            Exist = false;
        }
    }
}













