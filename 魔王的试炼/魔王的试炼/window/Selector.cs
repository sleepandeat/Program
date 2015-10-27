using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏的选择器窗口
    /// </summary>
    abstract class Selector : GameWindow
    {
        /// <summary>
        /// 创建窗口实例
        /// </summary>
        /// <param name="width">窗口宽度</param>
        /// <param name="height">窗口高度</param>
        public Selector(int width, int height) : base(width, height)
        {
            RemoveAllOptions();
        }

        /// <summary>
        /// 重写基类方法，每次刷新时不重新绘制图形
        /// </summary>
        public override void NextFrame() { }

        /// <summary>
        /// 选项列表
        /// </summary>
        protected List<Option> Options = new List<Option>(0);

        /// <summary>
        /// 移除所有现有选项
        /// </summary>
        public void RemoveAllOptions() { Options.Clear(); }

        /// <summary>
        /// 被选中之后触发的事件
        /// </summary>
        protected virtual void OnSelected()
        {
            SelectSound();

            //立即重绘控件
            ReDraw();
        }

        /// <summary>
        /// 被选中之后的效果音
        /// </summary>
        protected virtual void SelectSound()
        {
            SoundsList.PlaySound(SoundType.选择);
        }

        /// <summary>
        /// 为选择器添加选项
        /// </summary>
        /// <param name="option">选项</param>
        public virtual void AddOption(Option option)
        { 
            Options.Add(option);
        }

        /// <summary>
        /// 选项选项,如果选项不存在，没有影响
        /// </summary>
        /// <param name="index">选项索引值</param>
        /// <returns>返回是否选择成功，如果选项不可选中，返回false</returns>
        protected bool Select(int index)
        {
            if (index < 0 || index >= Options.Count)
            {
                return false;
            }

            //如果新选项选择成功，取消之前的选项
            if (Options[index].CanSelect)
            {
                Options[selectedIndex].Selected = false;
                Options[index].Selected = true;
                selectedIndex = index;

                OnSelected();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 初始化选项
        /// </summary>
        /// <param name="data">选项索引，默认为0</param>
        public override void Open(object data)
        {
            int index;
            if (data == null)
            {
                index = 0;
            }
            else
            {
                index = (int)data;
            }

            Options[index].Selected = true;
            selectedIndex = index;
            Enable = true;

            ReDraw();
        }

        /// <summary>
        /// 选项确定
        /// </summary>
        public void Enter()
        {
            if (!Enable)
            {
                return;
            }

            if (Options[SelectedIndex].Selected)
            {
                EnterSound();

                Options[SelectedIndex].onTrigger();
            }   
        }

        /// <summary>
        /// 触发后的效果音
        /// </summary>
        protected virtual void EnterSound()
        {
            SoundsList.PlaySound(SoundType.确认选择);
        }

        /// <summary>
        /// 选择下一项,如果下一项不可选择，则继续选择下一项,如果下面没有可供选择的选项，
        /// 则返回第一个选项重新选择.
        /// </summary>
        public void NextItem()
        {
            if (!Enable)
            {
                return;
            }

            int preIndex = selectedIndex;
            int curIndex = selectedIndex;
            while (!Select(++curIndex))
            {
                //回到起始点则退出循序，防止死循环
                if (curIndex == preIndex)
                {
                    break;
                }

                if (curIndex >= Options.Count)
                {
                    curIndex = -1;
                }
            }
        }

        /// <summary>
        /// 选择上一项,如果上一项不可选择，则继续选择上一项,如果上面没有可供选择的选项，
        /// 则返回最后一个选项重新选择.
        /// </summary>
        public void PreItem()
        {
            if (!Enable)
            {
                return;
            }

            int preIndex = selectedIndex;
            int curIndex = selectedIndex;
            while (!Select(--curIndex))
            {
                //回到起始点则退出循序，防止死循环
                if (curIndex == preIndex)
                {
                    break;
                }

                if (curIndex < 0)
                {
                    curIndex = Options.Count;
                }
            }
        }

        private int selectedIndex = 0;
        /// <summary>
        /// 获取或设置被选中项的索引,不保证一定会选中
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                Select(value);
            }
        }

        /// <summary>
        /// 处理按键进行上下选择
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (Enable)
            {
                //如果窗口有效，则捕获按键
                if (code == System.Windows.Forms.Keys.Up)
                {
                    PreItem();
                }
                else if (code == System.Windows.Forms.Keys.Down)
                {
                    NextItem();
                }
                else if (code == System.Windows.Forms.Keys.Enter)
                {
                    this.Enter();
                }
                return true;
            }

            return false;
        }


    }


    

}




