using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace 魔王的试炼
{
    /// <summary>
    /// 怪物数据类静态类
    /// </summary>
    static class MonsterData
    {
        /// <summary>
        /// 加载怪物数据
        /// </summary>
        /// <param name="sourceFile">数据文件</param>
        public static void LoadMonsterData(string dataFile)
        {
            XDocument monsterData = XDocument.Load(dataFile);

            XElement root = monsterData.Root;
            IEnumerable<XElement> monsters = root.Elements();

            //根据怪物数量创建数据数组
            Data = new CharacterArgs[monsters.Count()];

            for (int i = 0; i < monsters.Count(); i++)
            {
                XElement mon = monsters.ElementAt(i);
                CharacterArgs oneData;
                try
                {
                    oneData = new CharacterArgs(
                    int.Parse(mon.Element("id").Value),
                    mon.Element("faceFile").Value,
                    mon.Element("name").Value,
                    int.Parse(mon.Element("level").Value),
                    int.Parse(mon.Element("hp").Value),
                    int.Parse(mon.Element("attack").Value),
                    int.Parse(mon.Element("defence").Value),
                    int.Parse(mon.Element("agility").Value),
                    int.Parse(mon.Element("magic").Value),
                    int.Parse(mon.Element("coin").Value),
                    int.Parse(mon.Element("exp").Value),
                    mon.Element("describe").Value
                    );
                }
                catch (Exception)
                {
                    throw new Exception("读取怪物数据错误");
                }
                Data[i] = oneData;
            }
        }

        /// <summary>
        /// 怪物数据数组
        /// </summary>
        static private CharacterArgs[] Data;

        /// <summary>
        /// 返回怪物的数量
        /// </summary>
        public static int MonsterCount
        {
            get { return Data.Length; }
        }

        /// <summary>
        /// 根据怪物id获取怪物参数
        /// </summary>
        /// <param name="monsterId">怪物id</param>
        /// <returns>相应的怪物数据</returns>
        public static CharacterArgs IndexOf(int monsterId)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i].MonsterId == monsterId)
                {
                    return Data[i];
                }
            }

            throw new Exception("未找到相应的怪物数据");
        }

        /// <summary>
        /// 根据怪物名称获取怪物参数
        /// </summary>
        /// <param name="monsterName">怪物名称</param>
        /// <returns>相应的怪物数据</returns>
        public static CharacterArgs IndexOf(string monsterName)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i].Name.CompareTo(monsterName) == 0)
                {
                    return Data[i];
                }
            }

            throw new Exception("未找到相应的怪物数据");   
        }
    }
}









