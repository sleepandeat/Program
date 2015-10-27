using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //FloorNode类的的一些方法可以搬移到此类

    //把地表和事件单独讨论是初期设计的一大失误

    /// <summary>
    /// 元素节点(不可变结构)
    /// </summary>
    class ElementNode
    {
        /// <summary>
        /// 创建元素结点的副本
        /// </summary>
        /// <param name="desBack">地表元素</param>
        /// <param name="desEvent">事件元素</param>
        public ElementNode(Background desBack, MapEvent desEvent)
        {
            //引用
            _Back = desBack;
            _Event = desEvent;

            //深度拷贝
            _Back = GetBack(Coord.Empty);
            _Event = GetEvent(Coord.Empty);
        }

        private Background _Back;

        private MapEvent _Event;

        /// <summary>
        /// 获取地表元素的副本
        /// </summary>
        /// <param name="pos">副本出现的坐标</param>
        public Background GetBack(Coord pos)
        {
            return Background.CreateInstance(_Back.XmlRecord, pos);
        }

        /// <summary>
        /// 获取事件元素的副本
        /// </summary>
        /// <param name="pos">副本出现的坐标</param>
        public MapEvent GetEvent(Coord pos)
        {
            if (_Event == null)
            {
                return MapEvent.CreateInstance(MapEvent.EmptyXml, pos);
            }
            return MapEvent.CreateInstance(_Event.XmlRecord, pos);
        }
        
        /// <summary>
        /// 根据xml结点创建地图元素
        /// </summary>
        /// <param name="xmlNode">xml结点</param>
        /// <returns>地图结点元素</returns>
        public static ElementNode GetNode(XElement xmlNode)
        {
            Background back = Background.CreateInstance(xmlNode.Element("oneBack"), Coord.Empty);
            MapEvent eve = MapEvent.CreateInstance(xmlNode.Element("oneEvent"), Coord.Empty);

            return new ElementNode(back, eve);
        }

        /// <summary>
        /// 将实例对象写出Xml形式
        /// </summary>
        /// <returns>xml结点</returns>
        public XElement WriteToXml()
        {
            XElement xmlNode = new XElement("element");
            xmlNode.Add(this._Back.XmlRecord);
            if (this._Event == null)
            {
                xmlNode.Add(MapEvent.EmptyXml);
            }
            else
            {
                xmlNode.Add(this._Event.XmlRecord);
            }
            return xmlNode;
        }
    }
}






