using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //摘要:
    //  此类不管理存档信息和窗口界面，只提供存档和读档的功能
    //
    //
    //

    /// <summary>
    /// 存档记录者，用于存档和读档
    /// </summary>
    class Recorder
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private Recorder() { }

        private static Recorder recorder = null;

        /// <summary>
        /// 获取当前的游戏场景
        /// </summary>
        private MainGame CurGame
        {
            get
            {
                return MotaWorld.GetInstance().MapManager;
            }
        }

        /// <summary>
        /// 获取唯一实例
        /// </summary>
        /// <returns></returns>
        public static Recorder GetInstence()
        {
            if (recorder == null)
            {
                recorder = new Recorder();
            }
            return recorder;
        }

        /// <summary>
        /// 读档
        /// </summary>
        /// <param name="recordFile">记录文件(XML)</param>
        public void Load(string recordFile)
        { 
            /*
             * 1. 加载魔塔地图和当前楼层
             * 
             * 2. 加载人物
             * 
             * 3. 加载抵达楼层信息
             * 
             * 4. 道具包
             * 
             */
            XDocument recordDocument = XDocument.Load(recordFile);
            XElement record = recordDocument.Root;

            XElement mapArgs = record.Element("map");
            XElement heroArgs = record.Element("hero");

            //加载当前楼层
            int curFloor = LoadCurFloor(mapArgs);

            //加载地图
            bool[] reached = LoadMap(mapArgs);

            //加载人物
            Hero player = Hero.Create(heroArgs);

            //关闭无关窗口
            MotaWorld.GetInstance().CloseWindow();

            CurGame.Initialize(curFloor, player, reached);

        }

        /// <summary>
        /// 加载当前楼层索引
        /// </summary>ck
        /// <param name="mapArgs">地图数据</param>
        /// <returns>返回一个整数，表示当前的楼层索引</returns>
        private static int LoadCurFloor(XElement mapArgs)
        {
            int curFloor = 0;

            if (mapArgs.Attribute("curFloor") != null)
            {
                curFloor = int.Parse(mapArgs.Attribute("curFloor").Value);
            }
            return curFloor;
        }

        /// <summary>
        /// 加载地图
        /// </summary>
        /// <param name="mapArgs">地图数据</param>
        /// <returns>返回一个布尔数组，记录抵达过的楼层</returns>
        private bool[] LoadMap(XElement mapArgs)
        {
            IEnumerable<XElement> floors = mapArgs.Elements("oneFloor");
            int count = floors.Count();

            bool[] reached = new bool[count];
            CurGame.Tower.Clear();

            foreach (var floor in floors)
            {
                FloorNode newFloor = FloorNode.Create(floor);
                CurGame.Tower.AddFloor(newFloor);

                //记录已经抵达过的楼层
                if (floor.Attribute("reached") != null)
                {
                    reached[newFloor.FloorIndex] = true;
                }
            }

            return reached;
        }

        /// <summary>
        /// 保存当前存档到目标文件
        /// </summary>
        /// <param name="saveFile">目标文件</param>
        public void Save(string saveFile)
        {
            XmlRecord.Save(saveFile);

            SoundsList.PlaySound(SoundType.保存);
        }

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public XDocument XmlRecord
        {
            get
            {
                XDocument xmlRecord = new XDocument();

                XElement root = new XElement("record");
                root.Add(XmlMap);
                root.Add(CurGame.CurHero.XmlRecord);
                xmlRecord.Add(root);

                return xmlRecord;
            }
        }

        /// <summary>
        /// 获取XML格式的地图数据
        /// </summary>
        private XElement XmlMap
        {
            get
            {
                XElement map = new XElement("map");
                map.SetAttributeValue("curFloor", CurGame.CurFloorIndex);
                for (int i = 0; i < CurGame.Tower.MaxFloor; i++)
                {
                    map.Add(CurGame.Tower[i].XmlRecord);
                }
                return map;
            }
        }

    }
}














