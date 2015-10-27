using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    //摘要:
    //  运用Replace method with method object重构手法，从原本的move函数提炼出此类
    //
    //使用:
    //  创建一个临时对象，传人源类的引用
    //

    /// <summary>
    /// 移动协助类，用于协助moveelement完成一次移动
    /// </summary> 
    class MoveHelper
    {
        /// <summary>
        /// 创建一个临时方法对象，传人源类的引用
        /// </summary>
        /// <param name="mover">用户类引用</param>
        public MoveHelper(MoveElement mover)
        {
            this.Mover = mover;

            //创建时初始化字段
            NextSite = GetNextSite();
            CaculateAroundPos();
            CaculateAroundPass();
        }

        /// <summary>
        /// 可移动对象的引用
        /// </summary>
        private MoveElement Mover;

        /// <summary>
        /// 获取移动之前的位置
        /// </summary>
        private Point PreSite
        {
            get { return this.Mover.Location; }
        }

        /// <summary>
        /// 获取移动后的新位置(非最终位置)
        /// </summary>
        public Point NextSite { get; set; }

        /// <summary>
        /// 得到新位置
        /// </summary>
        private Point GetNextSite()
        { 
            Point NextSite = PreSite;
            //移动一格单位距离
            switch (MoveDirection)
            {
                case Direction.Up:
                    NextSite.Y -= this.Mover.Speed;
                    break;
                case Direction.Down:
                    NextSite.Y += this.Mover.Speed;
                    break;
                case Direction.Left:
                    NextSite.X -= this.Mover.Speed;
                    break;
                case Direction.Right:
                    NextSite.X += this.Mover.Speed;
                    break;
                default:
                    break;
            }
            return NextSite;
        }

        /// <summary>
        /// 获取当前的移动方向
        /// </summary>
        private Direction MoveDirection
        {
            get { return this.Mover.MoveDirection; }
        }

        #region 四方的临时状态
        /// <summary>
        /// 新位置处右下的坐标
        /// </summary>
        private Coord EndPos;

        /// <summary>
        /// 新位置处左上的坐标
        /// </summary>
        private Coord StartPos;
        
        /// <summary>
        /// 新位置处右上的坐标
        /// </summary>
        private Coord RightPos;

        /// <summary>
        /// 新位置处左下的坐标
        /// </summary>
        private Coord LeftPos;

        /// <summary>
        /// 新位置处右下的坐标的可通行性
        /// </summary>
        private bool EndPassable;

        /// <summary>
        /// 新位置处右上的坐标的可通行性
        /// </summary>
        private bool RightPassable;

        /// <summary>
        /// 新位置处左上的坐标的可通行性
        /// </summary>
        private bool StartPassable;

        /// <summary>
        /// 新位置处左下的坐标的可通行性
        /// </summary>
        private bool LeftPassable;

        #endregion

        /// <summary>
        /// 获取人物移动之前右侧的 X 坐标，为位置的 X 坐标 加上移动对象的图像宽度
        /// </summary>
        private int Right
        {
            get
            {
                return Left + this.Mover.CurFace.Width;
            }
        }

        /// <summary>
        /// 获取人物移动之前底部的 Y 坐标，为位置的 Y 坐标 加上单位元素的高度
        /// </summary>
        private int Bottom
        {
            get
            {
                return Top + GameIni.ElementHeight;
            }
        }

        /// <summary>
        /// 获取人物移动之前左侧的 X 坐标
        /// </summary>
        private int Left
        {
            get { return PreSite.X; }
        }

        /// <summary>
        /// 获取人物移动之前上侧的 Y 坐标
        /// </summary>
        private int Top
        {
            get { return PreSite.Y; }
        }

        /// <summary>
        /// 计算新位置四周的坐标
        /// </summary>
        private void CaculateAroundPos()
        {
            EndPos = Common.GetStation(new Point(NextSite.X + GameIni.ElementWidth, NextSite.Y + GameIni.ElementHeight));

            StartPos = Common.GetStation(new Point(NextSite.X, NextSite.Y));

            RightPos = Common.GetStation(new Point(NextSite.X + GameIni.ElementWidth, NextSite.Y));

            LeftPos = Common.GetStation(new Point(NextSite.X, NextSite.Y + GameIni.ElementHeight));

            //当对象恰巧位于整坐标时，左下，右上，右下坐标均设为左上坐标
            if ((NextSite.Y % GameIni.ElementHeight) == 0)
            {
                EndPos.Row--;
                LeftPos.Row--;
            }

            if ((NextSite.X % GameIni.ElementWidth) == 0)
            {
                EndPos.Col--;
                RightPos.Col--;
            }
        }

        /// <summary>
        /// 计算新位置四周的可通行性
        /// </summary>
        private void CaculateAroundPass()
        {
            StartPassable = MotaWorld.GetInstance().MapManager.IsPassable(StartPos, MoveDirection);
            EndPassable = MotaWorld.GetInstance().MapManager.IsPassable(EndPos, MoveDirection);
            LeftPassable = MotaWorld.GetInstance().MapManager.IsPassable(LeftPos, MoveDirection);
            RightPassable = MotaWorld.GetInstance().MapManager.IsPassable(RightPos, MoveDirection);
        }

        /// <summary>
        /// 获取移动人物的脸距离后方边界的距离(移动前)
        /// </summary>
        private int FaceLine
        {
            get
            {
                //默认的边界
                Size border = new Size(GameIni.MapWidth, GameIni.MapHeight);

                int result = 0;
                switch (MoveDirection)
                {
                    case Direction.Up:
                        result = border.Height - Top;
                        break;
                    case Direction.Down:
                        result = Bottom;
                        break;
                    case Direction.Left:
                        result = border.Width - Left;
                        break;
                    case Direction.Right:
                        result = Right;
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// 获取移动人物移动后的脸面向的位置
        /// </summary>
        private Coord FaceToPos
        {
            get
            {
                Point faceTop = Point.Empty;
                switch (MoveDirection)
                {
                    case Direction.Up:
                        faceTop.X = NextSite.X + Mover.CurFace.Width / 2;
                        faceTop.Y = NextSite.Y;
                        break;
                    case Direction.Down:
                        faceTop.X = NextSite.X + Mover.CurFace.Width / 2;
                        faceTop.Y = NextSite.Y + GameIni.ElementHeight;
                        break;
                    case Direction.Left:
                        faceTop.X = NextSite.X;
                        faceTop.Y = NextSite.Y + GameIni.ElementHeight / 2;
                        break;
                    case Direction.Right:
                        faceTop.X = NextSite.X + Mover.CurFace.Width;
                        faceTop.Y = NextSite.Y + GameIni.ElementHeight / 2;
                        break;
                }

                return Common.GetStation(faceTop);
            }
        }

        /// <summary>
        /// 获取人物前方是否可以通行，如果可以通行(面对的唯一地点是可通行的)，返回true
        /// </summary>
        private bool Passable
        {
            get { return MotaWorld.GetInstance().MapManager.IsPassable(FaceToPos, MoveDirection); }
        }

        /// <summary>
        /// 获取移动人物移动后脸面对的临界线距离后方边界的距离
        /// </summary>
        private int CrisisLine
        {
            get
            {
                //默认的边界
                Size border = new Size(GameIni.MapWidth, GameIni.MapHeight);

                int result = 0;
                switch (MoveDirection)
                {
                    case Direction.Up:
                        result = border.Height - EndPos.Row * GameIni.ElementHeight;
                        break;
                    case Direction.Down:
                        result = EndPos.Row * GameIni.ElementHeight;
                        break;
                    case Direction.Left:
                        result = border.Width - EndPos.Col * GameIni.ElementWidth;
                        break;
                    case Direction.Right:
                        result = EndPos.Col * GameIni.ElementWidth;
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// 获取人物是否临界(靠近障碍物边缘又不可前进)
        /// </summary>
        private bool Critical
        {
            get
            {
                return FaceLine < CrisisLine;  
            }
        }

        /// <summary>
        /// 获取人物前方是否有阻碍，如果无阻碍(前方挡住的两个位置都可通行)，返回true
        /// </summary>
        private bool ObstacleFree
        {
            get
            {
                switch (MoveDirection)
                {
                    case Direction.Up:
                        return StartPassable && RightPassable;
                    case Direction.Down:
                        return LeftPassable && EndPassable;
                    case Direction.Left:
                        return StartPassable && LeftPassable;
                    case Direction.Right:
                        return RightPassable && EndPassable;
                }
                return true;
            }
        }

        /// <summary>
        /// 使人物移动到障碍物的边界线
        /// </summary>
        private Point MoveToCrisisLine()
        {
            int slide = CrisisLine - FaceLine;
            Point result = PreSite;
            switch (MoveDirection)
            {
                case Direction.Up:
                    result.Y -= slide;
                    break;
                case Direction.Down:
                    result.Y += slide;
                    break;
                case Direction.Left:
                    result.X -= slide;
                    break;
                case Direction.Right:
                    result.X += slide;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 使人物滑动一段距离
        /// </summary>
        private Point Slide()
        {
            int slide = this.Mover.Speed / 2;

            Point result = PreSite;
            if (MoveDirection == Direction.Up || MoveDirection == Direction.Down)
            {
                //人物右侧距离右侧地点的距离
                int marginRight = FaceToPos.Col * GameIni.ElementWidth - Left;

                //人物左侧距离左侧地点的距离
                int marginLeft = Right - (FaceToPos.Col + 1) * GameIni.ElementWidth;

                if (marginRight > 0)
                {
                    slide = slide > marginRight ? marginRight : slide;
                    result.X += slide;
                }
                else
                {
                    slide = slide > marginLeft ? marginLeft : slide;
                    result.X -= slide;
                }
            }
            else
            {
                //人物下侧距离下侧地点的距离
                int marginDown = FaceToPos.Row * GameIni.ElementHeight - Top;

                //人物上侧距离上侧地点的距离
                int marginTop = Bottom - (FaceToPos.Row + 1) * GameIni.ElementHeight;

                if (marginDown > 0)
                {
                    slide = slide > marginDown ? marginDown : slide;
                    result.Y += slide;
                }
                else
                {
                    slide = slide > marginTop ? marginTop : slide;
                    result.Y -= slide;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取一个布尔值，标示可移动对象是否可以触发地图事件
        /// </summary>
        private bool CanTrigger
        {
            get
            {
                //这里约定只有勇士有能力触发地图事件
                return this.Mover is Hero;
            }
        }

        /// <summary>
        /// 获取可以触发地图事件的调用者
        /// </summary>
        private Hero Caller
        {
            get
            {
                if (this.Mover is Hero)
                {
                    return this.Mover as Hero;
                }
                else
                {
                    throw new Exception("错误的调用者");
                }
            }
        }

        /// <summary>
        /// 帮助可移动对象移动一个单位的距离，并触发相应的地图事件
        /// </summary>
        public void Move()
        {
            //要计算的最终目标地点
            Point desSite = PreSite;

            //记录之前的坐标，用于与新坐标进行比较
            Coord preStation = this.Mover.Station;

            //如果前方可以通行，直接前进
            if (ObstacleFree)
            {
                desSite = NextSite;
            }
                //如果临界，调整位置使人物走到障碍物的边界而不跨越障碍物
            else if (Critical)
            {
                desSite = MoveToCrisisLine();
            }
                //如果被障碍物遮挡，但前方可以通行，则滑动人物越过障碍物
            else if (Passable)
            {
                desSite = Slide();
            }
                //无法移动，触发事件
            else if(CanTrigger)
            {
                MotaWorld.GetInstance().MapManager.TriggerEvent(FaceToPos, TouchMethod.ImmediatelyTouch, Caller);
            }

            this.Mover.Location = desSite;

            //位置不同时触发新位置上的事件
            if (preStation.CompareTo(this.Mover.Station) != 0 && CanTrigger)
            {
                MotaWorld.GetInstance().MapManager.TriggerEvent(this.Mover.Station, TouchMethod.StationTouch, Caller);
            }
        }

    }
}















