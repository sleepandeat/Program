using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 装备类，获取后提升属性
    /// 需要符合等级的条件才能获取
    /// </summary>
    class Equip : MapEvent
    {
        /// <summary>
        /// 装备的实例
        /// </summary>
        /// <param name="faceFile">装备图像地址</param>
        /// <param name="p">装备位置</param>
        /// <param name="name">装备名称</param>
        /// <param name="description">装备的描述</param>
        /// <param name="data">装备提升的属性参数</param>
        protected Equip(string faceFile, Coord p, string name, string description, AbilityArgs data)
            : base(faceFile, p, TouchMethod.StationTouch, true, name, GameIni.UnitSize)
        {
            this.Name = name;
            this.Description = description;
            this.GetAbility = data;
            this.LevelDemand = data.Level;
        }

        /// <summary>
        /// 获取后人物会获得的能力
        /// </summary>
        private AbilityArgs GetAbility;

        /// <summary>
        /// 装备需求的等级，如果人物未到达需求的等级，无法获取
        /// </summary>
        protected int LevelDemand;

        /// <summary>
        /// 装备的名称
        /// </summary>
        private string Name;

        /// <summary>
        /// 装备的描述信息
        /// </summary>
        private string Description;

        /// <summary>
        /// 与装备接触的装备获取事件.
        /// </summary>
        /// <param name="player">调用者</param>
        public override void TriggerEvent(Hero player)
        {
            //如果人物等级高于需求的等级，获取装备
            if (Enable && player.Level >= this.LevelDemand)
            {
                player.Attack += this.GetAbility.Attack;
                player.Defence += this.GetAbility.Defence;
                player.Agility += this.GetAbility.Agility;
                player.Magic += this.GetAbility.Magic;

                MotaWorld.GetInstance().MessageShowWindow.Open(Description);
                SoundsList.PlaySound(SoundType.升级);

                this.Exist = false;
            }
            else
	        {
                MotaWorld.GetInstance().MessageShowWindow.Open("获取此装备需要达到" + this.LevelDemand + "级，\r\n您的等级不足够获取此装备！");
                SoundsList.PlaySound(SoundType.错误);   
	        }

            base.TriggerEvent(player);
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Equip; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            string fileName = createArgs.Attribute("imagefile").Value;
            string name = createArgs.Attribute("eventName").Value;
            string description = createArgs.Attribute("description").Value;

            return new Equip(fileName, existCoord, name, description, AbilityArgs.CreateFrom(createArgs));
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("imagefile", MotaImage.GetFileName(this.FaceIndex));
            eventType.SetAttributeValue("description", this.Description);
            this.GetAbility.SaveTo(eventType);
        }
    }
}





