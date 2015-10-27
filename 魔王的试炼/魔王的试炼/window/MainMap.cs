using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    //摘要:
    //  这是游戏逻辑管理类，用于协调各方制作游戏画面
    //
    //设计思路:
    //  具体细节委托给内部对象处理，整体细节独自完成
    //
    //特征:
    //  管理当前的楼层状态，拥有游戏人物对象
    //

    /// <summary>
    /// 游戏的主场景窗口，参与游戏人物的互动
    /// </summary>
    partial class MainGame : GameWindow
    {
        /// <summary>
        /// 创建魔塔地图窗口
        /// </summary>
        public MainGame() : base(GameIni.WindowWidth, GameIni.WindowHeight) 
        {
            Solo = false;

            GuidePoint = new Background(MotaElement.指引指针, Coord.Empty);
            GuidePoint.PlayInterval = 100;
        }

        /// <summary>
        /// 魔塔地图
        /// </summary>
        public MagicTower Tower = new MagicTower();

        /// <summary>
        /// 获取当前活动的勇士
        /// </summary>
        public Hero CurHero { get; set; }

        /// <summary>
        /// 魔塔的全景地图
        /// </summary>
        private Bitmap MapViewPic;

        /// <summary>
        /// 游戏地图视口
        /// </summary>
        private MapView View = new MapView();

        /// <summary>
        /// 指引指针
        /// </summary>
        private Background GuidePoint;

        #region 管理楼层状态
        /// <summary>
        /// 楼层跳转时触发的事件
        /// </summary>
        public event EventHandler FloorChangeEvent = null;

        int curFloorIndex;
        /// <summary>
        /// 获取或设置当前楼层索引
        /// </summary>
        public int CurFloorIndex
        {
            get
            {
                return curFloorIndex;
            }
            set
            {
                if (value < 0 || value >= Tower.MaxFloor)
                {
                    return;
                }

                //楼层切换时，更新人物位置
                if (value >= curFloorIndex)
                {
                    //上楼
                    CurHero.Station = Tower[value].HeroUpPos;
                }
                else
                {
                    //下楼
                    CurHero.Station = Tower[value].HeroDownPos;
                }

                //更新人物朝向
                CurHero.FaceTo = Direction.Down;

                //更新窗口
                View.ResetView(CurHero.Station);

                SetFloor(value);
            }
        }

        /// <summary>
        /// 设置新的楼层
        /// </summary>
        /// <param name="index">楼层索引</param>
        private void SetFloor(int index)
        {
            curFloorIndex = index;

            if (FloorChangeEvent != null)
            {
                FloorChangeEvent(null, EventArgs.Empty);
            }

            //经过的楼层设置为true
            FloorReached[index] = true;

            //楼层跳转效果
            MotaWorld.GetInstance().SkipFlashWindow.Open(new ShortMessage(CurFloorNode.FloorName, Coord.Empty));
            SoundsList.PlaySound(SoundType.楼层跳转);
        }

        /// <summary>
        /// 获取当前楼层节点
        /// </summary>
        public FloorNode CurFloorNode
        {
            get { return Tower[CurFloorIndex]; }
        }

        /// <summary>
        /// 获取或设置楼层是否抵达
        /// </summary>
        public bool[] FloorReached;
        #endregion

        /// <summary>
        /// 刷新魔塔地图
        /// </summary>
        public override void NextFrame()
        {
            //对当前楼层的所有元素刷新一次
            CurFloorNode.Refresh();

            //驱动人物运转
            CurHero.Play();

            //地图晃动计数
            View.ShakeCount++;

            GuidePoint.Play();

            base.NextFrame();
        }

        /// <summary>
        /// 重绘可见窗口内的地图元素
        /// </summary>
        protected override void ReDraw()
        {
            Graphics canvas = Graphics.FromImage(MapViewPic);

            //计算要绘制的坐标范围
            CoordRange paintRange = new CoordRange(View.PaintWindow, CurFloorNode.FloorSize);
            
            //填充全景地图
            if (View.Shaked)
            {
                Graphics.FromImage(WindowFace).Clear(Color.Black);
            }
            
            //绘制地表
            DrawBackground(canvas, paintRange);

            //绘制地图
            DrawMap(canvas, paintRange);

            //绘制指引指针
            if (GuidePoint.Exist)
            {
                GuidePoint.Draw(canvas);
            }
            
            //绘制视口上的图像到窗口地图
            Graphics.FromImage(WindowFace).DrawImage(MapViewPic, FrmMain.DesWindow, View.PaintWindow, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 绘制地图
        /// </summary>
        /// <param name="canvas">画布</param>
        /// <param name="paintRange">绘制范围</param>
        private void DrawMap(Graphics canvas, CoordRange paintRange)
        {
            for (int i = paintRange.startPos.Row; i < paintRange.endPos.Row; i++)
            {
                for (int j = paintRange.startPos.Col; j < paintRange.endPos.Col; j++)
                {
                    CurFloorNode.Draw(canvas, new Coord(j, i));
                }

                //在人物出现的那一行绘制人物，实现覆盖效果
                if (CurHero.Station.Row == i)
                {
                    CurHero.Draw(canvas);
                }
            }
        }

        /// <summary>
        /// 绘制地表
        /// </summary>
        /// <param name="canvas">画布</param>
        /// <param name="paintRange">绘制范围</param>
        private void DrawBackground(Graphics canvas, CoordRange paintRange)
        {
            for (int i = paintRange.startPos.Row; i < paintRange.endPos.Row; i++)
            {
                for (int j = paintRange.startPos.Col; j < paintRange.endPos.Col; j++)
                {
                    canvas.DrawImage(MotaImage.BackImage, Common.GetPointFromCoord(j, i));
                }
            }
        }

        /// <summary>
        /// 打开地图窗口并选择楼层
        /// </summary>
        /// <param name="data">楼层信息</param>
        public override void Open(object data)
        {
            Enable = true;
        }

        /// <summary>
        /// 显示指引指针
        /// </summary>
        /// <param name="pos">指针出现的位置</param>
        public void ShowGuide(Coord pos)
        {
            if (CurFloorNode.InFloor(pos) && pos.CompareTo(Coord.Empty) != 0)
            {
                this.GuidePoint.Exist = true;
                this.GuidePoint.Location = Common.GetPointFromCoord(pos);
            }
        }

        /// <summary>
        /// 停止指针指引
        /// </summary>
        public void StopGuide() { this.GuidePoint.Exist = false; }

        public delegate void IniEventHandle();
        public event IniEventHandle OnIniEvent = null;

        /// <summary>
        /// 重新初始化游戏场景
        /// </summary>
        /// <param name="curFloor">新楼层</param>
        public void Initialize(int curFloor, Hero player, bool[] reached)
        {
            GuidePoint.Exist = false;

            this.CurHero = player;
            this.FloorReached = reached;

            MapViewPic = new Bitmap(GameIni.MapWidth, GameIni.MapHeight);

            //更新窗口
            View.ResetView(CurHero.Station);

            SetFloor(curFloor);

            if (OnIniEvent != null)
            {
                OnIniEvent();
            }
        }
    }
}









