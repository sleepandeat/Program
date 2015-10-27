using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 可以播放图像的动态元素，任何派生类的实例都可以自动播放图像
    /// </summary>
    abstract class DynamicElement
    {
        /// <summary>
        /// 创建动态元素实例
        /// </summary>
        /// <param name="repeated">元素图像是否重复播放</param>
        /// <param name="interval">每帧的部分间隔</param>
        /// <param name="faceIndex">图像索引</param>
        public DynamicElement(bool repeated, int interval, MotaElement faceIndex)
        {
            FaceIndex = (int)faceIndex;

            Initialize(repeated, interval);
        }

        /// <summary>
        /// 创建动态元素实例
        /// </summary>
        /// <param name="repeated">元素图像是否重复播放</param>
        /// <param name="interval">每帧的部分间隔</param>
        /// <param name="fileName">图像文件地址</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        public DynamicElement(bool repeated, int interval, string fileName, Size unitSize)
        {
            FaceIndex = MotaImage.GetFaceIndex(fileName, unitSize);

            Initialize(repeated, interval);
        }

        /// <summary>
        /// 初始化工作
        /// </summary>
        /// <param name="repeated">是否重复播放</param>
        /// <param name="interval">播放间隔</param>
        private void Initialize(bool repeated, int interval)
        {
            RepeatFlash = repeated;
            PlayInterval = interval;
            Dynamic = true;
        }

        /// <summary>
        /// 帧数改变触发的事件
        /// </summary>
        public event EventHandler FrameChangeEvent = null;

        /// <summary>
        /// 获取或设置元素图像是否重复播放
        /// </summary>
        protected bool RepeatFlash { get; set; }

        int curFrame = 0;
        /// <summary>
        /// 获取或设置元素帧数，初始帧数为0
        /// </summary>
        protected virtual int CurFrame
        {
            get
            {
                return curFrame;
            }
            set
            {
                if (TotalFrame != 0)
                {
                    if (!RepeatFlash && value >= TotalFrame)
                    {
                        StopFlash();
                    }
                    curFrame = value % TotalFrame;
                }
                FrameOnChange();
            }
        }

        /// <summary>
        /// 停止播放图像
        /// </summary>
        protected virtual void StopFlash()
        {
            Dynamic = false;
        }

        /// <summary>
        /// 获取或设置播放每帧间隔
        /// </summary>
        public int PlayInterval { get; set; }

        /// <summary>
        /// 获取每帧的播放计数
        /// </summary>
        protected int FrameCount
        {
            get { return Common.Ceil(PlayInterval, GameIni.RefreshInterval);}
        }

        /// <summary>
        /// 获取元素的总帧数，取决于图像的数量
        /// </summary>
        protected int TotalFrame { get; set; }

        /// <summary>
        /// 获取或设置元素的动态性，表示元素是否允许循环切换图像
        /// </summary>
        protected bool Dynamic { get; set; }

        /// <summary>
        /// 元素内部计时器，用于记录内部动作的持续时间
        /// </summary>
        protected int TimeCount = 0;

        private int _faceIndex;
        /// <summary>
        /// 获取或设置图像索引
        /// </summary>
        public int FaceIndex
        {
            get { return _faceIndex; }
            set { 
                _faceIndex = value;

                //更新总帧数
                if (MotaImage.GetImage(FaceIndex) != null)
                {
                    TotalFrame = MotaImage.GetImage(FaceIndex).Length;
                }
                else
                {
                    TotalFrame = 0;
                }
            }
        }

        /// <summary>
        /// 获取游戏元素当前帧数的即时图像
        /// </summary>
        public virtual Bitmap CurFace
        {
            get
            {
                if (MotaImage.GetImage(FaceIndex) == null)
                {
                    return null;
                }
                return MotaImage.GetImage(FaceIndex)[CurFrame];
            }
        }

        /// <summary>
        /// 帧数改变时触发的事件，相当于定时器的功用
        /// </summary>
        protected virtual void FrameOnChange() 
        {
            if (FrameChangeEvent != null)
            {
                FrameChangeEvent(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 获取一个布尔值，标示图像是否可以刷新
        /// </summary>
        protected virtual bool CanRefresh
        {
            get { return Dynamic; }
        }

        /// <summary>
        /// 刷新元素图像，实现动态效果
        /// </summary>
        public void Play()
        {
            if (CanRefresh)
            {
                PlayFace();
            }
        }

        /// <summary>
        /// 驱动图像帧数刷新一次
        /// </summary>
        protected virtual void PlayFace()
        {
            TimeCount++;
            if (TimeCount >= FrameCount)
            {
                TimeCount = 0;
                CurFrame++;
            }
        }
    }
}




