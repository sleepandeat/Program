using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //摘要:
    //  游戏角色类，拥有背包，可以自主触发事件
    //
    //
    //
    //
    //

    /// <summary>
    /// 英雄类,可以移动并且可以主动战斗
    /// </summary>
    sealed class Hero : Character, IPropUser
    {
        /// <summary>
        /// 创建英雄的新实例
        /// </summary>
        /// <param name="pos">勇士在地图上的坐标</param>
        /// <param name="data">勇士属性</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        private Hero(Coord pos, CharacterArgs data, Size unitSize)
            : base(pos, data, true, unitSize)
        {
            WaitMonsters = 0;

            //增加勇士独有的技能
            skills.Add(new BestAttack(true));
            skills.Add(new Miss(true));
            //skills.Add(new Recover(true));
        }

        /// <summary>
        /// 背包
        /// </summary>
        public Packet Pack;

        /// <summary>
        /// 获取一个布尔值，标示元素是否可以刷新
        /// </summary>
        protected override bool CanRefresh
        {
            get
            {
                if (!(base.CanRefresh && MoveDirection != Direction.No))
                {
                    return false;
                }

                //当存在独显窗口时，人物没有控制权,不可移动
                if (MotaWorld.GetInstance().ExistSolo)
                {
                    StopMove(MoveDirection);
                    return false;
                }

                if (WaitMonsters > 0)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 驱动帧动画
        /// </summary>
        protected override void PlayFace()
        {
            //计数并改变图像
            TimeCount = (TimeCount + 1) % (FrameCount * TotalFrame);
            if (TotalFrame % 4 == 0)
            {
                CurFrame = (TimeCount / FrameCount) % (TotalFrame / 4) + 4 * (int)MoveDirection;
            }

            Move();
        }

        /// <summary>
        /// 获取或设置人物的移动速度
        /// </summary>
        public override int Speed
        {
            get
            {
                return base.Speed;
            }
            set
            {
                base.Speed = value;
                PlayInterval = 450 / value;
            }
        }

        /// <summary>
        /// 使人物停止移动
        /// </summary>
        /// <param name="faceTo">脸面对的方向</param>
        protected override void Stop(Direction faceTo)
        {
            base.CurFrame = (int)faceTo * 4;
            base.TimeCount = 0;
            base.Stop(faceTo);
        }

        /// <summary>
        /// 使人物移动，并调整界面窗口
        /// </summary>
        public override void Move()
        {
            base.Move();

            MotaWorld.GetInstance().MapManager.RefreshView(Location, MoveDirection);
        }

        /// <summary>
        /// 绘制自身到画布
        /// </summary>
        public override void Draw(Graphics canvas)
        {
            if (Exist)
            {
                //有些图像并不是在起始位置开始绘制的，需要动态计算偏移距离
                Point vPoint = new Point(Location.X, Location.Y);

                vPoint.Y += GameIni.ElementHeight - base.CurFace.Height;

                canvas.DrawImage(base.CurFace, vPoint);
            }
        }

        /// <summary>
        /// 处理键盘按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>是否处理成功</returns>
        public bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.Right)
            {
                StartMove(Direction.Right);
            }
            else if (code == System.Windows.Forms.Keys.Up)
            {
                StartMove(Direction.Up);
            }
            else if (code == System.Windows.Forms.Keys.Down)
            {
                StartMove(Direction.Down);
            }
            else if (code == System.Windows.Forms.Keys.Left)
            {
                StartMove(Direction.Left);
            }
            else
            {
                UseProp(code);
            }
            //捕获按键
            return true;
        }

        /// <summary>
        /// 处理按键释放
        /// </summary>
        /// <param name="code">按键</param>
        public void HandleKeyUp(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.Right)
            {
                StopMove(Direction.Right);
            }
            else if (code == System.Windows.Forms.Keys.Up)
            {
                StopMove(Direction.Up);
            }
            else if (code == System.Windows.Forms.Keys.Down)
            {
                StopMove(Direction.Down);
            }
            else if (code == System.Windows.Forms.Keys.Left)
            {
                StopMove(Direction.Left);
            }
        }

        /// <summary>
        /// 获取或设置勇士的朝向
        /// </summary>
        public Direction FaceTo
        {
            get 
            {
                return (Direction)(CurFrame / 4);
            }
            set
            {
                CurFrame = 4 * (int)value;
                TimeCount = 0;
            }
        }

        /// <summary>
        /// 使用道具
        /// </summary>
        /// <param name="keyCode">道具使用按键</param>
        public void UseProp(System.Windows.Forms.Keys keyCode)
        {
            this.Pack.UseProperty(keyCode, this);
        }

        /// <summary>
        /// 获取在战斗窗口中的图像
        /// </summary>
        public override Bitmap Icon
        {
            get
            {
                return MotaImage.GetImage(FaceIndex)[0];
            }
        }

        /// <summary>
        /// 勇士死亡，游戏失败处理
        /// </summary>
        public override void Death()
        {
            base.Death();

            MotaWorld.GetInstance().GameOver = true;
        }

        /// <summary>
        /// 获取或设置等待反应的怪物数量，当存在怪物反应时，人物不可移动
        /// </summary>
        public int WaitMonsters { get; set; }

        /// <summary>
        /// 智能移动到指定的位置
        /// </summary>
        /// <param name="pos">指定的位置</param>
        public override void MoveTo(Coord pos)
        {
            base.MoveTo(pos);

            //显示界面指引指针
            if (AutoPath.ExistPath)
            {
                MotaWorld.GetInstance().MapManager.ShowGuide(AutoPath.EndTargetPos);
            }
        }

        /// <summary>
        /// 停止智能移动
        /// </summary>
        protected override void StopAutoMove()
        {
            base.StopAutoMove();

            //终止界面层的指引指针的显示
            MotaWorld.GetInstance().MapManager.StopGuide();
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Hero; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static Hero Create(XElement createArgs)
        {
            CharacterArgs data = CharacterArgs.CreateFrom(createArgs);

            int row, col;
            try
            {
                row = int.Parse(createArgs.Attribute("row").Value);
                col = int.Parse(createArgs.Attribute("col").Value);
            }
            catch (Exception)
            {
                throw new Exception("错误的位置");
            }
            Coord showPosation = new Coord(col, row);

            string fileName = data.FaceFile;
            Size unitSize = GetSize(createArgs.Attribute("unitSize").Value);

            Hero player = new Hero(showPosation, data, unitSize);

            //获取背包数据
            player.Pack = Packet.Create(createArgs.Element("packet"));

            //加载技能信息
            if (createArgs.Element("skill") != null)
            {
                XElement faceXml = createArgs.Element("skill").Element("skillImages");
                string[] images = Weapon.GetSkillImages(faceXml);
                player.SetSkillFlash(images[0], images[1], images[2]);
            }

            return player;
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("row", this.Station.Row);
            eventType.SetAttributeValue("col", this.Station.Col);

            //添加背包数据
            eventType.Add(this.Pack.XmlRecord);

            eventType.SetAttributeValue("curAttack", this.Attack);
            eventType.SetAttributeValue("curDefence", this.Defence);
            eventType.SetAttributeValue("curAgility", this.Agility);
            eventType.SetAttributeValue("curMagic", this.Magic);
            eventType.SetAttributeValue("curCoin", this.Coin);
            eventType.SetAttributeValue("curExp", this.Exp);
            eventType.SetAttributeValue("curLevel", this.Level);

            base.SaveTypeTo(eventType);
        }

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public override XElement XmlRecord
        {
            get
            {
                XElement xmlRecord = new XElement("hero");
                xmlRecord.SetAttributeValue("unitSize", this.CurFace.Size.ToXmlString());
                SaveTypeTo(xmlRecord);

                XElement skillXml = new XElement("skill");
                XElement skillImages = new XElement("skillImages");
                skillImages.SetAttributeValue("commonAttack", MotaImage.GetFileName(CommonSkill.FaceIndex));
                skillImages.SetAttributeValue("goodAttack", MotaImage.GetFileName(GoodSkill.FaceIndex));
                skillImages.SetAttributeValue("bestAttack", MotaImage.GetFileName(BestSkill.FaceIndex));
                skillXml.Add(skillImages);
                xmlRecord.Add(skillXml);

                return xmlRecord;
            }
        }

        private CommonAttack CommonSkill
        {
            get {
                foreach (var item in skills)
                {
                    if (item is CommonAttack)
                    {
                        return item as CommonAttack;
                    }
                }
                return null;
            }
        }

        private GoodAttack GoodSkill
        {
            get
            {
                foreach (var item in skills)
                {
                    if (item is GoodAttack)
                    {
                        return item as GoodAttack;
                    }
                }
                return null;
            }
        }

        private BestAttack BestSkill
        {
            get
            {
                foreach (var item in skills)
                {
                    if (item is BestAttack)
                    {
                        return item as BestAttack;
                    }
                }
                return null;
            }
        }

    }
}








