using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 空事件类，用于描述基础事件类型
    /// </summary>
    class EmptyEvent : MapEvent
    {
        /// <summary>
        /// 根据自定义的图像设置事件元素实例
        /// </summary>
        /// <param name="fileName">图像文件名</param>
        /// <param name="showPosation">事件在地图上的坐标</param>
        /// <param name="method">触发方式</param
        /// <param name="repeated">是否是触发触发的事件</param>>
        /// <param name="eventName">事件名</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        private EmptyEvent(string fileName, Coord showPosation, TouchMethod method, bool repeated, string eventName, Size unitSize)
            : base(fileName, showPosation, method, repeated, eventName, unitSize)
        {
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Empty; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            string fileName;
            if (createArgs.Attribute("imagefile") == null)
            {
                fileName = null;
            }
            else
            {
                fileName = createArgs.Attribute("imagefile").Value;
            }
            TouchMethod method = createArgs.Attribute("touchMethod").Value.CompareTo("station") == 0 ? TouchMethod.StationTouch : TouchMethod.ImmediatelyTouch;
            bool repeated = createArgs.Attribute("repeated").Value.ToLower().CompareTo("true") == 0;
            string name = createArgs.Attribute("eventName").Value;
            Size unitSize = GetSize(createArgs.Attribute("unitSize").Value);

            return new EmptyEvent(fileName, existCoord, method, repeated, name, unitSize);
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("imagefile", MotaImage.GetFileName(this.FaceIndex));

            eventType.SetAttributeValue("touchMethod", this.TriggerMethod == TouchMethod.StationTouch ? "station" : "");
            eventType.SetAttributeValue("repeated", this.Repeated.ToString());
        }
    }
}













