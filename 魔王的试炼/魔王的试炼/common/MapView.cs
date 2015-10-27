using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏地图的可见场景类，用于管理窗口
    /// </summary>
    class MapView
    {
        /// <summary>
        /// 获取或设置游戏的活动窗口
        /// </summary>
        public Rectangle DynamicWindow { get; set; }

        /// <summary>
        /// 根据目标点坐标更新窗口位置，使目标位置落在视口中间
        /// </summary>
        /// <param name="desPos">目标位置</param>
        public void ResetView(Coord desPos)
        {
            int top, left;
            //如果目标点距离地图左侧距离大于半个窗口，则移动窗口使目标点处于中间位置
            if (desPos.Col - (GameIni.WindowGridX / 2) > 0)
            {
                left = (desPos.Col - (GameIni.WindowGridX / 2)) * GameIni.ElementWidth;
                if (left + GameIni.WindowWidth > GameIni.MapWidth)
                {
                    left = GameIni.MapWidth - GameIni.WindowWidth;
                }
            }
            else
            {
                left = 0;
            }

            //如果目标点距离地图上侧距离大于半个窗口，则移动窗口使目标点处于中间位置
            if (desPos.Row - (GameIni.WindowGridY / 2) > 0)
            {
                top = (desPos.Row - (GameIni.WindowGridY / 2)) * GameIni.ElementHeight;
                if (top + GameIni.WindowHeight > GameIni.MapHeight)
                {
                    top = GameIni.MapHeight - GameIni.WindowHeight;
                }
            }
            else
            {
                top = 0;
            }

            DynamicWindow = new Rectangle(left, top, GameIni.WindowWidth, GameIni.WindowHeight);
        }

        /// <summary>
        /// 刷新窗口位置，使之跟随目标的移动而移动
        /// </summary>
        /// <param name="MapPoint">目标的绝对位置</param>
        /// <param name="way">移动的方向</param>
        public void RefreshView(Point desPoint, Direction way)
        {
            Rectangle newView = DynamicWindow;
            switch (way)
            {
                case Direction.Up:
                    int marginTop = desPoint.Y - DynamicWindow.Top;
                    if (marginTop < GameIni.EdgeDistance && desPoint.Y - GameIni.EdgeDistance > 0)
                    {
                        newView.Offset(0, marginTop - GameIni.EdgeDistance);
                    }
                    else if (desPoint.Y - GameIni.EdgeDistance < 0)
                    {
                        newView.Offset(0, -DynamicWindow.Top);
                    }
                    break;
                case Direction.Down:
                    int marginDown = DynamicWindow.Bottom - (desPoint.Y + GameIni.ElementHeight);
                    if (marginDown < GameIni.EdgeDistance && (desPoint.Y + GameIni.ElementHeight) + GameIni.EdgeDistance < GameIni.MapHeight)
                    {
                        newView.Offset(0, GameIni.EdgeDistance - marginDown);
                    }
                    else if ((desPoint.Y + GameIni.ElementHeight) + GameIni.EdgeDistance > GameIni.MapHeight)
                    {
                        newView.Offset(0, -DynamicWindow.Bottom + GameIni.MapHeight);
                    }
                    break;
                case Direction.Left:
                    int marginLeft = desPoint.X - DynamicWindow.Left;
                    if (marginLeft < GameIni.EdgeDistance && desPoint.X - GameIni.EdgeDistance > 0)
                    {
                        newView.Offset(marginLeft - GameIni.EdgeDistance, 0);
                    }
                    else if (desPoint.X - GameIni.EdgeDistance < 0)
                    {
                        newView.Offset(-DynamicWindow.Left, 0);
                    }
                    break;
                case Direction.Right:
                    int marginRight = DynamicWindow.Right - (desPoint.X + GameIni.ElementWidth);
                    if (marginRight < GameIni.EdgeDistance && (desPoint.X + GameIni.ElementWidth) + GameIni.EdgeDistance < GameIni.MapWidth)
                    {
                        newView.Offset(GameIni.EdgeDistance - marginRight, 0);
                    }
                    else if ((desPoint.X + GameIni.ElementWidth) + GameIni.EdgeDistance > GameIni.MapWidth)
                    {
                        newView.Offset(-DynamicWindow.Right + GameIni.MapWidth, 0);
                    }
                    break;
                case Direction.No:
                    break;
                default:
                    break;
            }
            DynamicWindow = newView;
        }

        /// <summary>
        /// 获取晃动中窗口向右滑动的距离
        /// </summary>
        private int SlideRight
        {
            get
            {
                if (!Shaked)
                {
                    return 0;
                }

                if (ShakeCount < GameIni.ShakeUnitTime)
                {
                    //向右晃动
                    return GameIni.ShakeWidth * ShakeCount;
                }
                else if (ShakeCount < 3 * GameIni.ShakeUnitTime)
                {
                    //向左晃动
                    return 2 * GameIni.ShakeUnitTime * GameIni.ShakeWidth - GameIni.ShakeWidth * ShakeCount;
                }
                else
                {
                    //再向右晃动
                    return GameIni.ShakeWidth * ShakeCount - 4 * GameIni.ShakeUnitTime * GameIni.ShakeWidth;
                }
            }
        }

        private int shakeCount = 0;
        /// <summary>
        /// 晃动计数，拨动窗口晃动并且达到一定次数后取消晃动
        /// </summary>
        public int ShakeCount
        {
            get { return shakeCount; }
            set
            {
                if (!Shaked)
                {
                    return;
                }

                shakeCount = value;
                if (value > 4 * GameIni.ShakeUnitTime)
                {
                    Shaked = false;
                }
            }
        }

        /// <summary>
        /// 获取或设置是否产生晃动
        /// </summary>
        public bool Shaked { get; set; }

        /// <summary>
        /// 让地图产生晃动
        /// </summary>
        public void Shake()
        {
            Shaked = true;
            ShakeCount = 0;
        }

        /// <summary>
        /// 获取最终要绘制的游戏窗口
        /// </summary>
        public Rectangle PaintWindow
        {
            get
            {
                return new Rectangle(new Point(DynamicWindow.Location.X + SlideRight, DynamicWindow.Location.Y), DynamicWindow.Size);
            }
        }

        /// <summary>
        /// 根据地图上的位置计算出在视图窗口上的相对位置
        /// </summary>
        /// <param name="mapPos">地图上的绝对位置</param>
        /// <returns>在视图窗口上的相当位置</returns>
        public Point GetWindowPosation(Point mapPos)
        {
            return new Point(mapPos.X - this.DynamicWindow.Location.X, mapPos.Y - this.DynamicWindow.Location.Y);
        }

        /// <summary>
        /// 根据视图窗口上的位置计算出在地图上的绝对位置
        /// </summary>
        /// <param name="windowPos">窗口上的相当位置</param>
        /// <returns>地图上的绝对位置</returns>
        public Point GetMapPosation(Point windowPos)
        {
            return new Point(windowPos.X + this.DynamicWindow.Location.X, windowPos.Y + this.DynamicWindow.Location.Y);
        }
    }
}
