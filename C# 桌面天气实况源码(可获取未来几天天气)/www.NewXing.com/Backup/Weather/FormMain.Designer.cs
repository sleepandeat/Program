namespace Weather
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.PicBox1 = new System.Windows.Forms.PictureBox();
            this.Pic1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.PicBox2 = new System.Windows.Forms.PictureBox();
            this.Pic2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.llbReFlash2 = new Weather.MyLinkLabel();
            this.llbView2 = new Weather.MyLinkLabel();
            this.llbReFlash1 = new Weather.MyLinkLabel();
            this.llbView1 = new Weather.MyLinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic1)).BeginInit();
            this.gb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic2)).BeginInit();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "桌面实时天气";
            this.notifyIcon1.BalloonTipTitle = "桌面实时天气";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "桌面实时天气";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            this.设置SToolStripMenuItem.Click += new System.EventHandler(this.设置SToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.PicBox1);
            this.gb1.Controls.Add(this.Pic1);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.llbReFlash1);
            this.gb1.Controls.Add(this.llbView1);
            this.gb1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb1.Location = new System.Drawing.Point(5, 58);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(213, 186);
            this.gb1.TabIndex = 4;
            this.gb1.TabStop = false;
            this.gb1.Text = "城市1天气情况：";
            // 
            // PicBox1
            // 
            this.PicBox1.ErrorImage = null;
            this.PicBox1.Location = new System.Drawing.Point(163, 50);
            this.PicBox1.Name = "PicBox1";
            this.PicBox1.Size = new System.Drawing.Size(44, 32);
            this.PicBox1.TabIndex = 9;
            this.PicBox1.TabStop = false;
            // 
            // Pic1
            // 
            this.Pic1.ErrorImage = null;
            this.Pic1.Location = new System.Drawing.Point(163, 12);
            this.Pic1.Name = "Pic1";
            this.Pic1.Size = new System.Drawing.Size(44, 32);
            this.Pic1.TabIndex = 7;
            this.Pic1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "未找到数据！";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.PicBox2);
            this.gb2.Controls.Add(this.Pic2);
            this.gb2.Controls.Add(this.label2);
            this.gb2.Controls.Add(this.llbReFlash2);
            this.gb2.Controls.Add(this.llbView2);
            this.gb2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb2.Location = new System.Drawing.Point(224, 58);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(213, 186);
            this.gb2.TabIndex = 5;
            this.gb2.TabStop = false;
            this.gb2.Text = "城市2天气情况：";
            // 
            // PicBox2
            // 
            this.PicBox2.ErrorImage = null;
            this.PicBox2.Location = new System.Drawing.Point(163, 50);
            this.PicBox2.Name = "PicBox2";
            this.PicBox2.Size = new System.Drawing.Size(44, 32);
            this.PicBox2.TabIndex = 9;
            this.PicBox2.TabStop = false;
            // 
            // Pic2
            // 
            this.Pic2.ErrorImage = null;
            this.Pic2.Location = new System.Drawing.Point(163, 12);
            this.Pic2.Name = "Pic2";
            this.Pic2.Size = new System.Drawing.Size(44, 32);
            this.Pic2.TabIndex = 8;
            this.Pic2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "未找到数据！";
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.lblTitle);
            this.gbTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbTitle.Location = new System.Drawing.Point(5, 0);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(432, 52);
            this.gbTitle.TabIndex = 3;
            this.gbTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 12);
            this.lblTitle.TabIndex = 0;
            // 
            // llbReFlash2
            // 
            this.llbReFlash2.AutoSize = true;
            this.llbReFlash2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbReFlash2.Location = new System.Drawing.Point(150, 171);
            this.llbReFlash2.Name = "llbReFlash2";
            this.llbReFlash2.Selectable = false;
            this.llbReFlash2.Size = new System.Drawing.Size(57, 12);
            this.llbReFlash2.TabIndex = 6;
            this.llbReFlash2.TabStop = true;
            this.llbReFlash2.Text = "立即刷新";
            this.llbReFlash2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbReFlash2_LinkClicked);
            this.llbReFlash2.Enter += new System.EventHandler(this.llbView2_Enter);
            // 
            // llbView2
            // 
            this.llbView2.AutoSize = true;
            this.llbView2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbView2.Location = new System.Drawing.Point(6, 171);
            this.llbView2.Name = "llbView2";
            this.llbView2.Selectable = false;
            this.llbView2.Size = new System.Drawing.Size(57, 12);
            this.llbView2.TabIndex = 6;
            this.llbView2.TabStop = true;
            this.llbView2.Text = "查看详情";
            this.llbView2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbView2_LinkClicked);
            this.llbView2.Enter += new System.EventHandler(this.llbView2_Enter);
            // 
            // llbReFlash1
            // 
            this.llbReFlash1.AutoSize = true;
            this.llbReFlash1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbReFlash1.Location = new System.Drawing.Point(150, 171);
            this.llbReFlash1.Name = "llbReFlash1";
            this.llbReFlash1.Selectable = false;
            this.llbReFlash1.Size = new System.Drawing.Size(57, 12);
            this.llbReFlash1.TabIndex = 6;
            this.llbReFlash1.TabStop = true;
            this.llbReFlash1.Text = "立即刷新";
            this.llbReFlash1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbReFlash1_LinkClicked);
            this.llbReFlash1.Enter += new System.EventHandler(this.llbView1_Enter);
            // 
            // llbView1
            // 
            this.llbView1.AutoSize = true;
            this.llbView1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbView1.Location = new System.Drawing.Point(6, 171);
            this.llbView1.Name = "llbView1";
            this.llbView1.Selectable = false;
            this.llbView1.Size = new System.Drawing.Size(57, 12);
            this.llbView1.TabIndex = 6;
            this.llbView1.TabStop = true;
            this.llbView1.Text = "查看详情";
            this.llbView1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbView1_LinkClicked);
            this.llbView1.Enter += new System.EventHandler(this.llbView1_Enter);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(442, 250);
            this.Controls.Add(this.gbTitle);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "桌面实时天气";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic1)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic2)).EndInit();
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Label label2;
        private MyLinkLabel llbView1;
        private MyLinkLabel llbView2;
        private MyLinkLabel llbReFlash1;
        private MyLinkLabel llbReFlash2;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.PictureBox Pic1;
        private System.Windows.Forms.PictureBox Pic2;
        private System.Windows.Forms.PictureBox PicBox1;
        private System.Windows.Forms.PictureBox PicBox2;
    }
}

