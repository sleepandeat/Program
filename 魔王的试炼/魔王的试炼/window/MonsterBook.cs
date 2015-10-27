using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 怪物手册窗口，用于显示当前楼层的怪物信息
    /// </summary>
    class MonsterBook : GameWindow
    {
        public MonsterBook()
            : base(GameIni.BookSize.Width, GameIni.BookSize.Height)
        {
            ExistStation = new Point(50, 38);
        }

        /// <summary>
        /// 怪物列表
        /// </summary>
        private List<ICanShowData> Monsters = new List<ICanShowData>(0);

        /// <summary>
        /// 获取当前页面的怪物的枚举器
        /// </summary>
        private IEnumerable<ICanShowData> CurMonsters
        {
            get 
            {
                return Monsters.Skip((CurPage - 1) * GameIni.PageVolume).Take(GameIni.PageVolume);
            }
        }

        private int curPage;
        /// <summary>
        /// 当前的页数
        /// </summary>
        private int CurPage
        {
            get { return curPage; }
            set {
                if (value <= 1)
                {
                    curPage = 1;
                }
                else if(value >= MaxPage)
                {
                    curPage = MaxPage;
                }
                else
                {
                    curPage = value;
                }
                ReDraw();
            }
        }

        /// <summary>
        /// 获取最大的页数
        /// </summary>
        private int MaxPage
        {
            get { return Common.Ceil(Monsters.Count, GameIni.PageVolume); }
        }

        /// <summary>
        /// 设置怪物窗口窗口是否可用,打开怪物手册时，默认打开第一页
        /// </summary>
        public override bool Enable
        {
            get
            {
                return base.Enable;
            }
            set
            {
                base.Enable = value;
                if (Enable)
                {
                    curPage = 1;
                    Monsters.Clear();
                }
            }
        }

        /// <summary>
        /// 重新基类方法，每次刷新时不重绘窗口
        /// </summary>
        public override void NextFrame() { }

        /// <summary>
        /// 打开怪物手册
        /// </summary>
        /// <param name="data">楼层id</param>
        public override void Open(object data)
        {
            Enable = true;

            //搜寻当前楼层的所有怪物
            FloorNode curFloor = MotaWorld.GetInstance().MapManager.CurFloorNode;
            for (int i = 0; i < curFloor.FloorSize.Row; i++)
            {
                for (int j = 0; j < curFloor.FloorSize.Col; j++)
                {
                    if (curFloor.IsMonster(new Coord(j, i)))
                    {
                        //给怪物列表添加怪物, 不用重复
                        Monster oneMonster = curFloor.EventMap[i, j] as Monster;
                        if (!Monsters.Exists(o=>o.MonsterId == oneMonster.MonsterId))
                        {
                            Monsters.Add(oneMonster);   
                        }
                    }
                }
            }

            //按对勇士造成的伤害排序
            Monsters.Sort();

            //如果存在怪物，绑定第一个怪物的图像更新事件，实现在窗口中播放动态的怪物图像
            if (Monsters.Count > 0)
            {
                Monsters[0].FrameChangeEvent += new EventHandler(OneFlash);
            }

            ReDraw();
        }

        /// <summary>
        /// 一次动画效果的展现
        /// </summary>
        void OneFlash(object sender, EventArgs e)
        {
            if (Enable)
            {
                int count = CurMonsters.Count();
                for (int i = 0; i < count; i++)
                {
                    DrawMonsterFace(Graphics.FromImage(Canvas), i);
                }
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void Close()
        {
            Enable = false;
            if (Monsters.Count > 0)
            {
                Monsters[0].FrameChangeEvent -= OneFlash;
            }
        }

        /// <summary>
        /// 窗口的临时画布
        /// </summary>
        private Bitmap Canvas;

        /// <summary>
        /// 绘制怪物数据到窗口
        /// </summary>
        protected override void ReDraw()
        {
            Canvas = new Bitmap(WindowFace);
            Graphics g = Graphics.FromImage(Canvas);
            g.Clear(Color.Black);

            Font strFont = new Font("幼圆", 12, FontStyle.Bold);
            SolidBrush strBrush = new SolidBrush(Color.White);
            
            g.DrawString("怪物手册", new Font("宋体", 18, FontStyle.Bold), strBrush, new PointF(220, 10));

            OneFlash(null, null);

            //逐一绘制怪物属性
            int trun = 0;
            IEnumerable<ICanShowData> curMonsters = CurMonsters;
            foreach (var item in curMonsters)
            {
                DrawMonsterData(g, trun, item);

                trun++;
            }

            //绘制说明信息
            g.DrawString("按space返回主游戏页面", strFont, strBrush, new PointF(190, 420));

            g.DrawString(curPage.ToString() + " / " + MaxPage.ToString(), strFont, strBrush, new PointF(460, 420));
            try
            {
                //如果当前页数大于1，绘制向左翻页的提示
                if (CurPage > 1)
                {
                    g.DrawImage(new Bitmap("images/left.png"), new Point(440, 418));
                }
                //如果当前页数小于最大页数，绘制向右翻页提示
                if (curPage < MaxPage)
                {
                    g.DrawImage(new Bitmap("images/right.png"), new Point(508, 418));
                }
            }
            catch 
            {
            }

            Canvas.SetOpacity(0.90F);
            WindowFace = Canvas;
        }

        /// <summary>
        /// 绘制怪物数据
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="trun">怪物在页面中的出现次序</param>
        /// <param name="monster">怪物元素</param>
        private void DrawMonsterData(Graphics g, int trun, ICanShowData monster)
        {
            ICanShowData hero = MotaWorld.GetInstance().MapManager.CurHero;
            Font strFont = new Font("幼圆", 12, FontStyle.Bold);
            SolidBrush strBrush = new SolidBrush(Color.White);
            SolidBrush harmBrush = new SolidBrush(Color.White);

            //怪物名称
            g.DrawString(monster.Name, strFont, strBrush, new PointF(70, 50 + 62 * trun));

            //怪物生命
            g.DrawString("生命: " + monster.Hp.ToString(), strFont, strBrush, new PointF(170, 50 + 62 * trun));

            //怪物攻击
            g.DrawString("攻击: " + monster.Attack.ToString(), strFont, strBrush, new PointF(280, 50 + 62 * trun));

            //怪物防御
            g.DrawString("防御: " + monster.Defence.ToString(), strFont, strBrush, new PointF(380, 50 + 62 * trun));

            //怪物等级
            g.DrawString("等级: " + monster.Level.ToString(), strFont, strBrush, new PointF(480, 50 + 62 * trun));

            //伤害预测
            int harm = monster.HarmTo(hero);
            string harmDesc;
            if (harm == int.MaxValue)
            {
                harmDesc = "无法攻击";
                harmBrush.Color = Color.Red;
            }
            else if (harm == 0)
            {
                harmDesc = "无危险";
                harmBrush.Color = Color.LightGreen;
            }
            else if (harm < hero.Hp)
            {
                harmDesc = "受到" + harm.ToString() + "点伤害";
                harmBrush.Color = Color.LightSalmon;
            }
            else
            {
                harmDesc = "受到" + harm.ToString() + "点伤害";
                harmBrush.Color = Color.DarkGray;

            }
            g.DrawString(harmDesc, strFont, harmBrush, new PointF(70, 72 + 62 * trun));

            //收获
            g.DrawString("金币: " + monster.Coin, strFont, strBrush, new PointF(280, 72 + 62 * trun));
            g.DrawString("经验: " + monster.Exp, strFont, strBrush, new PointF(380, 72 + 62 * trun));
        }

        /// <summary>
        /// 绘制怪物头像到画布
        /// </summary>
        /// <param name="trun">怪物在页面上出现的次序</param>
        private void DrawMonsterFace(Graphics g, int trun)
        {
            Point p = new Point(20, 50 + 62 * trun);
            g.DrawImage(MotaImage.BackImage, p);
            g.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(p, new Size(GameIni.ElementWidth, GameIni.ElementHeight)));
            g.DrawImage(Monsters[(CurPage - 1) * GameIni.PageVolume + trun].Icon, p);
        }

        /// <summary>
        /// 处理按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            //当窗口处于关闭状态，只能通过道具来开启
            if (!Enable)
            {
                return false;
            }

            //关闭窗口
            if (code == System.Windows.Forms.Keys.Space)
            {
                this.Close();
            }
                //向前翻页
            else if (code == System.Windows.Forms.Keys.Left || code == System.Windows.Forms.Keys.PageUp)
            {
                CurPage--;
            }
                //向后翻页
            else if (code == System.Windows.Forms.Keys.Right || code == System.Windows.Forms.Keys.PageDown)
            {
                CurPage++;
            }

            return true;
        }

    }
}




