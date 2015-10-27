using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 武器类，获取后提升属性
    /// 获取后有可能修改技能动画
    /// </summary>
    class Weapon : Equip
    {
        /// <summary>
        /// 武器的实例
        /// </summary>
        /// <param name="faceFile">武器图像地址</param>
        /// <param name="pos">武器位置</param>
        /// <param name="name">武器名称</param>
        /// <param name="description">武器的描述</param>
        /// <param name="data">武器提升的属性参数</param>
        /// <param name="skillFaceFiles">技能效果图，如果为空，则获得武器后不更新技能效果</param>
        private Weapon(string faceFile, Coord pos, string name, string description, AbilityArgs data, string[] skillFaceFiles = null)
            : base(faceFile, pos, name, description, data)
        {
            if (skillFaceFiles == null || skillFaceFiles.Length != 3)
            {
                CommonAttackFaceFile = string.Empty;
                GoodAttackFaceFile = string.Empty;
                BestAttackFaceFile = string.Empty;
            }
            else
            {
                CommonAttackFaceFile = skillFaceFiles[0];
                GoodAttackFaceFile = skillFaceFiles[1];
                BestAttackFaceFile = skillFaceFiles[2];
            }
        }

        /// <summary>
        /// 普通攻击技能图像
        /// </summary>
        private string CommonAttackFaceFile;

        /// <summary>
        /// 暴击技能图像
        /// </summary>
        private string GoodAttackFaceFile;

        /// <summary>
        /// 愤怒一击技能图像
        /// </summary>
        private string BestAttackFaceFile;

        /// <summary>
        /// 与武器接触触发获取事件，如果等级不够则无法获取
        /// </summary>
        /// <param name="player">事件触发者</param>
        public override void TriggerEvent(Hero player)
        {
            if (Enable && player.Level >= this.LevelDemand)
            { 
                //获取之后更新技能动画
                player.SetSkillFlash(CommonAttackFaceFile, GoodAttackFaceFile, BestAttackFaceFile);
            }

            base.TriggerEvent(player);
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Weapon; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public new static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            string fileName = createArgs.Attribute("imagefile").Value;
            string name = createArgs.Attribute("eventName").Value;
            string description = createArgs.Attribute("description").Value;

            string[] skillImages = GetSkillImages(createArgs);

            return new Weapon(fileName, existCoord, name, description, AbilityArgs.CreateFrom(createArgs), skillImages);
        }

        public static string[] GetSkillImages(XElement createArgs)
        {
            string[] skillImages = new string[3];
            skillImages[0] = createArgs.Attribute("commonAttack").Value;
            skillImages[1] = createArgs.Attribute("goodAttack").Value;
            skillImages[2] = createArgs.Attribute("bestAttack").Value;
            return skillImages;
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            base.SaveTypeTo(eventType);

            SetSkillImagesToXml(eventType);
        }

        private void SetSkillImagesToXml(XElement eventType)
        {
            eventType.SetAttributeValue("commonAttack", this.CommonAttackFaceFile);
            eventType.SetAttributeValue("goodAttack", this.GoodAttackFaceFile);
            eventType.SetAttributeValue("bestAttack", this.BestAttackFaceFile);
        }
    }
}



