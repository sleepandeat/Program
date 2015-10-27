using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 定时窗口，具体定时显示某些信息的功能
    /// </summary>
    abstract class TimingWindow : GameWindow
    {
        /// <summary>
        /// 创建定时窗口实例
        /// </summary>
        /// <param name="timing">计时数</param>
        public TimingWindow(int timing)
            : base(GameIni.WindowWidth, GameIni.WindowHeight)
        {
            TimeCount = 10000000;
            SumCount = timing;
        }

        /// <summary>
        /// 获取或设置内部消息
        /// </summary>
        protected ShortMessage Message { get; set; }

        /// <summary>
        /// 内部计数值
        /// </summary>
        protected int TimeCount = 0;
        
        /// <summary>
        /// 计数总数量
        /// </summary>
        protected int SumCount = 20;

        /// <summary>
        /// 设置新的消息以打开窗口，强制终止之前的消息显示
        /// </summary>
        /// <param name="data">消息</param>
        public override void Open(object data)
        {
            ShortMessage mesg = data as ShortMessage;
            if (mesg != null)
            {
                this.Message = mesg;
                TimeCount = 0;
                Enable = true;
            }
        }

        /// <summary>
        /// 获取一个布尔值，标示消息是否有效，如果显示时间到达一定数量，则停止显示
        /// </summary>
        public bool Valid
        {
            get 
            {
                if (TimeCount >= SumCount)
                {
                    Enable = false;
                    return false;
                }

                return true; 
            }
        }

    }
}




