using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 魔王的试炼
{
    public partial class FrmEdit : Form
    {
        /// <summary>
        /// 以待编辑的元素坐标创建窗口
        /// </summary>
        public FrmEdit(Coord editPos)
        {
            InitializeComponent();

            this.CurPosation = editPos;
            this.content.Text = MotaWorld.GetInstance().MapManager.GetNodeString(editPos);
        }

        /// <summary>
        /// 获取或设置正在编辑的元素坐标
        /// </summary>
        public Coord CurPosation { get; set; }

        /// <summary>
        /// 获取编辑内容
        /// </summary>
        public string EditContent
        {
            get
            {
                return this.content.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
















