using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 人物属性参数类,用于创建勇士和怪物实例.
    /// </summary>
    class CharacterArgs : AbilityArgs
    {
        /// <summary>
        /// 创建属性参数实例
        /// </summary>
        /// <param name="id">怪物id</param>
        /// <param name="faceFile">怪物的图像文件名</param>
        /// <param name="name">名称</param>
        /// <param name="level">等级</param>
        /// <param name="hp">生命力</param>
        /// <param name="attack">攻击力</param>
        /// <param name="defence">防御力</param>
        /// <param name="agility">敏捷</param>
        /// <param name="magic">魔法</param>
        /// <param name="coin">金币</param>
        /// <param name="exp">经验</param>
        /// <param name="desc">简介</param>
        public CharacterArgs(int id, string faceFile, string name, int level, int hp, int attack, int defence, int agility, int magic, int coin, int exp, string desc)
            : base(level, attack, defence, agility, magic)
        {
            this.MonsterId = id;
            this.FaceFile = faceFile;
            this.Name = name;
            this.Hp = hp;
            this.Coin = coin;
            this.Exp = exp;
            this.Description = desc;
        }

        /// <summary>
        /// 怪物id
        /// </summary>
        public int MonsterId;

        /// <summary>
        /// 图像文件名
        /// </summary>
        public string FaceFile;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 生命值
        /// </summary>
        public int Hp;

        /// <summary>
        /// 金币
        /// </summary>
        public int Coin;

        /// <summary>
        /// 经验
        /// </summary>
        public int Exp;

        /// <summary>
        /// 人物简介
        /// </summary>
        public string Description;

        /// <summary>
        /// 获取参数对象的副本
        /// </summary>
        public CharacterArgs Copy
        {
            get
            {
                return new CharacterArgs(this.MonsterId, this.FaceFile, this.Name, this.Level,
                    this.Hp, this.Attack, this.Defence, this.Agility, this.Magic, this.Coin,
                    this.Exp, this.Description);
            }
        }

        /// <summary>
        /// 根据事件参数获取属性配置
        /// </summary>
        /// <param name="eventArgs">事件参数</param>
        /// <returns>属性配置</returns>
        public new static CharacterArgs CreateFrom(XElement eventArgs)
        {
            CharacterArgs data;
            int monsterId;
            try
            {
                monsterId = int.Parse(eventArgs.Attribute("id").Value);
            }
            catch (Exception)
            {
                throw new Exception("怪物属性读取错误");
            }

            //从怪物数据容器中获取参数
            data = MonsterData.IndexOf(monsterId).Copy;

            if (eventArgs.Attribute("curHp") != null)
            {
                int curHp = int.Parse(eventArgs.Attribute("curHp").Value);
                data.Hp = curHp;
            }

            if (eventArgs.Attribute("curAttack") != null)
            {
                int curAttack = int.Parse(eventArgs.Attribute("curAttack").Value);
                data.Attack = curAttack;
            }

            if (eventArgs.Attribute("curDefence") != null)
            {
                int curDefence = int.Parse(eventArgs.Attribute("curDefence").Value);
                data.Defence = curDefence;
            }

            if (eventArgs.Attribute("curAgility") != null)
            {
                int curAgility = int.Parse(eventArgs.Attribute("curAgility").Value);
                data.Agility = curAgility;
            }

            if (eventArgs.Attribute("curMagic") != null)
            {
                int curMagic = int.Parse(eventArgs.Attribute("curMagic").Value);
                data.Magic = curMagic;
            }

            if (eventArgs.Attribute("curCoin") != null)
            {
                int curCoin = int.Parse(eventArgs.Attribute("curCoin").Value);
                data.Coin = curCoin;
            }

            if (eventArgs.Attribute("curExp") != null)
            {
                int curExp = int.Parse(eventArgs.Attribute("curExp").Value);
                data.Exp = curExp;
            }

            if (eventArgs.Attribute("curLevel") != null)
            {
                int curLevel = int.Parse(eventArgs.Attribute("curLevel").Value);
                data.Level = curLevel;
            }

            return data;
        }
    }
}

