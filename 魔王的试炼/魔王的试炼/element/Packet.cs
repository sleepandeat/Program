using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 背包，存储各种游戏道具
    /// </summary>
    class Packet
    {
        /// <summary>
        /// 初始化道具,初始数量为0
        /// </summary>            
        private Packet()
        { 
            //非消耗品
            PropList.Add(new HoldProp(PropName.怪物侦测器, MotaElement.怪物探测器));
            PropList.Add(new BookProp());
            PropList.Add(new SkipProp());
            PropList.Add(new HoldProp(PropName.自然之靴, MotaElement.自然之靴));
            PropList.Add(new UpStair());

            //消耗品
            PropList.Add(new DestroyProp());
            PropList.Add(new KeyProp(MotaElement.小红钥匙, PropName.红钥匙));
            PropList.Add(new KeyProp(MotaElement.小蓝钥匙, PropName.蓝钥匙));
            PropList.Add(new KeyProp(MotaElement.小黄钥匙, PropName.黄钥匙));

            //绑定道具栏重绘事件
            foreach (var item in PropList)
            {
                item.CountChangeEvent += new Property.CountChangeHandle(OnChange);
            }
        }
        
        /// <summary>
        /// 道具列表
        /// </summary>
        private List<Property> PropList = new List<Property>(0);

        /// <summary>
        /// 道具数量改变时触发的事件
        /// </summary>
        public event EventHandler PropertyChangeEvent = null;

        /// <summary>
        /// 根据道具使用按键使用相应的道具
        /// </summary>
        /// <param name="name">道具使用按键</param>
        /// <param name="user">道具使用者</param>
        public void UseProperty(System.Windows.Forms.Keys keyCode, IPropUser user)
        {
            foreach (var item in PropList)
            {
                if (item.UseKeyCode == keyCode)
                {
                    if (item.Count > 0)
                    {
                        item.Use(user);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 获取一个布尔值，标示背包中是否存在某种道具
        /// </summary>
        /// <param name="name">道具名称</param>
        public bool ExistProperty(PropName name)
        {
            return GetPropertyNumber(name) >= 1;
        }

        /// <summary>
        /// 获取道具的数量
        /// </summary>
        /// <param name="name">道具名称</param>
        public int GetPropertyNumber(PropName name)
        {
            foreach (var item in PropList)
            {
                if (item.Name == name)
                {
                    return item.Count;
                }
            }
            return 0;
        }

        /// <summary>
        /// 给背包中增加某种道具
        /// </summary>
        /// <param name="name">道具名称</param>
        /// <param name="number">增加数量</param>
        public void AddProperty(PropName name, int number = 1)
        {
            foreach (var item in PropList)
            {
                if (item.Name == name)
                {
                    item.Count += number;
                }
            }
        }

        /// <summary>
        /// 给背包中减少某种道具
        /// </summary>
        /// <param name="name">道具名称</param>
        /// <param name="number">减少数量</param>
        public void RemoveProperty(PropName name, int number = 1)
        {
            foreach (var item in PropList)
            {
                if (item.Name == name)
                {
                    item.Count -= number;
                }
            }
        }

        /// <summary>
        /// 绘制道具包到画布
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="mapSize">画布的坐标尺寸</param>
        public void DrawPacket(Graphics g, Coord coordSize)
        {
            //绘制点的当前坐标
            Coord curStation = Coord.Empty;

            g.Clear(Color.Transparent);

            //把所有道具绘制出来
            foreach (var item in PropList)
            {
                Bitmap icon = item.Icon;
                for (int i = 0; i < item.Count; i++)
                {
                    g.DrawImage(icon, new Rectangle(curStation.Col * GameIni.PropIcon.Width,
                        curStation.Row * GameIni.PropIcon.Height, GameIni.PropIcon.Width,
                        GameIni.PropIcon.Height), new Rectangle(0, 0, icon.Width,
                            icon.Height), GraphicsUnit.Pixel);

                    //移动绘制点的坐标
                    curStation.Col++;
                    if (curStation.Col >= coordSize.Col)
                    {
                        curStation.Col = 0;
                        curStation.Row++;
                    }

                    //如果不是消耗品，只绘制一次
                    if (!item.Consumable)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 更新道具栏的图标显示
        /// </summary>
        public void OnChange()
        {
            if (PropertyChangeEvent != null)
            {
                PropertyChangeEvent(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static Packet Create(XElement createArgs)
        {
            Packet pack = new Packet();
            IEnumerable<XElement> props = createArgs.Elements("prop");
            foreach (var item in props)
            {
                string propName = item.Attribute("name").Value;
                int number = int.Parse(item.Value);
                pack.AddProperty(Property.GetProp(propName), number);
            }

            return pack;
        }

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public XElement XmlRecord
        {
            get
            {
                XElement xmlRecord = new XElement("packet");
                foreach (var prop in PropList)
                {
                    XElement oneProp = new XElement("prop", prop.Count);
                    oneProp.SetAttributeValue("name", prop.Name);
                    xmlRecord.Add(oneProp);
                }

                return xmlRecord;
            }
        }
    }
}


















