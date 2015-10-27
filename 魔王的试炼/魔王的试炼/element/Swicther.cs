using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //摘要：目前只提供简单的条件判断
    //

    /// <summary>
    /// 事件切换器，当达到某一条件时自动触发开关
    /// </summary>
    class Swicther
    {
        private Swicther(List<EventState> conditions, List<EventState> methods)
        {
            this.Conditions = conditions;
            this.Methods = methods;

            this.Enable = true;
        }

        /// <summary>
        /// 条件列表
        /// </summary>
        private List<EventState> Conditions;

        /// <summary>
        /// 方法列表
        /// </summary>
        private List<EventState> Methods;

        /// <summary>
        /// 获取当前楼层对象的引用
        /// </summary>
        private FloorNode CurFloor
        {
            get
            {
                return MotaWorld.GetInstance().MapManager.CurFloorNode;
            }
        }

        /// <summary>
        /// 获取事件层的某个坐标上是否处于开启状态
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <returns>如果处于开启状态，返回true</returns>
        private bool IsOpen(Coord pos)
        {
            if (!CurFloor.InFloor(pos))
            {
                return false;
            }

            if (CurFloor.EventMap[pos.Row, pos.Col] == null || !CurFloor.EventMap[pos.Row, pos.Col].Exist)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置事件层某一个元素的开关状态
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <param name="closed">是否关闭</param>
        private void SetState(Coord pos, bool closed)
        {
            MapEvent node = CurFloor.EventMap[pos.Row, pos.Col];
            if (node != null)
            {
                if (closed)
                {
                    node.Close();
                }
                else
                {
                    node.Open();
                }
            }
        }

        /// <summary>
        /// 获取一个布尔值，标示是否满足条件
        /// </summary>
        private bool Satisfied
        {
            get
            {
                foreach (var item in Conditions)
                {
                    //应该处于关闭状态却没有关闭
                    if (item.Closed && IsOpen(item.EventPosation))
                    {
                        return false;
                    }

                    //应该处于开启状态却没有开启
                    if (!item.Closed && !IsOpen(item.EventPosation))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// 获取或设置这项开关是否可用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 开始运转
        /// </summary>
        private void Operate()
        {
            if (Enable)
            {
                foreach (var item in Methods)
                {
                    SetState(item.EventPosation, item.Closed);
                }

                this.Enable = false;
            }
        }

        /// <summary>
        /// 进行一次事件检测，如果满足条件，转动开关
        /// </summary>
        public void Check()
        {
            if (Satisfied)
            {
                Operate();
            }
        }

        /// <summary>
        /// 根据xml元素结点创建开关器
        /// </summary>
        /// <param name="curFloor">当前楼层的引用</param>
        /// <param name="node">xml结点</param>
        /// <returns>开关器对象</returns>
        public static Swicther CreateFromXml(XElement node)
        {
            XElement xmlCondition = node.Element("if");
            XElement xmlMethods = node.Element("then");

            List<EventState> conditions = new List<EventState>();
            foreach (var item in xmlCondition.Elements())
            {
                conditions.Add(EventState.Create(item));
            }

            List<EventState> methods = new List<EventState>();
            foreach (var item in xmlMethods.Elements())
            {
                methods.Add(EventState.Create(item));
            }

            return new Swicther(conditions, methods);
        }

        /// <summary>
        /// 获取对象的xml形式的记录
        /// </summary>
        public XElement XmlRecord
        {
            get
            {
                XElement node = new XElement("switcher");
                XElement condition = new XElement("if");
                foreach (var item in this.Conditions)
                {
                    condition.Add(item.XmlRecord);
                }

                XElement method = new XElement("then");
                foreach (var item in this.Methods)
                {
                    method.Add(item.XmlRecord);
                }

                node.Add(condition);
                node.Add(method);

                return node;
            }
        }
    }
}













