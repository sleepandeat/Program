using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 记录事件状态的结构体，不可变类
    /// </summary>
    struct EventState
    {
        public EventState(Coord pos, bool isClose)
        {
            this.eventPosation = pos;
            this.closed = isClose;
        }

        /// <summary>
        /// 事件位置
        /// </summary>
        private Coord eventPosation;

        /// <summary>
        /// 一个布尔值，表示事件是否处于关闭状态
        /// </summary>
        private bool closed;

        /// <summary>
        /// 获取事件位置
        /// </summary>
        public Coord EventPosation
        {
            get { return this.eventPosation; }
        }

        /// <summary>
        /// 获取一个布尔值，表示事件是否处于关闭状态
        /// </summary>
        public bool Closed
        {
            get { return this.closed; }
        }

        /// <summary>
        /// 根据xml元素结点构造一个事件状态结构
        /// </summary>
        /// <param name="xmlNode">xml元素结构</param>
        /// <returns>一个表示事件元素状态的结构</returns>
        public static EventState Create(XElement xmlNode)
        {
            Coord pos = Coord.CreateFromString(xmlNode.Value);

            if (xmlNode.Name.ToString().CompareTo("open") == 0)
            {
                return new EventState(pos, false);
            }
            else
            {
                return new EventState(pos, true);
            }
        }

        /// <summary>
        /// 获取结构的xml记录
        /// </summary>
        public XElement XmlRecord
        {
            get
            {
                string name = this.Closed ? "close" : "open";
                XElement xmlNode = new XElement(name, this.EventPosation.ToString());
                return xmlNode;
            }
        }
    }
}








