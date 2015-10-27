using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏战斗窗口，处理游戏的战斗逻辑，与技能类与战斗员接口交互数据
    /// </summary>
    class BattleBox : GameWindow
    {
        /// <summary>
        /// 创建战斗窗口
        /// </summary>
        public BattleBox()
            : base(GameIni.BattleSize.Width, GameIni.BattleSize.Height)
        {
            ExistStation = new Point(90, 150);

            //加载窗口背景图像
            try
            {
                Background = new Bitmap("images/战斗.bmp");
                WinPicture = new Bitmap("images/胜利.png");
            }
            catch { throw new Exception("未找到战斗窗口图像"); }
        }

        /// <summary>
        /// 勇士(主动方，首先攻击)
        /// </summary>
        private IFighter Hero;

        /// <summary>
        /// 战斗胜利之后呈现的图像
        /// </summary>
        private Bitmap WinPicture;

        /// <summary>
        /// 背景
        /// </summary>
        private Bitmap Background;

        /// <summary>
        /// 怪物(被动方)
        /// </summary>
        private IFighter Monster;

        /// <summary>
        /// 获取或设置攻击顺序，如果当前的攻击方为勇士，返回true，否则返回false
        /// 当前的攻击方的生命期为发起攻击后直到对手发起攻击前
        /// </summary>
        private bool HeroTurn { get; set; }

        /// <summary>
        /// 获取或设置战斗是否结束，如果勇士或怪物的其中一方生命值小于等于0，返回true
        /// </summary>
        private bool IsEnd { get; set; }

        /// <summary>
        /// 获取或设置战斗是否有撤退请求
        /// </summary>
        private bool QuitWaiting { get; set; }

        /// <summary>
        /// 返回一个布尔值，表示勇士是否死亡，如果勇士的生命小于等于0，则返回false
        /// </summary>
        private bool HeroDeath
        {
            get { return Hero.Hp <= 0; }
        }

        /// <summary>
        /// 返回一个布尔值，表示怪物是否死亡，如果怪物的生命小于等于0，则返回false
        /// </summary>
        private bool MonsterDeath
        {
            get { return Monster.Hp <= 0; }
        }

        /// <summary>
        /// 战斗消息队列，用于显示战斗消息
        /// </summary>
        private Queue<string> BattleMessages = new Queue<string>(0);

        /// <summary>
        /// 重写基类方法, 播放技能特效
        /// </summary>
        public override void NextFrame() 
        {
            IFighter attacker = HeroTurn ? Hero : Monster;
            IFighter defencer = HeroTurn ? Monster : Hero;

            //先刷新攻击者的攻击技能
            foreach (var item in attacker.Skills)
            {
                if (item.IsAttackSkill)
                {
                    item.Flash(attacker, defencer);
                }
            }
            //再刷新防御者的防御技能
            foreach (var item in defencer.Skills)
            {
                if (!item.IsAttackSkill)
                {
                    item.Flash(attacker, defencer);
                }
            }

            base.NextFrame();
        }

        /// <summary>
        /// 打开战斗窗口，传递战斗的双方
        /// </summary>
        /// <param name="data">战斗的双方（数组）</param>
        public override void Open(object data)
        {
            IFighter[] fighters = data as IFighter[];
            if (fighters != null && fighters.Length == 2)
            {
                Hero = fighters[0];         //勇士
                Monster = fighters[1];      //怪物

                Hero.InBattle = true;
                Monster.InBattle = true;

                //将怪物的播放绑定到战斗的回合上来
                Monster.FrameChangeEvent += new EventHandler(OneBattle);

                //勇士为发动攻击之前
                HeroTurn = false;
                Enable = true;
                IsEnd = false;
                QuitWaiting = false;

                //清空消息队列
                BattleMessages.Clear();

                ReDraw();
            }
            else
            {
                throw new Exception("错误的战斗双方");
            }
        }

        /// <summary>
        /// 双方其中一人进行一次攻击，并重绘窗口
        /// </summary>
        private void OneBattle(object sender, EventArgs e)
        {
            if (!Enable || IsEnd)
            {
                return;
            }

            //战斗结束，不再战斗，等待确定按键关闭窗口
            if (MonsterDeath || HeroDeath)
            {
                IsEnd = true;
                if (MonsterDeath)
                {
                    if (MonsterDeath)
                    {
                        //胜利音效和提示
                        SoundsList.PlaySound(SoundType.战斗结束);
                        if (BattleMessages.Count >= 6)
                        {
                            BattleMessages.Dequeue();
                        }
                        BattleMessages.Enqueue("战斗胜利!" + "获得" + Monster.Coin + "金币," + Monster.Exp + "经验");
                    }
                }

                //勇士失败时立即终止
                if (HeroDeath)
                {
                    Close();
                }
                return;
            }
            else
            {
                //轮流交换战斗
                HeroTurn = !HeroTurn;
                if (HeroTurn)
                {
                    if (QuitWaiting)
                    {
                        Close();
                        return;
                    }

                    //勇士攻击怪物
                    OneFight(Hero, Monster);
                }
                else
                {
                    //怪物攻击勇士
                    OneFight(Monster, Hero);
                }
            }
            
            ReDraw();
        }

        /// <summary>
        /// A向B发动一次攻击
        /// </summary>
        private void OneFight(IFighter A, IFighter B)
        {
            int harm = 0;
            
            //重置所有技能
            foreach (var item in A.Skills)
            {
                item.Reset();
            }
            foreach (var item in B.Skills)
            {
                item.Reset();
            }
            A.SkillOnIt = null;
            B.SkillOnIt = null;

            //主动技能
            foreach (var item in A.Skills)
            {
                if (item.IsAttackSkill)
                {
                    if (item.Onset(ref harm, A, B, BattleMessages))
                    {
                        break;
                    }
                }
            }

            //防御技能
            foreach (var item in B.Skills)
            {
                if (!item.IsAttackSkill)
                {
                    if (item.Onset(ref harm, A, B, BattleMessages))
                    {
                        break;
                    }
                }
            }

            B.Hp -= harm;

            //当信息队列达到一定数量的时候，清空之前的内容以显示最新的信息
            if (BattleMessages.Count >= 7)
            {
                BattleMessages.Clear();
            }

            //战斗消息
            BattleMessages.Enqueue(B.Name + "受到<" + harm + ">点伤害");

            //播放战斗音效
            SoundsList.PlaySound(A.AttackSound);
        }

        /// <summary>
        /// 处理战斗结束情况，关闭窗口
        /// </summary>
        private void Close()
        {    
            //处理战斗结果
            if (MonsterDeath)
            {
                //获取经验和金币
                Hero.Coin += Monster.Coin;
                Hero.Exp += Monster.Exp;

                Monster.Death();
            }
            else if(HeroDeath)
            {
                Hero.Death();
            }

            Hero.InBattle = false;
            Monster.InBattle = false;
            Monster.FrameChangeEvent -= OneBattle;
            this.Enable = false;
        }

        /// <summary>
        /// 绘制战斗窗口
        /// </summary>
        protected override void ReDraw()
        {
            //绘制背景
            Graphics vGraphics = Graphics.FromImage(WindowFace);
            vGraphics.DrawImage(Background, new Point(0, 0));

            Font strFont = new Font("幼圆", 13, FontStyle.Bold);
            SolidBrush strBrush = new SolidBrush(Color.White);

            vGraphics.DrawLine(new Pen(Color.Blue, 2), new Point(0, 72), new Point(WindowFace.Width, 72));
            vGraphics.DrawString("VS", new Font("宋体", 18, FontStyle.Italic), strBrush, new PointF(220, 15));

            //绘制撤退提示
            if (Monster.AllowQuit && Hero.AllowQuit)
            {
                vGraphics.DrawString("Q撤退", new Font("宋体", 17, FontStyle.Italic), new SolidBrush(Color.CornflowerBlue), new PointF(420, 2));
            }

            //绘制怪物
            vGraphics.DrawImage(Monster.Icon, new Point(60, 25));
            vGraphics.DrawString("等级: " + Monster.Level.ToString(), strFont, strBrush, new PointF(30, 80));
            vGraphics.DrawString("生命: " + Monster.Hp.ToString(), strFont, strBrush, new PointF(30, 115));
            vGraphics.DrawString("攻击: " + Monster.Attack.ToString(), strFont, strBrush, new PointF(30, 150));
            vGraphics.DrawString("防御: " + Monster.Defence.ToString(), strFont, strBrush, new PointF(30, 185));

            //绘制展示在怪物身上的技能特效
            if (Monster.SkillOnIt != null)
            {
                vGraphics.DrawImage(Monster.SkillOnIt, new Point(20, -15));
            }
            
            //绘制勇士
            vGraphics.DrawImage(Hero.Icon, new Point(390, 25));
            vGraphics.DrawString("等级: " + Hero.Level.ToString(), strFont, strBrush, new PointF(360, 80));
            vGraphics.DrawString("生命: " + Hero.Hp.ToString(), strFont, strBrush, new PointF(360, 115));
            vGraphics.DrawString("攻击: " + Hero.Attack.ToString(), strFont, strBrush, new PointF(360, 150));
            vGraphics.DrawString("防御: " + Hero.Defence.ToString(), strFont, strBrush, new PointF(360, 185));

            //绘制展示在勇士身上的技能特效
            if (Hero.SkillOnIt != null)
            {
                vGraphics.DrawImage(Hero.SkillOnIt, new Point(350, -15));
            }


            //绘制战斗消息
            ShowMessages();

            //展示胜利画面
            if (IsEnd && MonsterDeath)
            {
                vGraphics.DrawImage(WinPicture, new Point(200, 100));
            }
        }

        /// <summary>
        /// 展示战斗过程信息
        /// </summary>
        private void ShowMessages()
        {
            Rectangle aRectangle = new Rectangle(155, 80, 200, 130);
            //vGraphics.FillRectangle(new SolidBrush(Color.DimGray), aRectangle);

            StringBuilder text = new StringBuilder();
            foreach (var item in BattleMessages)
            {
                text.Append(item + "\r\n");
            }

            Font strFont = new Font("微软雅黑", 10, FontStyle.Regular);
            Brush strBrush = new SolidBrush(Color.White);
            Graphics.FromImage(WindowFace).DrawString(text.ToString(), strFont, strBrush, aRectangle);
        }

        /// <summary>
        /// 处理按键, 确定键关闭窗口
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (IsEnd)
            {
                Close();
                return true;
            }

            if (code == System.Windows.Forms.Keys.Q && Monster.AllowQuit)
            {
                Monster.Quit();
                QuitWaiting = true;
                return true;
            }

            return false;
        }
    }
}


