using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 附加事件方法类
    /// </summary>
    class AppendEvent
    {
        public AppendEvent(MapEvent user)
        {
            this.User = user;
        }

        /// <summary>
        /// 事件接受者
        /// </summary>
        private MapEvent User;

        /// <summary>
        /// 设置附加事件
        /// </summary>
        /// <param name="eventArgs">事件参数</param>
        public void SetEvent(XElement eventArgs)
        {
            if (eventArgs == null)
            {
                return;
            }

            //添加属性事件
            AddAttribute(eventArgs);

            //楼层跳转事件
            SkipFloor(eventArgs);

            //获取道具
            GetProp(eventArgs);

            //关闭机关事件
            CloseEvent(eventArgs);

            //对话事件
            ShowDialogue(eventArgs);

            //路障事件
            OnTrap(eventArgs);

            //设置附加事件效果
            SetEffect(eventArgs);
        }

        private void SetEffect(XElement eventArgs)
        {
            if (eventArgs.Attribute("effect") != null)
            {
                int value = int.Parse(eventArgs.Attribute("effect").Value);
                User.SetEffect((EffectType)value);
            }
        }

        private void OnTrap(XElement eventArgs)
        {
            if (eventArgs.Element("onTrap") != null)
            {
                int value = int.Parse(eventArgs.Element("onTrap").Value);
                User.AddEvent(EventLogic.OnTrap, new MotaEventArgs(value));
            }
        }

        private void ShowDialogue(XElement eventArgs)
        {
            if (eventArgs.Element("dialogue") != null)
            {
                int diaCount = eventArgs.Element("dialogue").Elements("oneDial").Count();
                Dialogue[] dials = new Dialogue[diaCount];
                for (int i = 0; i < diaCount; i++)
                {
                    string name = eventArgs.Element("dialogue").Elements("oneDial").ElementAt(i).Element("name").Value;
                    string content = eventArgs.Element("dialogue").Elements("oneDial").ElementAt(i).Element("content").Value;
                    dials[i] = new Dialogue(name, content);
                }

                User.AddEvent(EventLogic.OpenDialogue, new MotaEventArgs(dials));
            }
        }

        private void CloseEvent(XElement eventArgs)
        {
            foreach (var item in eventArgs.Elements("close"))
            {
                string posation = item.Value;
                User.AddEvent(EventLogic.CloseEvent, new MotaEventArgs(Posation.GetPosation(posation)));
            
            }
        }

        private void GetProp(XElement eventArgs)
        {
            if (eventArgs.Element("addProp") != null)
            {
                string propName = eventArgs.Element("addProp").Value;
                User.AddEvent(EventLogic.AddProperty, new MotaEventArgs(Property.GetProp(propName)));
            }
        }

        private void SkipFloor(XElement eventArgs)
        {
            if (eventArgs.Element("skipUp") != null)
            {
                User.AddEvent(EventLogic.UpFloor, new MotaEventArgs());
            }
            if (eventArgs.Element("skipDown") != null)
            {
                User.AddEvent(EventLogic.DownFloor, new MotaEventArgs());
            }
        }

        private void AddAttribute(XElement eventArgs)
        {
            if (eventArgs.Element("addHp") != null)
            {
                int value = int.Parse(eventArgs.Element("addHp").Value);
                User.AddEvent(EventLogic.AddHp, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addAttack") != null)
            {
                int value = int.Parse(eventArgs.Element("addAttack").Value);
                User.AddEvent(EventLogic.AddAttack, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addDefence") != null)
            {
                int value = int.Parse(eventArgs.Element("addDefence").Value);
                User.AddEvent(EventLogic.AddDefence, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addAgility") != null)
            {
                int value = int.Parse(eventArgs.Element("addAgility").Value);
                User.AddEvent(EventLogic.AddAgility, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addMagic") != null)
            {
                int value = int.Parse(eventArgs.Element("addMagic").Value);
                User.AddEvent(EventLogic.AddMagic, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addCoin") != null)
            {
                int value = int.Parse(eventArgs.Element("addCoin").Value);
                User.AddEvent(EventLogic.AddCoin, new MotaEventArgs(value));
            }
            if (eventArgs.Element("mulHp") != null)
            {
                double value = double.Parse(eventArgs.Element("mulHp").Value);
                User.AddEvent(EventLogic.MulHp, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addLevel") != null)
            {
                int value = int.Parse(eventArgs.Element("addLevel").Value);
                User.AddEvent(EventLogic.AddLevel, new MotaEventArgs(value));
            }
            if (eventArgs.Element("addExp") != null)
            {
                int value = int.Parse(eventArgs.Element("addExp").Value);
                User.AddEvent(EventLogic.AddExp, new MotaEventArgs(value));
            }
        }
    }
}





