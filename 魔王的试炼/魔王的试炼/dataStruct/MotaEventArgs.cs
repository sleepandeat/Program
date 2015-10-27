using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔事件参数类
    /// </summary>
    class MotaEventArgs : EventArgs
    {
        /// <summary>
        /// 以作用值创建魔塔事件参数实例
        /// </summary>
        /// <param name="value">主作用数值</param>
        public MotaEventArgs(int value, EffectType type = EffectType.Default)
        {
            this.Value = value;
            Method = type;
        }

        /// <summary>
        /// 以获取的道具名称和作用值创建魔塔事件参数实例
        /// </summary>
        /// <param name="name">道具名称</param>
        /// <param name="value">主影响值</param>
        public MotaEventArgs(PropName name, EffectType type = EffectType.Default, int value = 1)
        {
            this.Prop = name;
            this.Value = value;
            Method = type;
        }

        /// <summary>
        /// 以作用的音效类型创建魔塔事件参数实例
        /// </summary>
        /// <param name="value">主作用音效</param>
        public MotaEventArgs(SoundType sound, EffectType type = EffectType.Default)
        {
            this.Sound = sound;
            Method = type;
        }

        /// <summary>
        /// 以作用比率创建魔塔事件参数实例
        /// </summary>
        /// <param name="value">主作用数值</param>
        public MotaEventArgs(double rate, EffectType type = EffectType.Default)
        {
            this.Rate = rate;
            Method = type;
        }

        /// <summary>
        /// 以作用字符串创建魔塔事件参数实例
        /// </summary>
        /// <param name="dialogue">对话数组</param>
        public MotaEventArgs(Dialogue[] dialogue, EffectType type = EffectType.Default)
        {
            this.Messages = dialogue;
            Method = type;
        }

        /// <summary>
        /// 以作用目标位置创建魔塔事件参数实例
        /// </summary>
        /// <param name="desPosation">主作用目标位置</param>
        public MotaEventArgs(Posation desPosation, EffectType type = EffectType.Default)
        {
            this.DesPosation = desPosation;
            Method = type;
        }

        /// <summary>
        /// 创建空参数类
        /// </summary>
        public MotaEventArgs() { Method = EffectType.Default; }

        /// <summary>
        /// 获取或设置参数主作用数值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 获取或设置参数作用比率
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// 获取或设置参数的对话信息
        /// </summary>
        public Dialogue[] Messages { get; set; }

        /// <summary>
        /// 获取或设置事件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置主作用的目标位置
        /// </summary>
        public Posation DesPosation { get; set; }

        /// <summary>
        /// 获取或设置事件出现的位置
        /// </summary>
        public Coord ExistStation { get; set; }

        /// <summary>
        /// 获取或设置游戏音效
        /// </summary>
        public SoundType Sound { get; set; }

        /// <summary>
        /// 获取或设置事件类型
        /// </summary>
        public EffectType Method { get; set; }

        /// <summary>
        /// 获取或设置道具名称
        /// </summary>
        public PropName Prop { get; set; }

    }
}










