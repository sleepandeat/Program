using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    //摘要:
    //  这是游戏人物类，用于提供勇士和怪物的公有数据和方法
    //
    //设计思路:
    //  与属性直接相关，有能力做一定的逻辑计算
    //
    //特征:
    //  拥有属性、技能、战斗等字段和方法
    //

    /// <summary>
    /// 游戏人物类，派生出怪物和勇士
    /// </summary>
    abstract class Character : MoveElement, Idealer, IFighter
    {
        /// <summary>
        /// 创建人物的新实例
        /// </summary>
        /// <param name="pos">人物在地图上的坐标</param>
        /// <param name="data">人物属性</param>
        /// <param name="isHero">是否是勇士</param>
        /// <param name="unitSize">图像分割的单位尺寸</param>
        protected Character(Coord pos, CharacterArgs data, bool isHero, Size unitSize)
            : base(data.FaceFile, pos, data.Name, unitSize)
        {
            this.Name = data.Name;
            this.Level = data.Level;
            this.Hp = data.Hp;
            this.Attack = data.Attack;
            this.Defence = data.Defence;
            this.Agility = data.Agility;
            this.Magic = data.Magic;
            this.Coin = data.Coin;
            this.Exp = data.Exp;
            this.MonsterId = data.MonsterId;
            this.Description = data.Description;

            //默认拥有的技能, 次序很重要
            skills.Add(new CommonAttack(isHero));
            skills.Add(new HelmSplitter(isHero));
            skills.Add(new GoodAttack(isHero));

            SkillOnIt = null;
        }

        #region 人物的基本属性
        /// <summary>
        /// 获取或设置怪物的id, 勇士的id默认为0
        /// </summary>
        public int MonsterId { get; set; }

        private string name;
        /// <summary>
        /// 获取或设置人物的名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
                OnChange();
            }
        }

        private int hp;
        /// <summary>
        /// 获取或设置人物的Hp
        /// </summary>
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                //当什么小于0时，设置生命为0
                hp = value > 0 ? value : 0;

                OnChange();
            }
        }

        private int defence;
        /// <summary>
        /// 获取或设置人物的防御
        /// </summary>
        public int Defence
        {
            get
            {
                return defence;
            }
            set
            {
                defence = value;
                OnChange();
            }
        }

        private int attack;
        /// <summary>
        /// 获取或设置人物的攻击
        /// </summary>
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
                OnChange();
            }
        }

        private int agility;
        /// <summary>
        /// 获取或设置人物的敏捷
        /// </summary>
        public int Agility
        {
            get
            {
                return agility;
            }
            set
            {
                agility = value;
                OnChange();
            }
        }

        private int magic;
        /// <summary>
        /// 获取或设置人物的魔法
        /// </summary>
        public int Magic
        {
            get
            {
                return magic;
            }
            set
            {
                magic = value;
                OnChange();
            }
        }

        private int level;
        /// <summary>
        /// 获取或设置人物的等级
        /// </summary>
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnChange();
            }
        }

        private int exp;
        /// <summary>
        /// 获取或设置人物的经验
        /// </summary>
        public int Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
                OnChange();
            }
        }

        private int coin;
        /// <summary>
        /// 获取或设置人物的金币数量
        /// </summary>
        public int Coin
        {
            get
            {
                return coin;
            }
            set
            {
                coin = value;
                OnChange();
            }
        }

        private string description;
        /// <summary>
        /// 获取或设置人物的描述
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnChange();
            }
        }
        
        #endregion

        /// <summary>
        /// 获取或设置人物是否可以被攻击
        /// </summary>
        public bool CanBattle { get; set; }

        private bool inBattle = false;
        /// <summary>
        /// 获取或设置人物是否处于战斗状态
        /// </summary>
        public bool InBattle
        {
            get { return inBattle; }
            set {
                inBattle = value;
                
                //设置状态时更新界面数据
                OnChange();
            }
        }

        /// <summary>
        /// 角色属性改变时触发的事件
        /// </summary>
        public event EventHandler AttributeChange = null;

        /// <summary>
        /// 触发角色改变属性时的事件
        /// </summary>
        public void OnChange()
        {
            //处于战斗状态时，不修改界面数据
            if (InBattle)
            {
                return;
            }

            if (AttributeChange != null)
            {
                AttributeChange(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// 设置人物死亡
        /// </summary>
        public virtual void Death()
        {
            this.Exist = false;
        }

        /// <summary>
        /// 获取与目标对战的预测伤害
        /// </summary>
        /// <param name="target">对战目标, 主动攻击方</param>
        /// <returns>预测伤害</returns>
        public int HarmTo(ICanShowData target)
        {
            int result = 0;
            //无法攻击, 伤害无穷大
            if (target.Attack <= this.Defence)
            {
                result = int.MaxValue;
            }
            //被防杀，伤害为0
            else if (this.Attack <= target.Defence)
            {
                result = 0;
            }
            else
            {
                //单次伤害 = 攻击力 - 防御力
                int oneHarm = this.Attack - target.Defence;

                //受到攻击的次数 = 目标杀死怪物的攻击次数 - 1
                int harmCount = Common.Ceil(this.Hp, target.Attack - this.Defence) - 1;

                //总伤害 = 单次伤害 * 受到攻击的次数
                result = oneHarm * harmCount;
            }

            return result;
        }

        /// <summary>
        /// 与其他人物就可对目标对象造成多少伤害进行比较，如果伤害相同，比较id
        /// </summary>
        /// <param name="obj">可战斗的人物</param>
        /// <returns>如果伤害相同且id相同，返回0，如果伤害比比较对象小，返回-1</returns>
        public int CompareTo(object obj)
        {
            ICanShowData monster = obj as ICanShowData;
            
            ICanShowData hero = MotaWorld.GetInstance().MapManager.CurHero;
            if (this.HarmTo(hero) == monster.HarmTo(hero))
            {
                return this.MonsterId.CompareTo(monster.MonsterId);
            }
            if (this.HarmTo(hero) > monster.HarmTo(hero))
            {
                return 1;
            }
            return -1;
        }

        #region 技能相关字段和方法
        /// <summary>
        /// 获取或设置攻击音效
        /// </summary>
        public SoundType AttackSound { get; set; }

        /// <summary>
        /// 获取或设置显示在人物身上的技能特效
        /// </summary>
        public Bitmap SkillOnIt { get; set; }

        protected List<Skill> skills = new List<Skill>(0);
        /// <summary>
        /// 获取人物拥有的技能
        /// </summary>
        public List<Skill> Skills
        {
            get {
                //返回副本
                return new List<Skill>(skills);
            }
        }

        /// <summary>
        /// 设置技能动画
        /// </summary>
        /// <param name="commonAttackFile">普通攻击效果图像文件</param>
        /// <param name="goodAttackFile">暴击效果图像文件</param>
        /// <param name="BestAttackFile">愤怒一击效果图像文件</param>
        public void SetSkillFlash(string commonAttackFile, string goodAttackFile, string BestAttackFile)
        {
            foreach (var item in skills)
            {
                if (item is CommonAttack && commonAttackFile.CompareTo(string.Empty) != 0)
                {
                    item.ResetFlash(commonAttackFile);
                }
                if (item is GoodAttack && goodAttackFile.CompareTo(string.Empty) != 0)
                {
                    item.ResetFlash(goodAttackFile);
                }
                if (item is BestAttack && BestAttackFile.CompareTo(string.Empty) != 0)
                {
                    item.ResetFlash(BestAttackFile);
                }
            }
        } 
        #endregion

        /// <summary>
        /// 获得怪物或勇士在战斗窗口和怪物手册窗口中显示的图像
        /// </summary>
        public virtual Bitmap Icon
        {
            get {
                Bitmap unitFace = new Bitmap(GameIni.UnitSize.Width, GameIni.UnitSize.Height);

                //选取源图像的中下处作为缩略图像
                Point p = Point.Empty;
                p.X = CurFace.Width / 2 - unitFace.Width / 2;
                p.Y = CurFace.Height - unitFace.Height;
                Graphics.FromImage(unitFace).DrawImage(CurFace, new Rectangle(Point.Empty, GameIni.UnitSize), new Rectangle(p, GameIni.UnitSize), GraphicsUnit.Pixel);
                return unitFace;
            }
        }
        
        /// <summary>
        /// 允许撤退的次数
        /// </summary>
        private int QuitNumber = GameIni.AllowQuitNumber;

        /// <summary>
        /// 获取人物是否允许撤退
        /// </summary>
        public bool AllowQuit
        {
            get { return QuitNumber > 0; }
        }

        /// <summary>
        /// 在战斗中被动撤退一次，因为对方点了撤退按钮
        /// </summary>
        public void Quit()
        {
            QuitNumber--;
        }

        private bool selected = false;
        /// <summary>
        /// 获取或设置人物是否被选中用于侦测
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set {
                selected = value;
            }
        }

        /// <summary>
        /// 绘制人物到画布
        /// </summary>
        /// <param name="g">画布</param>
        public override void Draw(Graphics g)
        {
            //如果被侦测器选中，绘制选中边框效果
            if (Exist && Selected)
            {
                g.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(PaintPoint, CurFace.Size));
                g.DrawImage(MotaImage.SelectedBackImage, new Rectangle(PaintPoint, CurFace.Size));
            }

            base.Draw(g);
        }

        /// <summary>
        /// 获取人物图像左上角出现在窗口上的位置和尺寸
        /// </summary>
        public Rectangle ExistRectangle
        {
            get 
            {
                Rectangle aRectangle = Rectangle.Empty;
                aRectangle.Location = MotaWorld.GetInstance().MapManager.GetWindowPosation(PaintPoint);
                aRectangle.Size = CurFace.Size;
                return aRectangle;
            }
        }

        protected override void SaveTypeTo(XElement eventType)
        {
            eventType.SetAttributeValue("curHp", this.Hp);
            eventType.SetAttributeValue("id", this.MonsterId);
        }
    }
}







