using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 怪物数据迷你窗口，用于显示选中怪物的详细信息
    /// </summary>
    class MiniBook : GameWindow
    {
        public MiniBook()
            : base(GameIni.WindowWidth, GameIni.WindowHeight)
        {
        }

        /// <summary>
        /// 目标怪物
        /// </summary>
        private ICanShowData Monster;

        /// <summary>
        /// 获取或设置窗口出现在视图上的位置
        /// </summary>
        private Point ShowPoint { get; set; }

        /// <summary>
        /// 获取或设置怪物数据窗口是否在怪物的右面
        /// </summary>
        private bool InRight { get; set; }

        /// <summary>
        /// 获取或设置怪物数据窗口是否在怪物的下面
        /// </summary>
        private bool Below { get; set; }

        /// <summary>
        /// 获取被侦测的怪物与窗口的连接点
        /// </summary>
        private Point MonsterLinkPoint
        {
            get {
                if (Monster != null)
                {
                    return new Point(Monster.ExistRectangle.X + Monster.ExistRectangle.Width / 2, Monster.ExistRectangle.Y + (Below ? Monster.ExistRectangle.Height : 0));
                }
                else
                {
                    return Point.Empty;
                }
            }
        }

        /// <summary>
        /// 获取窗口与被侦测的怪物的连接点
        /// </summary>
        private Point WindowLinkPoint
        {
            get
            {
                return new Point(ShowPoint.X + (InRight ? 0 : GameIni.MiniBookSize.Width), ShowPoint.Y + GameIni.MiniBookSize.Height / 2);
            }
        }

        /// <summary>
        /// 重新基类方法，每次刷新时不重绘窗口
        /// </summary>
        public override void NextFrame() { }

        /// <summary>
        /// 以怪物接口打开怪物手册
        /// </summary>
        /// <param name="data">怪物接口</param>
        public override void Open(object data)
        {
            if (!MotaWorld.GetInstance().MapManager.CurHero.Pack.ExistProperty(PropName.怪物侦测器))
            {
                return;
            }

            if (!(data is ICanShowData))
            {
                throw new Exception("错误的怪物类型");
            }

            //打开之前先尝试关闭之前的窗口
            Close();

            Monster = data as ICanShowData;
            Monster.FrameChangeEvent += new EventHandler(OneFlash);
            Monster.Selected = true;

            //设置窗口位置
            ShowPoint = GetShowPosation();

            Enable = true;
            ReDraw();
        }

        /// <summary>
        /// 根据怪物的位置设置窗口出现的位置
        /// </summary>
        /// <returns>窗口的出现位置</returns>
        private Point GetShowPosation()
        {
            Point showPosation = Point.Empty;

            //无法将窗口放在怪物右边的情况
            if (Monster.ExistRectangle.Right + GameIni.MiniBookSize.Width + 10 > GameIni.WindowWidth)
            {
                //就将窗口放在怪物左边
                showPosation.X = Monster.ExistRectangle.X - GameIni.MiniBookSize.Width - 10;
                InRight = false;
            }
            else
            {
                //否则将窗口放在怪物右边
                showPosation.X = Monster.ExistRectangle.Right + 10;
                InRight = true;
            }

            //无法将窗口放在怪物下边的情况
            if (Monster.ExistRectangle.Y + GameIni.MiniBookSize.Height > GameIni.WindowHeight)
            {
                //就将窗口放在怪物上边
                showPosation.Y = Monster.ExistRectangle.Bottom - GameIni.MiniBookSize.Height;
                Below = false;
            }
            else
            {
                //否则将窗口放在怪物下边
                showPosation.Y = Monster.ExistRectangle.Y;
                Below = true;
            }

            return showPosation;
        }

        /// <summary>
        /// 怪物图像一次动画效果的展现
        /// </summary>
        void OneFlash(object sender, EventArgs e)
        {
            if (Enable)
            {
                Graphics vGraphics = Graphics.FromImage(WindowFace);
                Point p = new Point(40 + ShowPoint.X, 10 + ShowPoint.Y);
                vGraphics.DrawImage(MotaImage.BackImage, p);
                vGraphics.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(p, new Size(GameIni.ElementWidth, GameIni.ElementHeight)));
                vGraphics.DrawImage(Monster.Icon, p);
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public void Close()
        {
            Enable = false;
            if (Monster != null)
            {
                Monster.FrameChangeEvent -= OneFlash;
                Monster.Selected = false;
            }
        }

        /// <summary>
        /// 窗口的临时画布
        /// </summary>
        private Bitmap Canvas = new Bitmap(GameIni.MiniBookSize.Width, GameIni.MiniBookSize.Height);

        /// <summary>
        /// 绘制怪物数据到窗口
        /// </summary>
        protected override void ReDraw()
        {
            Graphics vGraphics = Graphics.FromImage(WindowFace);
            vGraphics.Clear(Color.Transparent);

            //临时绘图窗口
            Graphics g = Graphics.FromImage(Canvas);
            g.Clear(Color.BlueViolet);

            Font strFont = new Font("微软雅黑", 12, FontStyle.Regular);
            SolidBrush strBrush = new SolidBrush(Color.White);
            ICanShowData hero = MotaWorld.GetInstance().MapManager.CurHero;
            SolidBrush harmBrush = new SolidBrush(Color.White);     //伤害刷子

            //绘制边框
            g.DrawRectangle(new Pen(Color.LightGreen, 2), new Rectangle(0, 0, Canvas.Width, Canvas.Height));

            //怪物名称
            g.DrawString(Monster.Name, new Font("幼圆", 14, FontStyle.Regular), strBrush, new PointF(90, 20));

            //怪物等级
            g.DrawString("等级: " + Monster.Level.ToString(), strFont, strBrush, new PointF(10, 60));

            //怪物生命
            g.DrawString("生命: " + Monster.Hp.ToString(), strFont, strBrush, new PointF(120, 60));

            //怪物攻击
            g.DrawString("攻击: " + Monster.Attack.ToString(), strFont, strBrush, new PointF(10, 90));

            //怪物防御
            g.DrawString("防御: " + Monster.Defence.ToString(), strFont, strBrush, new PointF(120, 90));

            //怪物敏捷
            g.DrawString("敏捷: " + Monster.Agility.ToString(), strFont, strBrush, new PointF(10, 120));

            //怪物防御
            g.DrawString("魔法: " + Monster.Magic.ToString(), strFont, strBrush, new PointF(120, 120));

            //怪物防御
            g.DrawString("金币: " + Monster.Coin.ToString(), strFont, strBrush, new PointF(10, 150));

            //怪物防御
            g.DrawString("经验: " + Monster.Exp.ToString(), strFont, strBrush, new PointF(120, 150));

            //怪物简介
            g.DrawString(Monster.Description, new Font("幼圆", 12, FontStyle.Regular), strBrush, new Rectangle(10, 180, 230, 60));

            //伤害预测
            int harm = Monster.HarmTo(hero);
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
                harmDesc = "可能造成" + harm.ToString() + "点伤害";
                harmBrush.Color = Color.LightSalmon;
            }
            else
            {
                harmDesc = "可能造成" + harm.ToString() + "点伤害";
                harmBrush.Color = Color.DarkGray;

            }
            g.DrawString(harmDesc, strFont, harmBrush, new PointF(10, 240));
            Canvas.SetOpacity(0.80F);

            //将临时窗口绘制到视图窗口上，交由其共享到全局视图中。
            vGraphics.DrawImage(Canvas, ShowPoint);

            //绘制连接线
            vGraphics.DrawLine(new Pen(Color.LightGreen, 1), MonsterLinkPoint, WindowLinkPoint);

            //绘制怪物头像
            OneFlash(null, null);
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
            if (code == System.Windows.Forms.Keys.Space || code == System.Windows.Forms.Keys.Enter)
            {
                this.Close();
            }

            return true;
        }

    }
}




