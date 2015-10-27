using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 魔王的试炼
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            SetCursorPicture(true);

            MotaScene.Width = GameIni.WindowWidth;
            MotaScene.Height = GameIni.WindowHeight;

            timer1.Interval = GameIni.RefreshInterval;

            
            (PropShow = new PacketBox(this.PropPack.Width, this.PropPack.Height)).Enable = true;

            IniGameSelect();

            MotaWorld.GetInstance().MapManager.OnIniEvent += new MainGame.IniEventHandle(Binding);

            SetBack();
        }

        private void SetBack()
        {
            Image img = new Bitmap(this.Width, this.Height);
            Graphics canvas = Graphics.FromImage(img);
            canvas.Clear(Color.Black);
            canvas.DrawString("魔王的试炼V1.0", new Font("宋体", 35, FontStyle.Bold), new SolidBrush(Color.White), new PointF(290, 100));
            canvas.DrawString("作者: F贝贝", new Font("宋体", 20, FontStyle.Bold), new SolidBrush(Color.White), new PointF(550, 160));
            this.BackgroundImage = img;
        }

        /// <summary>
        /// 绑定人物和楼层属性到界面
        /// </summary>
        private void Binding()
        {
            BingingHero();

            //绑定楼层属性到界面
            MotaWorld.GetInstance().MapManager.FloorChangeEvent += new EventHandler(AttributeChange);

            //游戏结束事件
            MotaWorld.GetInstance().GameOverEvent += new EventHandler(FrmMain_GameOverEvent);
        }

        private void BingingHero()
        {
            //绑定人物属性到界面
            MotaWorld.GetInstance().MapManager.CurHero.AttributeChange += new EventHandler(AttributeChange);
            MotaWorld.GetInstance().MapManager.CurHero.Pack.PropertyChangeEvent += new EventHandler(PropertyChange);

            AttributeChange(null, null);
            PropertyChange(null, null);
        }

        void FrmMain_GameOverEvent(object sender, EventArgs e)
        {
            MessageBox.Show("你输了");
            this.Close();
        }

        /// <summary>
        /// 初始化游戏选项
        /// </summary>
        private void IniGameSelect()
        {
            //创建游戏选项类
            GameShow = new GameSelector(GameSelectWindow.Width, GameSelectWindow.Height);
            Option o1 = new GameOption("游戏开始", true);
            o1.TriggerEvent += new EventHandler(NewGame);
            Option o2 = new GameOption("读取存档", true);
            o2.TriggerEvent += new EventHandler(LoadRecord);
            Option o3 = new GameOption("游戏结束", true);
            o3.TriggerEvent += new EventHandler(CloseGame);

            GameShow.AddOption(o1);
            GameShow.AddOption(o2);
            GameShow.AddOption(o3);

            //给游戏选项窗口绑定游戏的几个选项
            GameShow.Open(null);       //初始化选项，默认选中第一项
        }

        /// <summary>
        /// 更新界面上的钥匙情况
        /// </summary>
        void PropertyChange(object sender, EventArgs e)
        {
            //刷新道具窗口图像
            PropShow.NextFrame();

            PropPack.Refresh();
        }

        /// <summary>
        /// 游戏的目标窗口
        /// </summary>
        public static Rectangle DesWindow = new Rectangle(0, 0, GameIni.WindowWidth, GameIni.WindowHeight);

        /// <summary>
        /// 更新界面上的人物属性
        /// </summary>
        void AttributeChange(object sender, EventArgs e)
        {
            PlayerAttack.Text = MotaWorld.GetInstance().CurHero.Attack.ToString();
            PlayerCoins.Text = MotaWorld.GetInstance().CurHero.Coin.ToString();
            PlayerDefence.Text = MotaWorld.GetInstance().CurHero.Defence.ToString();
            PlayerAgility.Text = MotaWorld.GetInstance().CurHero.Agility.ToString();
            PlayerMagic.Text = MotaWorld.GetInstance().CurHero.Magic.ToString();
            PlayerExp.Text = MotaWorld.GetInstance().CurHero.Exp.ToString();
            PlayerLives.Text = MotaWorld.GetInstance().CurHero.Hp.ToString();
            PlayerLevel.Text = MotaWorld.GetInstance().CurHero.Level.ToString();
            lblFloor.Text = "魔 塔 - " + MotaWorld.GetInstance().MapManager.CurFloorNode.FloorName;
        }

        /// <summary>
        /// 游戏选项窗口
        /// </summary>
        GameSelector GameShow;

        /// <summary>
        /// 游戏道具窗口
        /// </summary>
        PacketBox PropShow;

        //刷新选项界面
        private void GameSelectWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(GameShow.WindowFace, 0, 0, GameSelectWindow.Width, GameSelectWindow.Height);
        }

        private Keys PreKey = Keys.None;
        private int KeyCount = 0;

        //根据按键更新游戏选项或移动人物
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == PreKey)
            {
                if (KeyCount >= 7)
                {
                    KeyCount = 0;
                }
                else
                {
                    KeyCount++;
                    return;
                }
            }
            else
            {
                PreKey = e.KeyCode;
            }

            if (e.KeyCode == Keys.T)
            {
                Test();
            }

            if (e.KeyCode == Keys.U)
            {
                this.Editable = !this.Editable;
            }

            if (MotaWorld.GetInstance().HandleKeyDown(e.KeyCode))
            {
                return;
            }

            GameShow.HandleKeyDown(e.KeyCode);

            GameSelectWindow.Refresh();
        }
        
        //关闭游戏事件
        void CloseGame(object sender, EventArgs e)
        {
            this.Close();
        }

        //正式进入游戏
        void EnterGame()
        {
            GameShow.Enable = false;
            GameSelectWindow.Visible = false;
            GameSelectWindow.Enabled = false;

            //打开新的窗口控件
            GameState.Visible = true;
            MotaScene.Visible = true;

            //MP3.Load("背景音乐/start.MP3");
        }

        //新的游戏
        void NewGame(object sender, EventArgs e)
        {
            EnterGame();
            MotaWorld.GetInstance().Open(GameIni.MainRecord);
        }

        //读取游戏
        void LoadRecord(object sender, EventArgs e)
        {
            EnterGame();
            MotaWorld.GetInstance().Open(GameIni.RecordFile);
        }

        //绑定魔塔窗口到界面上
        private void MotaScene_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(MotaWorld.GetInstance().WindowFace, 0, 0, MotaScene.Width, MotaScene.Height);
        }

        //刷新魔塔界面
        private void timer1_Tick(object sender, EventArgs e)
        {
            MotaWorld.GetInstance().NextFrame();
            MotaScene.Refresh();
        }

        //释放按键，停止人物移动
        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == PreKey)
            {
                PreKey = Keys.None;
            }

            if (MotaWorld.GetInstance().MapManager.Enable)
            {
                MotaWorld.GetInstance().MapManager.CurHero.HandleKeyUp(e.KeyCode);
            }
        }

        private void PropPack_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(PropShow.WindowFace, new Point(0, 0));
        }

        private void MotaScene_MouseClick(object sender, MouseEventArgs e)
        {
            Coord pos = MotaWorld.GetInstance().MapManager.GetPosation(e.Location);
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right && Editable)
            {
                CurEditPos = pos;
                cmsMenu.Show(this.MotaScene, e.Location);
                return;
            }

            if (MotaWorld.GetInstance().Enable)
            {
                MotaWorld.GetInstance().HandleMouseClick(e.Location, e.Button == System.Windows.Forms.MouseButtons.Left);
            }

            Tester.ClickTest(pos);
        }

        private void MotaScene_MouseMove(object sender, MouseEventArgs e)
        {
            MotaWorld.GetInstance().SetEventFoucs(e.Location);

            if (MotaWorld.GetInstance().MapManager.IsMonster(e.Location))
            {
                SetCursorPicture(false);
            }
            else
            {
                SetCursorPicture(true);
            }
        }

        /// <summary>
        /// 设置鼠标图像
        /// </summary>
        void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);
            this.Cursor = new Cursor(myNewCursor.GetHicon());
            g.Dispose();
            myNewCursor.Dispose();
        }

        private Bitmap NormalMouse = new Bitmap("images/鼠标.png");
        private Bitmap MonsterMouse = new Bitmap("images/杀敌.png");
        private bool CurMouse;

        /// <summary>
        /// 设置鼠标图像
        /// </summary>
        /// <param name="normarl">是否正常显示</param>
        public void SetCursorPicture(bool normarl)
        {
            if (normarl)
            {
                if (!CurMouse)
                {
                    SetCursor(NormalMouse, Point.Empty);
                    CurMouse = true;
                }
            }
            else
            {
                if (CurMouse)
                {
                    SetCursor(MonsterMouse, Point.Empty);
                    CurMouse = false;
                }
            }
        }

        /// <summary>
        /// 测试函数
        /// </summary>
        public void Test()
        {
            Tester.TestMain();
        }

        private bool editable = false;
        /// <summary>
        /// 表示是否可以编辑
        /// </summary>
        private bool Editable
        {
            set
            {
                editable = value;
            }
            get { return this.editable; }
        }

        private Coord CurEditPos { get; set; }

        private void Copy_Click(object sender, EventArgs e)
        {
            Edit.GetInstance().SetSource(CurEditPos);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Edit.GetInstance().Delete(CurEditPos);
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            Edit.GetInstance().CopyTo(CurEditPos);
        }

        private void 剪贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit.GetInstance().Cut(CurEditPos);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEdit edit = new FrmEdit(CurEditPos);
            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //保存内容
                MotaWorld.GetInstance().MapManager.LoadNode(edit.CurPosation, edit.EditContent);
            }
        }
    }
}











