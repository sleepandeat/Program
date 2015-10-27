using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 门事件，处理开门和减钥匙的系统事件
    /// 花门、铁门、暗墙已经可以消去的障碍物都可以看做是门类
    /// </summary>
    class Door : MapEvent
    {
        /// <summary>
        /// 创建门的实例
        /// </summary>
        /// <param name="fileName">图像文件名</param>
        /// <param name="pos">门位置</param>
        /// <param name="name">名称</param>
        /// <param name="key">需求的钥匙</param>
        /// <param name="exist">存在性</param>
        /// <param name="unitSize">图像分割的单位尺寸</param>
        private Door(string fileName, Coord pos, string name, PropName key, Size unitSize, bool exist = true)
            : base(fileName, pos, TouchMethod.ImmediatelyTouch, true, name, unitSize)
        {
            //存在性，默认存在，如果想要实现通过其他事件来开启障碍物，需要为false.
            base.Exist = exist;

            //默认不可播放
            base.Dynamic = false;

            //不可重复播放，播放一次动画后消失
            base.RepeatFlash = false;

            //快速的播放频率
            base.PlayInterval = 50;

            this.Key = key;

            CanFocus = false;
        }

        /// <summary>
        /// 需求的钥匙
        /// </summary>
        private PropName Key;

        /// <summary>
        /// 重写触发函数，加上开门系统事件
        /// </summary>
        /// <param name="player">调用者</param>
        public override void TriggerEvent(Hero player)
        {
            if (Enable && Key != PropName.事件钥)
            {
                //背包中存在钥匙或不要求钥匙直接开门
                if (MotaWorld.GetInstance().MapManager.CurHero.Pack.ExistProperty(Key) || Key == PropName.NULL)
                {
                    Close();
                }
            }

            //重复撞门都会触发以下事件,直到门消失为止
            base.TriggerEvent(player);
        }

        /// <summary>
        /// 设置门，开启元素
        /// </summary>
        public override void Open() 
        {
            this.Dynamic = false;
            CurFrame = 0;
            Enable = true;

            base.Open();
        }

        /// <summary>
        /// 开门，等待门自动关闭
        /// </summary>
        public override void Close()
        {
            //如果存在此种钥匙,则减去钥匙并开门
            Dynamic = true;

            //减去需求的钥匙，如果钥匙不存在，没有影响
            MotaWorld.GetInstance().MapManager.CurHero.Pack.RemoveProperty(Key);

            if (Key == PropName.NULL || Key == PropName.事件钥)
            {
                SoundsList.PlaySound(SoundType.暗墙);
            }
            else
            {
                SoundsList.PlaySound(SoundType.开门);
            }
            Enable = false;
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Door; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            string fileName = createArgs.Attribute("imagefile").Value;
            string name = createArgs.Attribute("eventName").Value;
            Size unitSize = GetSize(createArgs.Attribute("unitSize").Value);
            PropName key = Property.GetProp(createArgs.Attribute("key").Value);
            bool exist = createArgs.Attribute("exist").Value.ToLower().CompareTo("false") != 0;

            return new Door(fileName, existCoord, name, key, unitSize, exist);
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("imagefile", MotaImage.GetFileName(this.FaceIndex));

            eventType.SetAttributeValue("key", Property.GetName(this.Key));
            eventType.SetAttributeValue("exist", this.Exist.ToString());
        }
    }
}





