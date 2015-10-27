using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //摘要:
    //  地图事件类，通过系统事件和用户事件的触发引擎
    //
    //设计:
    //  设置系统事件可以继承此类，内设工厂方法
    //
    //
    //
    //
    /// <summary>
    /// 地图事件类,为每一个地图单元准备一系列的事件触发器.
    /// </summary>
    abstract class MapEvent : MapElement
    {
        /// <summary>
        /// 设置事件元素实例
        /// </summary>
        /// <param name="face">图像索引</param>
        /// <param name="showPosation">事件在地图上的坐标</param>
        /// <param name="method">触发方式</param
        /// <param name="repeated">是否是触发触发的事件</param>
        /// <param name="eventName">事件名</param>
        protected MapEvent(MotaElement face, Coord showPosation, TouchMethod method, bool repeated, string eventName) 
            : base(face, showPosation)
        {
            SetAttr(method, repeated, eventName);
        }

        /// <summary>
        /// 根据自定义的图像设置事件元素实例
        /// </summary>
        /// <param name="fileName">图像文件名</param>
        /// <param name="showPosation">事件在地图上的坐标</param>
        /// <param name="method">触发方式</param
        /// <param name="repeated">是否是触发触发的事件</param>>
        /// <param name="eventName">事件名</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        protected MapEvent(string fileName, Coord showPosation, TouchMethod method, bool repeated, string eventName, Size unitSize)
            : base(fileName, showPosation, unitSize)
        {
            SetAttr(method, repeated, eventName);

            this.FaceUnit = unitSize;
        }

        /// <summary>
        /// 构造时设置类成员属性
        /// </summary>
        /// <param name="method">触发方式</param>
        /// <param name="repeated">是否是触发触发的事件</param>
        /// <param name="eventName">事件名</param>
        private void SetAttr(TouchMethod method, bool repeated, string eventName)
        {
            //约定直接触发的事件是不可通行的
            if (method == TouchMethod.StationTouch)
            {
                CanPass = true;
            }
            else if (method == TouchMethod.ImmediatelyTouch)
            {
                CanPass = false;
            }

            Enable = true;
            Repeated = repeated;
            TriggerMethod = method;
            EventName = eventName;
            CanFocus = true;
        }

        /// <summary>
        /// 事件类型码字符串标示符
        /// </summary>
        const string EVENT_TYPE_STR = "eventType";

        /// <summary>
        /// 事件附加字符串标示符
        /// </summary>
        const string EVENT_ADD_STR = "eventAdd";

        /// <summary>
        /// 根据事件类型码创建相应的事件元素
        /// </summary>
        /// <param name="createArgs">事件参数</param>
        /// <param name="existCoord">出现坐标</param>
        /// <returns>事件元素</returns>
        public static MapEvent CreateInstance(XElement createArgs, Coord existCoord)
        {
            XElement eventArgs = createArgs.Element(EVENT_TYPE_STR);
            EventType typeCode = (EventType)int.Parse(eventArgs.Value);

            MapEvent mapEvent;

            switch (typeCode)
            {
                case EventType.Empty:
                    mapEvent = EmptyEvent.Create(eventArgs, existCoord);
                    break;
                case EventType.Box:
                    mapEvent = Box.Create(eventArgs, existCoord);
                    break;
                case EventType.Door:
                    mapEvent = Door.Create(eventArgs, existCoord);
                    break;
                case EventType.Equip:
                    mapEvent = Equip.Create(eventArgs, existCoord);
                    break;
                case EventType.Hero:
                    mapEvent = Hero.Create(eventArgs);
                    break;
                case EventType.Monster:
                    mapEvent = Monster.Create(eventArgs, existCoord);
                    break;
                case EventType.Shop:
                    mapEvent = ShopEvent.Create(eventArgs, existCoord);
                    break;
                case EventType.Weapon:
                    mapEvent = Weapon.Create(eventArgs, existCoord);
                    break;
                case EventType.NullEvent:
                    return null;
                default: 
                    throw new Exception("不存在的类型码");

            }

            mapEvent.SetEvent(createArgs.Element(EVENT_ADD_STR));
            return mapEvent;
        }

        /// <summary>
        /// 设置附加事件
        /// </summary>
        /// <param name="eventArgs">事件参数</param>
        private void SetEvent(XElement eventArgs)
        {
            TouchEventData.Clear();

            new AppendEvent(this).SetEvent(eventArgs);

            //缓存
            XmlEvent = eventArgs;
        }

        private Size FaceUnit = GameIni.UnitSize;

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public virtual XElement XmlRecord
        {
            get
            {
                if (!this.Exist)
                {
                    return MapEvent.EmptyXml;
                }

                XElement xmlRecord = new XElement("oneEvent");

                //添加事件类型元素
                XElement eventType = new XElement(EVENT_TYPE_STR, (int)this.TypeCode);

                if (!(this is Character))
                {
                    eventType.SetAttributeValue("eventName", this.EventName);    
                }
                
                eventType.SetAttributeValue("unitSize", this.FaceUnit.ToXmlString());
                
                this.SaveTypeTo(eventType);
                xmlRecord.Add(eventType);

                //添加附加事件元素
                if (XmlEvent != null && this.Enable)
                {
                    xmlRecord.Add(XmlEvent);
                }

                return xmlRecord;
            }
        }

        /// <summary>
        /// 存储类型信息到xml元素
        /// </summary>
        /// <param name="eventType">类型元素</param>
        abstract protected void SaveTypeTo(XElement eventType);

        /// <summary>
        /// 记录xml的附加事件
        /// </summary>
        private XElement XmlEvent;

        /// <summary>
        /// 根据尺寸字符串参数获取尺寸实例
        /// </summary>
        protected static Size GetSize(string sizeArgs)
        {
            if (sizeArgs.CompareTo(string.Empty) == 0)
            {
                return GameIni.UnitSize;
            }
            else
            {
                string[] strs = sizeArgs.Split(',');
                if (strs.Length != 2)
                {
                    return GameIni.UnitSize;
                }
                else
                {
                    return new Size(int.Parse(strs[0]), int.Parse(strs[1]));
                }
            }
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public abstract EventType TypeCode { get; }

        /// <summary>
        /// 获取或设置事件是否可用
        /// 这里的enable可以使事件冻结
        /// </summary>
        protected bool Enable { get; set; }

        /// <summary>
        /// 获取或设置事件是否重复触发
        /// </summary>
        protected bool Repeated { get; set; }

        /// <summary>
        /// 获取或设置事件接触的方法
        /// </summary>
        public TouchMethod TriggerMethod { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        private event TouchHandle TouchEvent = null;

        /// <summary>
        /// 事件委托
        /// </summary>
        /// <param name="datas">事件参数</param>
        /// <param name="player">调用者</param>
        public delegate void TouchHandle(Queue<MotaEventArgs> datas, Hero player);

        /// <summary>
        /// 事件参数队列
        /// </summary>
        private Queue<MotaEventArgs> TouchEventData = new Queue<MotaEventArgs>(0);

        /// <summary>
        /// 获取或设置事件名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 添加事件并提供作用数据
        /// </summary>
        /// <param name="e">事件方法</param>
        /// <param name="data">作用数据</param>
        public void AddEvent(TouchHandle e, MotaEventArgs data)
        {
            TouchEvent += e;

            //设置事件参数的固有属性
            data.Name = EventName;
            data.ExistStation = Common.GetStation(this.Location);
            TouchEventData.Enqueue(data);
        }

        /// <summary>
        /// 调用此事件元素上的接触时事件
        /// </summary>
        /// <param name="player">调用者</param>
        public virtual void TriggerEvent(Hero player)
        {
            if (!Enable)
            {
                return;
            }

            //拷贝参数数据
            Queue<MotaEventArgs> TempData = new Queue<MotaEventArgs>(TouchEventData);
            if (TouchEvent != null)
            {
                //调用方法列表
                TouchEvent(TempData, player);
            }

            //如果不是重复触发的事件，调用一次之后就要关闭
            if (!Repeated)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 事件获取焦点时的图像的缓存
        /// </summary>
        private static Bitmap FocusFace;

        /// <summary>
        /// 当前类实例中获取焦点的图像的索引
        /// </summary>
        private static int FocusFaceIndex = -1;

        /// <summary>
        /// 获取绘制描述内容的起始点
        /// </summary>
        private Point DescPoint
        {
            get 
            {
                Point strPoint = Point.Empty;
                strPoint.X = Location.X + (GameIni.ElementWidth / 2 - 8 * EventName.Length);
                strPoint.Y = PaintPoint.Y - 20;
                return strPoint;
            }
        }
        
        /// <summary>
        /// 绘制元素图像到画布，如果具有焦点，绘制焦点效果
        /// </summary>
        /// <param name="canvas">画布</param>
        public override void Draw(Graphics canvas)
        {
            if (Exist && CurFace != null)
            {
                //如果获取焦点，显示事件名称并进行描边
                if (this.Focused)
                {
                    //当焦点图像缓存为空时，重新绘制，否则直接输出
                    if (FocusFace == null || FocusFaceIndex != this.FaceIndex)
                    {
                        SetFocus();
                    }

                    canvas.DrawImage(FocusFace, PaintPoint);
                    canvas.DrawString(EventName, new Font("幼圆", 12, FontStyle.Bold), new SolidBrush(Color.White), DescPoint);
                }
                else
                {
                    //绘制事件的时候不需要绘制空地
                    canvas.DrawImage(CurFace, PaintPoint);
                }
            }
        }

        /// <summary>
        /// 设置焦点图像
        /// </summary>
        private void SetFocus()
        {
            FocusFaceIndex = this.FaceIndex;
            FocusFace = new Bitmap(CurFace);
            FocusFace.Stroke(Color.FromArgb(180, 0, 153, 255));
            FocusFace.Stroke(Color.FromArgb(120, 0, 153, 255));
        }

        /// <summary>
        /// 获取或设置元素是否可以获取焦点
        /// </summary>
        public bool CanFocus { get; set; }

        private bool focused = false;
        /// <summary>
        /// 获取或设置事件图像是否获取鼠标焦点，当鼠标落在事件图像上时
        /// 设置焦点为true.
        /// </summary>
        public bool Focused
        {
            get { return focused; }
            set {
                if (CanFocus)
                {
                    focused = value;
                }
            }
        }

        /// <summary>
        /// 设置事件效果
        /// </summary>
        /// <param name="type">效果类型</param>
        public void SetEffect(EffectType type)
        {
            if (TouchEventData.Count > 0)
            {
                TouchEventData.Peek().Method = type;
            }
        }

        /// <summary>
        /// 获取缺省的地图xml数据
        /// </summary>
        public static XElement EmptyXml
        {
            get
            {
                XElement empty = new XElement("oneEvent");
                empty.Add(new XElement("eventType", (int)EventType.NullEvent));
                return empty;
            }
        }
    }
}














