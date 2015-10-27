using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 交易参数类, 基本的交易数据类型
    /// </summary>
    class DealArgs : AbilityArgs
    {
        /// <summary>
        /// 创建交易参数
        /// </summary>
        /// <param name="desc">交易选项的描述</param>
        /// <param name="coin">需要的金币</param>
        /// <param name="exp">需要的经验</param>
        /// <param name="hp">获得的生命值</param>
        /// <param name="attack">获得的攻击力</param>
        /// <param name="defence">获得的防御值</param>
        /// <param name="level">获得的等级</param>
        /// <param name="agility">获得的敏捷</param>
        /// <param name="magic">获得的魔法</param>
        public DealArgs(string desc, int coin, int exp, int hp, int attack, int defence, int level, int agility, int magic)
            : base(level, attack, defence, agility, magic)
        {
            this.DealName = desc;
            this.CoinDemand = coin;
            this.ExpDemand = exp;
            this.HpUp = hp;
        }

        /// <summary>
        /// 根据事件参数获取交易属性配置
        /// </summary>
        /// <param name="eventArgs">事件参数</param>
        /// <returns>属性配置</returns>
        public new static DealArgs CreateFrom(XElement eventArgs)
        {
            int level, attack, defence, agility, magic, coin, exp, hp;
            string description;

            try
            {
                level = int.Parse(eventArgs.Attribute("level").Value);
                attack = int.Parse(eventArgs.Attribute("attack").Value);
                defence = int.Parse(eventArgs.Attribute("defence").Value);
                agility = int.Parse(eventArgs.Attribute("agility").Value);
                magic = int.Parse(eventArgs.Attribute("magic").Value);
                coin = int.Parse(eventArgs.Attribute("coin").Value);
                exp = int.Parse(eventArgs.Attribute("exp").Value);
                hp = int.Parse(eventArgs.Attribute("hp").Value);
                description = eventArgs.Attribute("description").Value;
            }
            catch (Exception)
            {
                throw new Exception("读取怪物数据错误");
            }

            return new DealArgs(description, coin, exp, hp, attack, defence, level, agility, magic);
        }

        /// <summary>
        /// 将自身实例保存于xml元素中
        /// </summary>
        /// <param name="xmlRecord">xml元素</param>
        public new void SaveTo(XElement xmlRecord)
        {
            xmlRecord.SetAttributeValue("level", this.Level);
            xmlRecord.SetAttributeValue("magic", this.Magic);
            xmlRecord.SetAttributeValue("agility", this.Agility);
            xmlRecord.SetAttributeValue("attack", this.Attack);
            xmlRecord.SetAttributeValue("defence", this.Defence);
            xmlRecord.SetAttributeValue("hp", this.HpUp);
            xmlRecord.SetAttributeValue("coin", this.CoinDemand);
            xmlRecord.SetAttributeValue("exp", this.ExpDemand);
            xmlRecord.SetAttributeValue("description", this.DealName);
        }

        /// <summary>
        /// 获取或设置交易名称
        /// </summary>
        public string DealName { get; set; }

        /// <summary>
        /// 获取或设置需求的金币数量
        /// </summary>
        public int CoinDemand { get; set; }

        /// <summary>
        /// 获取或设置需求的经验数量
        /// </summary>
        public int ExpDemand { get; set; }

        /// <summary>
        /// 获取或设置交易会获得的生命值
        /// </summary>
        public int HpUp { get; set; }
    }
}






