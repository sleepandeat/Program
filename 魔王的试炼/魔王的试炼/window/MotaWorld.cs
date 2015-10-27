using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔世界窗口，用于管理和操作窗口，单例模式
    /// </summary>
    partial class MotaWorld : GameWindow
    {
        /// <summary>
        /// 魔塔世界的唯一实例
        /// </summary>
        private static MotaWorld Mota;

        /// <summary>
        /// 创建魔塔世界窗口实例
        /// </summary>
        private MotaWorld()
            : base(GameIni.WindowWidth, GameIni.WindowHeight)
        {
            //魔塔地图窗口
            Windows.Add(new MainGame());
            
            //物品获取消息窗口
            Windows.Add(new GoodsMessage());
            
            //楼层跳转窗口
            Windows.Add(new FloorFlash(new Bitmap("images/map/FloorMove.png")));
            
            //消息提示窗口
            Windows.Add(new MessageShow());
            
            //楼层跳转窗口
            Windows.Add(new FloorSkip());
            
            //对话窗口
            Windows.Add(new DialogueBox());
            
            //商店窗口
            Windows.Add(new Shop());
            
            //战斗窗口
            Windows.Add(new BattleBox());
            
            //怪物手册
            Windows.Add(new MonsterBook());

            //怪物数据窗口
            Windows.Add(new MiniBook());

            CanAuto = true;
        }

        /// <summary>
        /// 返回魔塔的唯一实例，如果不存在，创建一个
        /// </summary>
        /// <returns></returns>
        public static MotaWorld GetInstance()
        {
            if (Mota == null)
            {
                Mota = new MotaWorld();
            }
            return Mota;
        }

        /// <summary>
        /// 游戏结束事件
        /// </summary>
        public event EventHandler GameOverEvent = null;

        private bool gameOver = false;
        /// <summary>
        /// 获取或设置游戏是否结束
        /// </summary>
        public bool GameOver
        {
            get { return gameOver; }
            set {
                gameOver = value;
                if (value && GameOverEvent != null)
                {
                    GameOverEvent(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 获取当前活动的游戏人物
        /// </summary>
        public Hero CurHero
        {
            get
            { 
                //隐藏委托链
                return MapManager.CurHero;
            }
        }

        /// <summary>
        /// 游戏窗口容器
        /// </summary>
        private List<GameWindow> Windows = new List<GameWindow>(0);

        /// <summary>
        /// 获取魔塔世界中是否存在独显窗口
        /// </summary>
        public bool ExistSolo
        {
            get {
                foreach (var item in Windows)
                {
                    if (item.Enable && item.Solo)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        
        /// <summary>
        /// 驱动游戏运转到下一帧
        /// </summary>
        public override void NextFrame()
        {
            foreach (var item in Windows)
            {
                if (item.Enable)
                {
                    item.NextFrame();
                }
            }

            base.NextFrame();
        }

        /// <summary>
        /// 重新绘制魔塔世界窗口,集成所有活动的参考
        /// </summary>
        protected override void ReDraw()
        {
            foreach (var item in Windows)
            {
                if (item.Enable)
                {
                    Graphics g = Graphics.FromImage(WindowFace);
                    g.DrawImage(item.WindowFace, item.ExistStation);
                }
            }
        }

        /// <summary>
        /// 以存档文件打开魔塔
        /// </summary>
        /// <param name="data"></param>
        public override void Open(object data)
        {
            string recordFile;
            if (data == null || !(data is string))
            {
                recordFile = GameIni.MainRecord;
            }
            else
            {
                recordFile = data as string;
            }

            Recorder.GetInstence().Load(recordFile);
            
            this.Enable = true;
            
            //打开地图窗口
            this.MapManager.Open(null);
        }

        /// <summary>
        /// 处理游戏控制按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>是否处理成功</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            HandleOrder(code);

            if (!Enable)
            {
                return false;
            }

            //依次交给各个独显窗口处理按键，如果处理成功，返回true
            foreach (var item in Windows)
            {
                if (item.Enable && item.Solo && item.HandleKeyDown(code))
                {
                    return true;
                }
            }

            //交给非独显窗口处理按键
            foreach (var item in Windows)
            {
                if (item.Enable && !item.Solo && item.HandleKeyDown(code))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 处理游戏命令
        /// </summary>
        private void HandleOrder(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.S)
            {
                Recorder.GetInstence().Save(GameIni.RecordFile);
            }
            if (code == System.Windows.Forms.Keys.R)
            {
                Recorder.GetInstence().Load(GameIni.RecordFile);
            }
            if (code == System.Windows.Forms.Keys.E)
            {
                Recorder.GetInstence().Load(GameIni.MainRecord);
            }
            if (code == System.Windows.Forms.Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (code == System.Windows.Forms.Keys.A)
            {
                this.CanAuto = !this.CanAuto;
            }
        }

        /// <summary>
        /// 获取或设置是否可以自动移动
        /// </summary>
        private bool CanAuto { get; set; }

        /// <summary>
        /// 打开怪物信息窗口，显示怪物的详细数据
        /// </summary>
        /// <param name="pos">怪物的坐标(在当前楼层中)</param>
        private void ShowMonsterData(Coord pos)
        {
            FloorNode curFloor = MapManager.CurFloorNode;
            if (curFloor.IsMonster(pos))
            {
                MotaWorld.GetInstance().MiniBookWindow.Open(curFloor.EventMap[pos.Row, pos.Col] as Monster);
            }
            else
            {
                MotaWorld.GetInstance().MiniBookWindow.Close();
            }
        }

        /// <summary>
        /// 打开怪物信息窗口，显示怪物的详细数据
        /// </summary>
        /// <param name="windowPoint">怪物出现在视图窗口上的位置</param>
        private void ShowMonsterData(Point windowPoint)
        {
            this.ShowMonsterData(MapManager.GetPosation(windowPoint));
        }

        /// <summary>
        /// 给事件设置焦点
        /// </summary>
        /// <param name="windowPoint">焦点出现在视图窗口上的位置</param>
        public void SetEventFoucs(Point windowPoint)
        {
            MapManager.CurFloorNode.SetEventFoucs(MapManager.GetPosation(windowPoint));
        }

        /// <summary>
        /// 响应界面鼠标点击事件
        /// </summary>
        /// <param name="windowPoint">鼠标点击的位置</param>
        /// <param name="leftButton">是否鼠标左击</param>
        public void HandleMouseClick(Point windowPoint, bool leftButton)
        {
            if (leftButton)
            {
                if (!ExistSolo && CanAuto)
                {
                    MapManager.CurHero.MoveTo(MapManager.GetPosation(windowPoint));
                }
            }
            else
            {
                ShowMonsterData(windowPoint);
            }           
        }

        /// <summary>
        /// 关闭除地图窗口之外的窗口
        /// </summary>
        public void CloseWindow()
        {
            foreach (var item in Windows)
            {
                if (!(item is MainGame))
                {
                    item.Enable = false;
                }
            }
        }
    }
}










