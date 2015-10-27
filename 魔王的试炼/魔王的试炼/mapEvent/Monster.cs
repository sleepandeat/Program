using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 怪物类
    /// </summary>
    sealed class Monster : Character
    {
        /// <summary>
        /// 创建怪物的新实例
        /// </summary>
        /// <param name="showPos">怪物在地图上的坐标</param>
        /// <param name="data">怪物属性</param>
        /// <param name="unitSize">怪物图像分割的单位尺寸</param>
        private Monster(Coord showPos, CharacterArgs data, Size unitSize)
            : base(showPos, data, false, unitSize)
        {
            CanBattle = true;
        }

        /// <summary>
        /// 触发战斗事件
        /// </summary>
        /// <param name="player">触发者</param>
        public override void TriggerEvent(Hero player)
        {
            //如果可以战斗，打开战斗窗口
            if (CanBattle && !(this.HarmTo(player) == int.MaxValue && player.Level < this.Level))
            {
                IFighter[] fighters = new IFighter[2];
                fighters[0] = player;
                fighters[1] = this;

                //以战斗的双方作为参数开启战斗窗口
                MotaWorld.GetInstance().BattleWindow.Open(fighters);
            }
            else
            {
                //无法战斗
                MotaWorld.GetInstance().MessageShowWindow.Open("攻击力不足，无法与这只怪物战斗！");
                SoundsList.PlaySound(SoundType.错误);
            }

            base.TriggerEvent(player);
        }

        public override void MoveTo(Coord pos)
        {
            base.MoveTo(pos);
            
            //开始移动反应
            MotaWorld.GetInstance().CurHero.WaitMonsters++;
        }

        /// <summary>
        /// 自动移动停止时方法
        /// </summary>
        protected override void StopAutoMove()
        {
            if (base.AutoMove)
            {
                //移动物理位置
                MotaWorld.GetInstance().MapManager.ShiftEvent(base.AutoPath.StartPos, base.AutoPath.EndTargetPos, base.AutoPath.EndDrection);
            }

            base.StopAutoMove();

            //反应结束
            MotaWorld.GetInstance().CurHero.WaitMonsters--;
        }

        /// <summary>
        /// 获取类型码
        /// </summary>
        public override EventType TypeCode
        {
            get { return EventType.Monster; }
        }

        /// <summary>
        /// 根据参数配置创建类的实例
        /// </summary>
        /// <param name="createArgs">参数配置</param>
        /// <returns>返回类实例</returns>
        public static MapEvent Create(XElement createArgs, Coord existCoord)
        {
            CharacterArgs data = CharacterArgs.CreateFrom(createArgs);

            string fileName = data.FaceFile;
            Size unitSize = GetSize(createArgs.Attribute("unitSize").Value);

            return new Monster(existCoord, data, unitSize);
        }
    }
}










