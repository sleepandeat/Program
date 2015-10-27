using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 可以被推动的箱子
    /// </summary>
    class Box : MoveElement
    {
        /// <summary>
        /// 创建箱子的新实例
        /// </summary>
        /// <param name="pos">箱子出现在地图上的坐标</param>
        /// <param name="name">箱子名称</param>
        private Box(Coord pos, string name = "箱子")
            : base(MotaElement.箱子, pos, name)
        {
            Speed = 5;
        }

        /// <summary>
        /// 箱子的移动次数计数
        /// </summary>
        private int MoveCount = GameIni.BoxMoveTimes;

        /// <summary>
        /// 箱子力气的积攒
        /// </summary>
        private int PushWaitCount = 0;

        /// <summary>
        /// 触发推箱子事件
        /// </summary>
        /// <param name="player">触发者</param>
        public override void TriggerEvent(Hero player)
        {
            //要推到的坐标
            Coord desPoint = this.Station;
            desPoint.Offset(player.FaceTo);

            PushWaitCount++;
            if (PushWaitCount <= GameIni.BoxPushWait)
            {
                return;
            }

            //如果箱子的前方为空，则推动那个位置
            if (MotaWorld.GetInstance().MapManager.ShiftEvent(this.Station, desPoint, player.FaceTo))
            {
                StartMove(player.FaceTo);
                SoundsList.PlaySound(SoundType.推箱子);
                this.MoveCount -= GameIni.BoxMoveTimes;
            }

            base.TriggerEvent(player);
        }

        protected override bool CanRefresh
        {
            get
            {
                return base.CanRefresh && MoveDirection != Direction.No;
            }
        }

        /// <summary>
        /// 移动箱子
        /// </summary>
        public override void Move()
        {
            //达到一定距离自动停止箱子移动
            MoveCount++;
            if (MoveCount > GameIni.BoxMoveTimes)
            {
                StopMove(MoveDirection);
                return;
            }

            //直接移动，不检测通向性
            this.Location = (new MoveHelper(this).NextSite);
        }

        /// <summary>
        /// 箱子停止移动
        /// </summary>
        protected override void Stop(Direction faceTo)
        {
            base.Stop(faceTo);

            MoveCount = GameIni.BoxMoveTimes;
            this.PushWaitCount = 0;
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Box; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            string name = createArgs.Attribute("eventName").Value;
            
            return new Box(existCoord, name);
        }

        protected override void SaveTypeTo(XElement eventType)
        {

        }
    }
}




