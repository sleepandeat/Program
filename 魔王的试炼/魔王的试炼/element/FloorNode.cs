using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;
using System.Xml;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔楼层类，用于记录和管理楼层信息
    /// </summary>
    class FloorNode
    {
        /// <summary>
        /// 创建一个全空的楼层节点
        /// </summary>
        /// <param name="index">楼层索引</param>
        /// <param name="name">楼层名称</param>
        /// <param name="maxCoord">楼层的坐标范围</param>
        /// <param name="nextFloor">下一层楼的索引，用于指向默认的下一层楼</param>
        /// <param name="preFloor">上一层楼的索引，用于指向默认的上一层楼</param>
        /// <param name="heroExistPos">人物初始出现的位置</param>
        /// <param name="downPos">下楼时出现的位置</param>
        /// <param name="autoSwicth">自动开关事件列表</param>
        private FloorNode(int index, string name, Coord maxCoord, int nextFloor, int preFloor, Coord heroExistPos, Coord downPos, List<Swicther> autoSwicth)
        {
            FloorIndex = index;
            FloorName = name;
            floorSize = maxCoord;
            BackMap = new Background[maxCoord.Row, maxCoord.Col];
            EventMap = new MapEvent[maxCoord.Row, maxCoord.Col];
            NextFloor = nextFloor;
            PreFloor = preFloor;
            HeroUpPos = heroExistPos;
            HeroDownPos = downPos;

            this.AutoSwicth = autoSwicth;
        }

        /// <summary>
        /// 获取或设置英雄上楼时出现在地图上的坐标
        /// </summary>
        public Coord HeroUpPos { get; set; }

        /// <summary>
        /// 获取或设置英雄下楼时出现在地图上的坐标
        /// </summary>
        public Coord HeroDownPos { get; set; }

        /// <summary>
        /// 获取或设置楼层的索引
        /// </summary>
        public int FloorIndex { get; set; }

        /// <summary>
        /// 获取或设置楼层名称
        /// </summary>
        public string FloorName { get; set; }

        /// <summary>
        /// 获取或设置楼层背景层
        /// </summary>
        public Background[,] BackMap { get; set; }

        /// <summary>
        /// 获取或设置楼层事件层
        /// </summary>
        public MapEvent[,] EventMap { get; set; }

        /// <summary>
        /// 自动开关事件
        /// </summary>
        private List<Swicther> AutoSwicth;

        /// <summary>
        /// 获取或设置下一层楼的id
        /// </summary>
        public int NextFloor { get; set; }

        /// <summary>
        /// 获取或设置上一层楼的id
        /// </summary>
        public int PreFloor { get; set; }

        private Coord floorSize;
        /// <summary>
        /// 获取楼层的大小，以坐标范围表示
        /// </summary>
        public Coord FloorSize
        {
            get
            {
                return floorSize;
            }
        }

        /// <summary>
        /// 检查点坐标是否在当前楼层中
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <returns>如果坐标超出楼层的范围，返回false</returns>
        public bool InFloor(Coord pos)
        {
            if (pos.Col < 0 || pos.Col >= FloorSize.Col || pos.Row < 0 || pos.Row >= FloorSize.Row)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 刷新本层楼的游戏元素
        /// </summary>
        public void Refresh()
        {
            for (int row = 0; row < FloorSize.Row; row++)
            {
                for (int col = 0; col < FloorSize.Col; col++)
                {
                    BackMap[row, col].Play();
                    if (EventMap[row, col] != null)
                    {
                        EventMap[row, col].Play();
                    }
                }
            }

            for (int i = 0; i < this.AutoSwicth.Count; i++)
            {
                this.AutoSwicth[i].Check();
                if (!this.AutoSwicth[i].Enable)
                {
                    this.AutoSwicth.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// 绘制楼层中某个坐标上的元素到画布
        /// </summary>
        /// <param name="canvas">画布</param>
        /// <param name="elementPos">元素坐标</param>
        public void Draw(Graphics canvas, Coord elementPos)
        {
            if (InFloor(elementPos))
            {
                BackMap[elementPos.Row, elementPos.Col].Draw(canvas);
                if (EventMap[elementPos.Row, elementPos.Col] != null)
                {
                    EventMap[elementPos.Row, elementPos.Col].Draw(canvas);
                }
            }
        }

        /// <summary>
        /// 判断当前楼层中的某个位置对于某个方向是否是可通行的
        /// </summary>
        /// <param name="pos">楼层中的位置</param>
        /// <param name="moveDirection">方向</param>
        /// <returns>如果不可通行，返回false</returns>
        public bool IsPassable(Coord pos, Direction moveDirection)
        {
            //判断点是否在楼层中
            if (!InFloor(pos))
            {
                return false;
            }

            //判断背景层是否可以通行
            if (BackMap[pos.Row, pos.Col].Exist && !BackMap[pos.Row, pos.Col].Passable(moveDirection))
            {
                return false;
            }

            //判断事件层是否可以通行
            if (EventMap[pos.Row, pos.Col] != null && EventMap[pos.Row, pos.Col].Exist && !EventMap[pos.Row, pos.Col].Passable(moveDirection))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断当前楼层中的某个位置是否是空的(可通行并且不存在事件)
        /// </summary>
        /// <param name="pos">楼层中的位置</param>
        /// <param name="moveDirection">方向</param>
        /// <returns>如果不为空，返回false</returns>
        public bool IsEmpty(Coord pos, Direction moveDirection)
        {
            if (!IsPassable(pos, moveDirection))
            {
                return false;
            }

            //判断事件层是否为空
            if (EventMap[pos.Row, pos.Col] != null && EventMap[pos.Row, pos.Col].Exist)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 移动事件元素到新的位置，如果移动成功返回true
        /// </summary>
        /// <param name="souPos">源坐标</param>
        /// <param name="desPos">目标坐标</param>
        /// <param name="moveDirection">目标的移动方向，用于检测目标位置是否可通行</param>
        public bool ShiftEvent(Coord souPos, Coord desPos, Direction moveDirection)
        {
            //如果目标坐标存在事件，则不能移动
            if (!IsEmpty(desPos, moveDirection))
            {
                return false;
            }

            EventMap[desPos.Row, desPos.Col] = EventMap[souPos.Row, souPos.Col];
            DeleteEvent(souPos);
            return true;
        }

        /// <summary>
        /// 删除地表元素，地表设为默认
        /// </summary>
        /// <param name="souPos">目标元素的坐标</param>
        private void DeleteBackground(Coord souPos)
        {
            if (InFloor(souPos))
            {
                this.BackMap[souPos.Row, souPos.Col] = Background.GetEmpty(souPos);
            }
        }

        /// <summary>
        /// 删除目标元素，事件设为空
        /// </summary>
        /// <param name="souPos">目标元素的坐标</param>
        private void DeleteEvent(Coord souPos)
        {
            if (InFloor(souPos))
            {
                this.EventMap[souPos.Row, souPos.Col] = null;
            }
        }

        /// <summary>
        /// 删除目标元素，事件设为空，地表设为默认
        /// </summary>
        /// <param name="souPos">目标元素的坐标</param>
        public void Delete(Coord souPos)
        {
            DeleteBackground(souPos);
            DeleteEvent(souPos);
        }

        /// <summary>
        /// 触发坐标处的事件
        /// </summary>
        /// <param name="pos">在地图上的坐标</param>
        /// <param name="triggerMethod">触发方式</param>
        /// <param name="player">触发者</param>
        public void TriggerEvent(Coord pos, TouchMethod triggerMethod, Hero player)
        {
            if (!InFloor(pos))
            {
                return;
            }

            if (EventMap[pos.Row, pos.Col] == null || EventMap[pos.Row, pos.Col].Exist == false)
            {
                return;
            }

            //如果触发方式符合，则触发事件
            if (EventMap[pos.Row, pos.Col].TriggerMethod == triggerMethod)
            {
                EventMap[pos.Row, pos.Col].TriggerEvent(player);
            }
        }

        /// <summary>
        /// 如果墙可以被破坏的话，破坏一堵墙
        /// </summary>
        /// <param name="pos">墙的位置</param>
        /// <returns>返回一个布尔值，标示是否破坏成功，如果墙不可以破坏，则返回false</returns>
        public bool Destroy(Coord pos)
        {
            if (InFloor(pos) && BackMap[pos.Row, pos.Col].CanDestroy)
            {
                BackMap[pos.Row, pos.Col].Close();
                SoundsList.PlaySound(SoundType.破墙);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取或设置当前获取焦点的事件的坐标
        /// </summary>
        private static Coord CurFocus { get; set; }

        /// <summary>
        /// 给事件设置焦点
        /// </summary>
        /// <param name="windowPos">焦点出现在地图中的坐标</param>
        public void SetEventFoucs(Coord pos)
        {
            //取消之前的焦点
            if (EventMap[CurFocus.Row, CurFocus.Col] != null)
            {
                EventMap[CurFocus.Row, CurFocus.Col].Focused = false;
            }

            if (!InFloor(pos))
            {
                return;
            }

            if (EventMap[pos.Row, pos.Col] != null && EventMap[pos.Row, pos.Col].Exist && EventMap[pos.Row, pos.Col].CurFace != null)
            {
                EventMap[pos.Row, pos.Col].Focused = true;

                //记录焦点坐标
                CurFocus = pos;
            }
        }

        /// <summary>
        /// 获取当前楼层中两点之间的路径(用坐标队列表示)
        /// </summary>
        /// <param name="startPos">起点坐标</param>
        /// <param name="endPos">终点坐标</param>
        /// <returns>返回从起点到终点的移动方向的队列，如果没有通行的路线，返回null</returns>
        public Queue<Coord> GetPath(Coord startPos, Coord endPos)
        {
            //委托路径计算类完成计算
            return new PathCaculator(this, startPos, endPos).Compute();
        }

        /// <summary>
        /// 判断当前楼层中某个位置存放存在怪物
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <returns>获取一个布尔值，标示是否存在怪物，如果存在，返回true</returns>
        public bool IsMonster(Coord pos)
        {
            if (!InFloor(pos))
            {
                return false;
            }

            if (EventMap[pos.Row, pos.Col] != null && EventMap[pos.Row, pos.Col].Exist && EventMap[pos.Row, pos.Col] is Monster)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 根据一层楼的XML数据创建楼层元素
        /// </summary>
        /// <param name="oneFloorArgs">楼层数据</param>
        /// <returns>返回一个拥有数据的楼层对象</returns>
        public static FloorNode Create(XElement oneFloorArgs)
        {
            int index;      //楼层索引
            string name;    //楼层名称
            int rowNum;     //行数
            int colNum;     //列数
            int preFloor;   //前驱楼层
            int nextFloor;  //后继楼层
            int upRow;      //上楼后的初始行
            int upCol;      //上楼后的初始列
            int downRow;    //下楼后的初始行
            int downCol;    //下楼后的初始列

            try
            {
                index = int.Parse(oneFloorArgs.Element("index").Value);
                rowNum = int.Parse(oneFloorArgs.Element("rowNum").Value);
                colNum = int.Parse(oneFloorArgs.Element("colNum").Value);
                preFloor = int.Parse(oneFloorArgs.Element("preFloor").Value);
                nextFloor = int.Parse(oneFloorArgs.Element("nextFloor").Value);
                upRow = int.Parse(oneFloorArgs.Element("heroRow").Value);
                upCol = int.Parse(oneFloorArgs.Element("heroCol").Value);
                downRow = int.Parse(oneFloorArgs.Element("downRow").Value);
                downCol = int.Parse(oneFloorArgs.Element("downCol").Value);
                name = oneFloorArgs.Element("name").Value;
            }
            catch (Exception)
            {
                throw new Exception("错误的楼层数据");
            }

            List<Swicther> autoSwitchs = new List<Swicther>();
            autoSwitchs.Clear();

            if (oneFloorArgs.Element("switchers") != null)
            {
                XElement switchers = oneFloorArgs.Element("switchers");
                foreach (var item in switchers.Elements("switcher"))
                {
                    autoSwitchs.Add(Swicther.CreateFromXml(item));
                }
            }
            
            FloorNode oneFloor = new FloorNode(index, name, new Coord(colNum, rowNum), nextFloor, preFloor, new Coord(upCol, upRow), new Coord(downCol, downRow), autoSwitchs);

            //加载地图层
            LoadBackLayer(oneFloorArgs, oneFloor);

            //加载事件层
            LoadEventLayer(oneFloorArgs, oneFloor);

            return oneFloor;
        }

        /// <summary>
        /// 加载事件层
        /// </summary>
        /// <param name="oneFloorArgs">事件层参数</param>
        /// <param name="oneFloor">待加载的楼层对象</param>
        private static void LoadEventLayer(XElement oneFloorArgs, FloorNode oneFloor)
        {
            XElement floorEventArgs = oneFloorArgs.Element("eventLayer");
            for (int row = 0; row < oneFloor.FloorSize.Row; row++)
            {
                //这里引入中间变量，为了提高查询速度
                XElement rowEventArgs = floorEventArgs.Elements("oneRow").ElementAt(row);
                for (int col = 0; col < oneFloor.FloorSize.Col; col++)
                {
                    try
                    {
                        oneFloor.EventMap[row, col] = MapEvent.CreateInstance(
                            rowEventArgs.Elements("oneEvent").ElementAt(col), new Coord(col, row));
                    }
                    catch (Exception)
                    {
                        oneFloor.EventMap[row, col] = null;
                    }
                }
            }
        }

        /// <summary>
        /// 加载地图层
        /// </summary>
        /// <param name="oneFloorArgs">地图层参数</param>
        /// <param name="oneFloor">待加载的楼层对象</param>
        private static void LoadBackLayer(XElement oneFloorArgs, FloorNode oneFloor)
        {
            XElement floorBackArgs = oneFloorArgs.Element("backLayer");
            for (int row = 0; row < oneFloor.FloorSize.Row; row++)
            {
                //这里引入中间变量，为了提高查询速度
                XElement rowBackArgs = floorBackArgs.Elements("oneRow").ElementAt(row);
                for (int col = 0; col < oneFloor.FloorSize.Col; col++)
                {
                    Coord pos = new Coord(col, row);
                    try
                    {
                        oneFloor.BackMap[row, col] = Background.CreateInstance(
                            rowBackArgs.Elements("oneBack").ElementAt(col), pos);
                    }
                    catch (Exception)
                    {
                        throw new Exception("地图层不可为空， 缺少位置: " + pos.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public XElement XmlRecord
        {
            get
            {
                XElement xmlRecord = new XElement("oneFloor");

                xmlRecord.SetAttributeValue("reached", MotaWorld.GetInstance().MapManager.FloorReached[this.FloorIndex].ToString());
                xmlRecord.Add(new XElement("index", this.FloorIndex));
                xmlRecord.Add(new XElement("rowNum", this.FloorSize.Row));
                xmlRecord.Add(new XElement("colNum", this.FloorSize.Col));
                xmlRecord.Add(new XElement("preFloor", this.PreFloor));
                xmlRecord.Add(new XElement("nextFloor", this.NextFloor));
                xmlRecord.Add(new XElement("heroRow", this.HeroUpPos.Row));
                xmlRecord.Add(new XElement("heroCol", this.HeroUpPos.Col));
                xmlRecord.Add(new XElement("downRow", this.HeroDownPos.Row));
                xmlRecord.Add(new XElement("downCol", this.HeroDownPos.Col));
                xmlRecord.Add(new XElement("name", this.FloorName));

                //添加地图层
                SaveMapTo(xmlRecord);

                //条件楼层事件
                XElement switchers = new XElement("switchers");
                foreach (var item in this.AutoSwicth)
                {
                    switchers.Add(item.XmlRecord);
                }
                xmlRecord.Add(switchers);

                return xmlRecord;
            }
        }

        private void SaveMapTo(XElement xmlRecord)
        {
            XElement backLayar = new XElement("backLayer");
            XElement eventLayar = new XElement("eventLayer");
            for (int row = 0; row < this.FloorSize.Row; row++)
            {
                XElement backRow = new XElement("oneRow");
                XElement eventRow = new XElement("oneRow");

                for (int col = 0; col < this.FloorSize.Col; col++)
                {
                    backRow.Add(this.BackMap[row, col].XmlRecord);

                    if (this.EventMap[row, col] == null)
                    {
                        eventRow.Add(MapEvent.EmptyXml);
                    }
                    else
                    {
                        eventRow.Add(this.EventMap[row, col].XmlRecord);
                    }
                }

                backLayar.Add(backRow);
                eventLayar.Add(eventRow);
            }
            xmlRecord.Add(backLayar);
            xmlRecord.Add(eventLayar);
        }

        /// <summary>
        /// 拷贝源节点到新节点(深度复制)
        /// </summary>
        /// <param name="node">源节点元素</param>
        /// <param name="desNode">新节点元素坐标</param>
        public void CopyNode(ElementNode node, Coord desNode)
        {
            if (!InFloor(desNode))
            {
                return;
            }

            //复制地表层
            BackMap[desNode.Row, desNode.Col] = node.GetBack(desNode);
            
            //复制事件层
            EventMap[desNode.Row, desNode.Col] = node.GetEvent(desNode);
        }

        /// <summary>
        /// 根据结点坐标获取结点元素
        /// </summary>
        /// <param name="desPos">结点坐标</param>
        /// <returns>结点元素</returns>
        public ElementNode GetNode(Coord desPos)
        {
            if (!InFloor(desPos))
            {
                return null;
            }

            return new ElementNode(BackMap[desPos.Row, desPos.Col], EventMap[desPos.Row, desPos.Col]);
        }

        /// <summary>
        /// 根据Xml元素重新加载结点
        /// </summary>
        /// <param name="desPos">结点坐标</param>
        /// <param name="xmlStr">xml字符串</param>
        public void LoadNode(Coord desPos, string xmlStr)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlStr);
            XElement xmlNode = xmlDocument.ToXDocument().Root;

            ElementNode node = ElementNode.GetNode(xmlNode);

            CopyNode(node, desPos);
        }

        /// <summary>
        /// 获取结点字符串描述（xml格式）
        /// </summary>
        /// <param name="desPos">目标坐标</param>
        /// <returns>xml字符串</returns>
        public string GetNodeString(Coord desPos)
        {
            return GetNode(desPos).WriteToXml().ToString();
        }
    }
}




















