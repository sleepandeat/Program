using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 可携带道具类，为背包类提供数据单元
    /// </summary>
    abstract class Property
    {
        /// <summary>
        /// 以道具名称创建道具的实例
        /// </summary>
        /// <param name="index">道具图像索引</param>
        /// <param name="name">道具名称</param>
        /// <param name="isConsumables">道具是否是消耗品</param>
        /// <param name="keyCode">使用按键</param>
        /// <param name="number">道具拥有数量, 默认为0</param>
        public Property(MotaElement index, PropName name, bool isConsumables, System.Windows.Forms.Keys keyCode, int number = 0)
        {
            this.FaceIndex = (int)index;

            this.Name = name;

            this.count = number;

            this.UseKeyCode = keyCode;

            this.Consumable = isConsumables;
        }

        /// <summary>
        /// 获取或设置道具名称
        /// </summary>
        public PropName Name { get; set; }

        /// <summary>
        /// 标示道具是否是消耗品
        /// </summary>
        public bool Consumable { get; set; }

        public delegate void CountChangeHandle();
        /// <summary>
        /// 道具数量改变时触发的事件
        /// </summary>
        public event CountChangeHandle CountChangeEvent = null;

        private int count;
        /// <summary>
        /// 获取或设置道具的拥有数量
        /// </summary>
        public int Count
        {
            get { return count; }
            set
            {
                count = value;

                if (CountChangeEvent != null)
                {
                    CountChangeEvent();
                }
            }
        }

        /// <summary>
        /// 如果道具是可消耗的话，减少道具数量1
        /// </summary>
        protected void CutDown() 
        {
            if (Consumable)
            {
                Count--;
            }
        }

        /// <summary>
        /// 获取或设置使用道具的按键
        /// </summary>
        public System.Windows.Forms.Keys UseKeyCode { get; set; }

        /// <summary>
        /// 使用道具
        /// </summary>
        /// <param name="user">道具使用者</param>
        public abstract void Use(IPropUser user);

        private int FaceIndex;

        /// <summary>
        /// 获取道具显示在道具栏里的图像
        /// </summary>
        public Bitmap Icon
        {
            get { return MotaImage.GetImage(FaceIndex)[0]; }
        }

        /// <summary>
        /// 根据道具名称获取描述信息
        /// </summary>
        /// <param name="name">道具名称</param>
        /// <returns>描述字符串</returns>
        public static string GetDescribe(PropName name)
        {
            string desc = string.Empty;
            switch (name)
            {
                case PropName.怪物手册:
                    desc += "获得怪物手册！\r\n按空格即可查看所在楼层的怪物信息以及可预测的基本伤害";
                    break;
                case PropName.楼层传送器:
                    desc += "获得楼层传送器！\r\n按J即可打开楼层跳转界面";
                    break;
                case PropName.破墙镐:
                    desc += "获得破墙镐！\r\n按P使用破墙镐，可以破坏一堵墙。获取宝物、打开密道时使用最佳。";
                    break;
                case PropName.自然之靴:
                    desc += "获得自然之靴！\r\n获得后可以无伤害地在路障陷阱中自由行走，非消耗品";
                    break;
                case PropName.上楼器:
                    desc += "获得上楼器！\r\n上楼器可以无视当前楼层的任何阻碍而进入下一层按U使用此道具.";
                    break;
                case PropName.道具包:
                    desc += "";
                    break;
                case PropName.怪物侦测器:
                    desc += "获得怪物侦测器！\r\n获得后可以用鼠标右键点击怪物查看怪物的详细信息，比怪物手册更加先进！";
                    break;

                default:
                    break;
            }
            return desc;
        }

        /// <summary>
        /// 根据描述字符串获取道具类型
        /// </summary>
        /// <param name="args">描述字符串</param>
        /// <returns>道具类型</returns>
        public static PropName GetProp(string args)
        {
            Dictionary<string, PropName> propDic = new Dictionary<string, PropName>();
            propDic.Add("黄钥匙", PropName.黄钥匙);
            propDic.Add("蓝钥匙", PropName.蓝钥匙);
            propDic.Add("红钥匙", PropName.红钥匙);
            propDic.Add("道具包", PropName.道具包);
            propDic.Add("怪物手册", PropName.怪物手册);
            propDic.Add("怪物侦测器", PropName.怪物侦测器);
            propDic.Add("楼层传送器", PropName.楼层传送器);
            propDic.Add("破墙镐", PropName.破墙镐);
            propDic.Add("上楼器", PropName.上楼器);
            propDic.Add("自然之靴", PropName.自然之靴);
            propDic.Add("事件钥", PropName.事件钥);
            propDic.Add("NULL", PropName.NULL);
            return propDic[args];
        }

        /// <summary>
        /// 根据道具类型获取道具名称
        /// </summary>
        /// <param name="prop">描述字符串</param>
        /// <returns>名称</returns>
        public static string GetName(PropName prop)
        {
            Dictionary<PropName, string> propDic = new Dictionary<PropName, string>();
            propDic.Add(PropName.黄钥匙, "黄钥匙");
            propDic.Add(PropName.蓝钥匙, "蓝钥匙");
            propDic.Add(PropName.红钥匙, "红钥匙");
            propDic.Add(PropName.道具包, "道具包");
            propDic.Add(PropName.怪物手册, "怪物手册");
            propDic.Add(PropName.怪物侦测器, "怪物侦测器");
            propDic.Add(PropName.楼层传送器, "楼层传送器");
            propDic.Add(PropName.破墙镐, "破墙镐");
            propDic.Add(PropName.上楼器, "上楼器");
            propDic.Add(PropName.自然之靴, "自然之靴");
            propDic.Add(PropName.事件钥, "事件钥");
            propDic.Add(PropName.NULL, "NULL");
            return propDic[prop];
        }

    }
}












