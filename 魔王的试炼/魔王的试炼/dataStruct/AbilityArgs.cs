using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 基本能力属性参数类
    /// </summary>
    class AbilityArgs
    {
        /// <summary>
        /// 创建属性参数实例
        /// </summary>
        /// <param name="level">等级</param>
        /// <param name="attack">攻击力</param>
        /// <param name="defence">防御力</param>
        /// <param name="agility">敏捷</param>
        /// <param name="magic">魔法</param>
        protected AbilityArgs(int level, int attack, int defence, int agility, int magic)
        {
            this.Attack = attack;
            this.Defence = defence;
            this.Agility = agility;
            this.Magic = magic;
            this.Level = level;
        }

        /// <summary>
        /// 攻击力
        /// </summary>
        public int Attack;

        /// <summary>
        /// 防御力
        /// </summary>
        public int Defence;

        /// <summary>
        /// 敏捷
        /// </summary>
        public int Agility;

        /// <summary>
        /// 魔法
        /// </summary>
        public int Magic;

        /// <summary>
        /// 等级
        /// </summary>
        public int Level;

        /// <summary>
        /// 根据事件参数获取属性配置
        /// </summary>
        /// <param name="eventArgs">事件参数</param>
        /// <returns>属性配置</returns>
        public static AbilityArgs CreateFrom(XElement eventArgs)
        {
            AbilityArgs data;
            try
            {
                int level = int.Parse(eventArgs.Attribute("level").Value);
                int attack = int.Parse(eventArgs.Attribute("attack").Value);
                int defence = int.Parse(eventArgs.Attribute("defence").Value);
                int agility = int.Parse(eventArgs.Attribute("agility").Value);
                int magic = int.Parse(eventArgs.Attribute("magic").Value);
                data = new AbilityArgs(level, attack, defence, agility, magic);
            }
            catch (Exception)
            {
                throw new Exception("装备能力读取错误");
            }

            return data;
        }

        /// <summary>
        /// 将自身实例保存于xml元素中
        /// </summary>
        /// <param name="xmlRecord">xml元素</param>
        public void SaveTo(XElement xmlRecord)
        {
            xmlRecord.SetAttributeValue("level", this.Level);
            xmlRecord.SetAttributeValue("magic", this.Magic);
            xmlRecord.SetAttributeValue("agility", this.Agility);
            xmlRecord.SetAttributeValue("attack", this.Attack);
            xmlRecord.SetAttributeValue("defence", this.Defence);
        }
       
    }
}




