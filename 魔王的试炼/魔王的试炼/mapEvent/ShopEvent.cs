using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 商店类，用于打开商店窗口进行金币或经验的交易
    /// 只限于金币和经验两种形式的交易
    /// </summary>
    class ShopEvent : MapEvent
    {
        /// <summary>
        /// 创建商店实例，并提供选项参数
        /// </summary>
        /// <param name="faceFile">商店图像文件</param>
        /// <param name="p">商店坐标</param>
        /// <param name="name">商店名称</param>
        /// <param name="deals">交易参数信息</param>
        /// <param name="desc">商店说明</param>
        /// <param name="unitSize">图像分割的尺寸</param>
        private ShopEvent(string faceFile, Coord p, string name, DealArgs[] deals, string desc, Size unitSize)
            : base(faceFile, p, TouchMethod.ImmediatelyTouch, true, name, unitSize)
        {
            this.DealOptions = deals;
            this.ShopMessage = desc;
        }

        private string ShopMessage;
        /// <summary>
        /// 交易参数信息
        /// </summary>
        private DealArgs[] DealOptions;

        /// <summary>
        /// 重写触发函数，加上打开商店窗口的事件
        /// </summary>
        /// <param name="player">调用者</param>
        public override void TriggerEvent(Hero player)
        {
            //获取交易者
            Idealer dealer = MotaWorld.GetInstance().MapManager.CurHero as Idealer;

            //商店引用
            Shop shop = MotaWorld.GetInstance().ShopWindow;
            
            //重新更新商店选项
            shop.RemoveAllOptions();
            for (int i = 0; i < DealOptions.Length; i++)
            {
                DealOption o = new DealOption(DealOptions[i]);
                shop.AddOption(o);
            }
            //添加交易关闭选项
            shop.AddOption(new DealOption("        关闭商店"));
            shop.ShopMessage = this.ShopMessage;

            shop.Open(dealer);

            base.TriggerEvent(player);
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Shop; }
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
            string description = createArgs.Attribute("description").Value;

            int dealCount = createArgs.Element("deals").Elements("deal").Count();
            DealArgs[] deals = new DealArgs[dealCount];
            for (int i = 0; i < dealCount; i++)
            {
                deals[i] = DealArgs.CreateFrom(createArgs.Element("deals").Elements("deal").ElementAt(i));    
            }

            return new ShopEvent(fileName, existCoord, name, deals, description, GameIni.UnitSize);
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("imagefile", MotaImage.GetFileName(this.FaceIndex));
            eventType.SetAttributeValue("description", this.ShopMessage);

            //添加交易项数据
            XElement deals = new XElement("deals");
            foreach (var item in this.DealOptions)
            {
                XElement deal = new XElement("deal");
                item.SaveTo(deal);
                deals.Add(deal);
            }

            eventType.Add(deals);
        }
    }
}









