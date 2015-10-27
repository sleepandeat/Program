using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 交易选项
    /// </summary>
    class DealOption : Option
    {
        /// <summary>
        /// 创建交易选项实例
        /// </summary>
        /// <param name="name">选项名称</param>
        public DealOption(DealArgs deal)
            : base(deal.DealName, true)
        {
            OnePiece = deal;
        }

        /// <summary>
        /// 创建交易关闭项
        /// </summary>
        public DealOption(string describe) : base(describe, true) { this.OnePiece = null; }

        /// <summary>
        /// 交易参数
        /// </summary>
        public DealArgs OnePiece;

        public override void Draw(Graphics g, Point startPoint)
        {
            Color strColor = Selected ? Color.Red : Color.Black;

            if (CanSelect)
            {
                g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 13, FontStyle.Regular), new SolidBrush(strColor), startPoint);
            }
            else
            {
                g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 13, FontStyle.Regular), new SolidBrush(strColor), startPoint);
            }
        }
    }
}











