using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 选项类
    /// </summary>
    abstract class Option
    {
        /// <summary>
        /// 创建选项实例
        /// </summary>
        /// <param name="name">选项名称</param>
        /// <param name="valid">是否有效(可以被选中)</param>
        public Option(string name, bool valid = true)
        {
            Name = name;
            CanSelect = valid;
        }

        /// <summary>
        /// 获取或设置选项名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 触发选项的事件
        /// </summary>
        public event EventHandler TriggerEvent = null;

        private bool selected = false;
        /// <summary>
        /// 获取或设置选项是否被选中
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (!CanSelect)
                {
                    return;
                }

                selected = value;
            }
        }

        /// <summary>
        /// 获取或设置选项是否允许选中
        /// </summary>
        public bool CanSelect { get; set; }

        /// <summary>
        /// 触发选项引起TriggerEvent事件
        /// </summary>
        public virtual void onTrigger()
        {
            if (Selected &&  TriggerEvent != null)
            {
                TriggerEvent(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 绘制选项文字到画布
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="startPoint">起始位置</param>
        public abstract void Draw(Graphics g, Point startPoint);
        
    }
}
