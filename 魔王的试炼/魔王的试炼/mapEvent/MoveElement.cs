using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 可移动类，包含移动时的事件触发
    /// </summary>
    abstract class MoveElement : MapEvent
    {
        /// <summary>
        /// 以一定的移动速度创建可移动元素对象
        /// </summary>
        /// <param name="fileName">移动对象的图像文件</param>
        /// <param name="pos">可移动对象的初始位置</param>
        /// <param name="name">移动对象名称</param>
        /// <param name="unitSize">图像分割的单位尺寸</param>
        public MoveElement(string fileName, Coord pos, string name, Size unitSize)
            :base(fileName, pos, TouchMethod.ImmediatelyTouch, true, name, unitSize)
        {
            this.Speed = GameIni.IniHeroSpeed;

            MoveDirection = Direction.No;
        }

        /// <summary>
        /// 以一定的移动速度创建可移动元素对象
        /// </summary>
        /// <param name="faceIndex">移动对象的图像索引</param>
        /// <param name="pos">可移动对象的初始位置</param>
        /// <param name="name">移动对象名称</param>
        public MoveElement(MotaElement faceIndex, Coord pos, string name)
            : base(faceIndex, pos, TouchMethod.ImmediatelyTouch, true, name)
        {
            this.Speed = GameIni.IniHeroSpeed;

            MoveDirection = Direction.No;
        }


        /// <summary>
        /// 获取或设置移动对象的移动速度(每移动一次的单位距离)
        /// </summary>
        public virtual int Speed { get; set; }

        /// <summary>
        /// 获取或设置是否执行自动移动
        /// </summary>
        protected bool AutoMove { get; set; }

        private Direction moveDirection;
        /// <summary>
        /// 获取或设置元素的移动方向
        /// </summary>
        public Direction MoveDirection
        {
            set { moveDirection = value; }
            get 
            {
                //如果自动移动开启，从方向队列中获取方向自动移动
                if (AutoMove)
                {
                    return AutoPath.CurPathDiection;
                }
                else
                {
                    return moveDirection;
                }
            }
        }

        /// <summary>
        /// 自动移动的路径
        /// </summary>
        protected Path AutoPath = new Path(null);

        /// <summary>
        /// 获取一个布尔值，标示是否达到目标位置
        /// </summary>
        private bool Reached
        {
            get
            {
                if (!AutoMove)
                {
                    return false;
                }
                
                switch (MoveDirection)
                {
                    case Direction.Up:
                        return Location.Y <= AutoPath.TargetPos.Row * GameIni.ElementHeight;
                    case Direction.Down:
                        return Location.Y >= AutoPath.TargetPos.Row * GameIni.ElementHeight;
                    case Direction.Left:
                        return Location.X <= AutoPath.TargetPos.Col * GameIni.ElementWidth;
                    case Direction.Right:
                        return Location.X >= AutoPath.TargetPos.Col * GameIni.ElementWidth;
                }

                return false;
            }
        }

        /// <summary>
        /// 停止智能移动
        /// </summary>
        protected virtual void StopAutoMove()
        {
            if (AutoMove)
            {
                AutoMove = false;
                Stop(AutoPath.CurPathDiection);
                AutoPath.ClearPath();
            }
        }

        /// <summary>
        /// 设置方向,开始行走
        /// </summary>
        public void StartMove(Direction way) 
        {
            StopAutoMove();

            MoveDirection = way;
        }

        /// <summary>
        /// 通过设置移动方向为无使元素停止行走
        /// </summary>
        public void StopMove(Direction way) 
        {
            //如果释放键的时候的方向与原方向一致，则运动停止
            if (way == MoveDirection)
            {
                Stop(way);
            }
        }
        
        /// <summary>
        /// 停止移动
        /// </summary>
        /// <param name="faceTo">脸面对的方向</param>
        protected virtual void Stop(Direction faceTo)
        {
            this.MoveDirection = Direction.No;
        }

        /// <summary>
        /// 移动一个单位距离,具有平滑移动的效果
        /// </summary>
        public virtual void Move()
        {
            if (MoveDirection == Direction.No)
            {
                return;
            }

            //委托移动帮助类完成移动对象的移动
            new MoveHelper(this).Move();

            //如果新的位置不可通行，终止自动移动
            if (AutoMove && !AutoPath.PassableIn(MotaWorld.GetInstance().MapManager.CurFloorNode))
            {
                StopAutoMove();
            }

            //如果抵达自动移动的目标位置，选取新的方向继续自动移动
            if (Reached)
            {
                AutoPath.NextPos();
                if (!AutoPath.ExistPath)
                {
                    StopAutoMove();
                }
            }
        }

        /// <summary>
        /// 获取或设置可移动对象在地图中的位置(中心位置)
        /// </summary>
        public Coord Station
        {
            get
            {
                return Common.GetStation(new Point(Location.X + CurFace.Width / 2, Location.Y + CurFace.Height / 2));
            }
            set
            {
                Location = new Point(value.Col * GameIni.ElementWidth, value.Row * GameIni.ElementHeight);
            }
        }

        /// <summary>
        /// 重写人物图像播放，实现移动
        /// </summary>
        protected override void PlayFace()
        {
            base.PlayFace();

            Move();
        }

        /// <summary>
        /// 使人物移动到当前楼层中指定的位置
        /// </summary>
        /// <param name="pos">目标位置</param>
        public virtual void MoveTo(Coord pos)
        {
            //委托楼层类计算当前楼层的最短路径
            AutoPath.SetPath(MotaWorld.GetInstance().MapManager.CurFloorNode.GetPath(this.Station, pos));

            //初始化目标位置
            AutoPath.NextPos();

            if (AutoPath.ExistPath)
            {
                AutoMove = true;
            }
        }
    }
}








