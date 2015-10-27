using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 可以展示在怪物手册上的接口, 用于被可战斗接口继承
    /// </summary>
    interface ICanShowData : IComparable
    {
        /// <summary>
        /// 获取怪物展示在怪物手册上的图像
        /// </summary>
        Bitmap Icon { get; }

        /// <summary>
        /// 获取怪物id
        /// </summary>
        int MonsterId { get; }

        /// <summary>
        /// 获取怪物的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取怪物的生命值
        /// </summary>
        int Hp { get; }

        /// <summary>
        /// 获取怪物的攻击力
        /// </summary>
        int Attack { get; }

        /// <summary>
        /// 获取怪物的防御力
        /// </summary>
        int Defence { get; }

        /// <summary>
        /// 获取怪物的敏捷
        /// </summary>
        int Agility { get; }

        /// <summary>
        /// 获取怪物的魔法
        /// </summary>
        int Magic { get; }

        /// <summary>
        /// 获取怪物的金币
        /// </summary>
        int Coin { get; }

        /// <summary>
        /// 获取怪物的经验
        /// </summary>
        int Exp { get; }

        /// <summary>
        /// 获取怪物的等级
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 获取怪物的简介
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 帧数改变触发的事件
        /// </summary>
        event EventHandler FrameChangeEvent;

        /// <summary>
        /// 获取与目标对战的预测伤害
        /// </summary>
        /// <param name="target">对战目标, 主动攻击方</param>
        /// <returns>预测伤害</returns>
        int HarmTo(ICanShowData target);

        /// <summary>
        /// 获取怪物图像左上角在地图窗口中出现的位置和尺寸
        /// </summary>
        Rectangle ExistRectangle { get; }

        /// <summary>
        /// 设置怪物是否被选中(被选中用于侦测属性)
        /// </summary>
        bool Selected { set; }
    }
}






