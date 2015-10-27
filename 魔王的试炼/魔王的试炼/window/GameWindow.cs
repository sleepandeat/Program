using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏窗口基类
    /// </summary>
    abstract class GameWindow
    {
        /// <summary>
        /// 创建窗口实例
        /// </summary>
        /// <param name="width">窗口宽度</param>
        /// <param name="height">窗口高度</param>
        public GameWindow(int width, int height)
        {
            WindowFace = new Bitmap(width, height);
            Graphics.FromImage(WindowFace).Clear(Color.Transparent);

            //默认出现位置为(0, 0)
            ExistStation = Point.Empty;

            Enable = false;

            //默认是独显窗口
            Solo = true;
        }

        /// <summary>
        /// 游戏窗口图像
        /// </summary>
        public Bitmap WindowFace;

        /// <summary>
        /// 获取或设置窗口在界面中出现的位置
        /// </summary>
        public Point ExistStation { get; set; }

        /// <summary>
        /// 获取或设置窗口是否处于可用状态
        /// </summary>
        public virtual bool Enable { get; set; }

        /// <summary>
        /// 获取窗口是否是独显窗口，独显窗口互相排斥，只能出现一个.
        /// 当出现独显窗口的时候，人物不可移动
        /// </summary>
        public bool Solo { get; set; }

        /// <summary>
        /// 进入下一帧
        /// </summary>
        public virtual void NextFrame()
        {
            ReDraw();
        }

        /// <summary>
        /// 以一定的数据参数打开窗口
        /// </summary>
        /// <param name="data"></param>
        public abstract void Open(object data);

        /// <summary>
        /// 重新绘制窗口图像
        /// </summary>
        protected abstract void ReDraw();

        /// <summary>
        /// 处理按键, 默认不处理任何按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public virtual bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            return false;
        }
    }
}




