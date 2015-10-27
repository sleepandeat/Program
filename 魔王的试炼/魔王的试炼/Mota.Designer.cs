namespace 魔王的试炼
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.GameSelectWindow = new System.Windows.Forms.PictureBox();
            this.GameState = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PlayerAgility = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PlayerMagic = new System.Windows.Forms.Label();
            this.PlayerExp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerLives = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PlayerLevel = new System.Windows.Forms.Label();
            this.PlayerDefence = new System.Windows.Forms.Label();
            this.PlayerCoins = new System.Windows.Forms.Label();
            this.PlayerAttack = new System.Windows.Forms.Label();
            this.lblFloor = new System.Windows.Forms.Label();
            this.PropPack = new System.Windows.Forms.PictureBox();
            this.MotaScene = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.剪贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GameSelectWindow)).BeginInit();
            this.GameState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotaScene)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameSelectWindow
            // 
            this.GameSelectWindow.BackColor = System.Drawing.Color.Transparent;
            this.GameSelectWindow.Location = new System.Drawing.Point(335, 245);
            this.GameSelectWindow.Name = "GameSelectWindow";
            this.GameSelectWindow.Size = new System.Drawing.Size(186, 232);
            this.GameSelectWindow.TabIndex = 0;
            this.GameSelectWindow.TabStop = false;
            this.GameSelectWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.GameSelectWindow_Paint);
            // 
            // GameState
            // 
            this.GameState.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameState.BackgroundImage")));
            this.GameState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameState.Controls.Add(this.label11);
            this.GameState.Controls.Add(this.label8);
            this.GameState.Controls.Add(this.label9);
            this.GameState.Controls.Add(this.PlayerAgility);
            this.GameState.Controls.Add(this.label12);
            this.GameState.Controls.Add(this.PlayerMagic);
            this.GameState.Controls.Add(this.PlayerExp);
            this.GameState.Controls.Add(this.label5);
            this.GameState.Controls.Add(this.label4);
            this.GameState.Controls.Add(this.label3);
            this.GameState.Controls.Add(this.label1);
            this.GameState.Controls.Add(this.PlayerLives);
            this.GameState.Controls.Add(this.label7);
            this.GameState.Controls.Add(this.PlayerLevel);
            this.GameState.Controls.Add(this.PlayerDefence);
            this.GameState.Controls.Add(this.PlayerCoins);
            this.GameState.Controls.Add(this.PlayerAttack);
            this.GameState.Controls.Add(this.lblFloor);
            this.GameState.Controls.Add(this.PropPack);
            this.GameState.Location = new System.Drawing.Point(0, 0);
            this.GameState.Name = "GameState";
            this.GameState.Size = new System.Drawing.Size(212, 520);
            this.GameState.TabIndex = 2;
            this.GameState.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(15, 461);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 50);
            this.label11.TabIndex = 41;
            this.label11.Text = "存档: S          读档: R\r\n重新开始: E    退出游戏: Esc";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(118, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 25);
            this.label8.TabIndex = 37;
            this.label8.Text = "经验";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(118, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 25);
            this.label9.TabIndex = 36;
            this.label9.Text = "魔法";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerAgility
            // 
            this.PlayerAgility.BackColor = System.Drawing.Color.Transparent;
            this.PlayerAgility.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerAgility.ForeColor = System.Drawing.Color.White;
            this.PlayerAgility.Location = new System.Drawing.Point(155, 130);
            this.PlayerAgility.Name = "PlayerAgility";
            this.PlayerAgility.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerAgility.Size = new System.Drawing.Size(43, 25);
            this.PlayerAgility.TabIndex = 34;
            this.PlayerAgility.Text = "0";
            this.PlayerAgility.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(118, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 25);
            this.label12.TabIndex = 33;
            this.label12.Text = "敏捷";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerMagic
            // 
            this.PlayerMagic.BackColor = System.Drawing.Color.Transparent;
            this.PlayerMagic.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerMagic.ForeColor = System.Drawing.Color.White;
            this.PlayerMagic.Location = new System.Drawing.Point(155, 169);
            this.PlayerMagic.Name = "PlayerMagic";
            this.PlayerMagic.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerMagic.Size = new System.Drawing.Size(43, 25);
            this.PlayerMagic.TabIndex = 31;
            this.PlayerMagic.Text = "0";
            this.PlayerMagic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerExp
            // 
            this.PlayerExp.BackColor = System.Drawing.Color.Transparent;
            this.PlayerExp.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerExp.ForeColor = System.Drawing.Color.White;
            this.PlayerExp.Location = new System.Drawing.Point(155, 208);
            this.PlayerExp.Name = "PlayerExp";
            this.PlayerExp.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerExp.Size = new System.Drawing.Size(43, 25);
            this.PlayerExp.TabIndex = 30;
            this.PlayerExp.Text = "0";
            this.PlayerExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "攻击";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "金币";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "防御";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "等级";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerLives
            // 
            this.PlayerLives.BackColor = System.Drawing.Color.Transparent;
            this.PlayerLives.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerLives.ForeColor = System.Drawing.Color.White;
            this.PlayerLives.Location = new System.Drawing.Point(56, 91);
            this.PlayerLives.Name = "PlayerLives";
            this.PlayerLives.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerLives.Size = new System.Drawing.Size(94, 25);
            this.PlayerLives.TabIndex = 23;
            this.PlayerLives.Text = "1000";
            this.PlayerLives.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "生命";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerLevel
            // 
            this.PlayerLevel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerLevel.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerLevel.ForeColor = System.Drawing.Color.White;
            this.PlayerLevel.Location = new System.Drawing.Point(56, 53);
            this.PlayerLevel.Name = "PlayerLevel";
            this.PlayerLevel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerLevel.Size = new System.Drawing.Size(59, 25);
            this.PlayerLevel.TabIndex = 21;
            this.PlayerLevel.Text = "1";
            this.PlayerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerDefence
            // 
            this.PlayerDefence.BackColor = System.Drawing.Color.Transparent;
            this.PlayerDefence.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerDefence.ForeColor = System.Drawing.Color.White;
            this.PlayerDefence.Location = new System.Drawing.Point(56, 170);
            this.PlayerDefence.Name = "PlayerDefence";
            this.PlayerDefence.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerDefence.Size = new System.Drawing.Size(59, 25);
            this.PlayerDefence.TabIndex = 20;
            this.PlayerDefence.Text = "10";
            this.PlayerDefence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerCoins
            // 
            this.PlayerCoins.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCoins.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerCoins.ForeColor = System.Drawing.Color.White;
            this.PlayerCoins.Location = new System.Drawing.Point(56, 209);
            this.PlayerCoins.Name = "PlayerCoins";
            this.PlayerCoins.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerCoins.Size = new System.Drawing.Size(59, 25);
            this.PlayerCoins.TabIndex = 19;
            this.PlayerCoins.Text = "0";
            this.PlayerCoins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerAttack
            // 
            this.PlayerAttack.BackColor = System.Drawing.Color.Transparent;
            this.PlayerAttack.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayerAttack.ForeColor = System.Drawing.Color.White;
            this.PlayerAttack.Location = new System.Drawing.Point(56, 130);
            this.PlayerAttack.Name = "PlayerAttack";
            this.PlayerAttack.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.PlayerAttack.Size = new System.Drawing.Size(59, 25);
            this.PlayerAttack.TabIndex = 16;
            this.PlayerAttack.Text = "10";
            this.PlayerAttack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.BackColor = System.Drawing.Color.Transparent;
            this.lblFloor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFloor.ForeColor = System.Drawing.Color.White;
            this.lblFloor.Location = new System.Drawing.Point(49, 14);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(115, 21);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "魔 塔 - 第 1 层";
            // 
            // PropPack
            // 
            this.PropPack.BackgroundImage = global::魔王的试炼.Properties.Resources.地面;
            this.PropPack.Location = new System.Drawing.Point(15, 244);
            this.PropPack.Name = "PropPack";
            this.PropPack.Size = new System.Drawing.Size(180, 210);
            this.PropPack.TabIndex = 0;
            this.PropPack.TabStop = false;
            this.PropPack.Paint += new System.Windows.Forms.PaintEventHandler(this.PropPack_Paint);
            // 
            // MotaScene
            // 
            this.MotaScene.Location = new System.Drawing.Point(212, 0);
            this.MotaScene.Name = "MotaScene";
            this.MotaScene.Size = new System.Drawing.Size(680, 520);
            this.MotaScene.TabIndex = 3;
            this.MotaScene.TabStop = false;
            this.MotaScene.Visible = false;
            this.MotaScene.Paint += new System.Windows.Forms.PaintEventHandler(this.MotaScene_Paint);
            this.MotaScene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MotaScene_MouseClick);
            this.MotaScene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MotaScene_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.剪贴ToolStripMenuItem,
            this.Copy,
            this.Paste,
            this.Delete,
            this.编辑ToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.ShowImageMargin = false;
            this.cmsMenu.Size = new System.Drawing.Size(121, 114);
            // 
            // 剪贴ToolStripMenuItem
            // 
            this.剪贴ToolStripMenuItem.Name = "剪贴ToolStripMenuItem";
            this.剪贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪贴ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.剪贴ToolStripMenuItem.Text = "剪贴";
            this.剪贴ToolStripMenuItem.Click += new System.EventHandler(this.剪贴ToolStripMenuItem_Click);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.ShortcutKeyDisplayString = "";
            this.Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy.Size = new System.Drawing.Size(120, 22);
            this.Copy.Text = "复制";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            this.Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Paste.Size = new System.Drawing.Size(120, 22);
            this.Paste.Text = "粘贴";
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.ShortcutKeyDisplayString = "Del";
            this.Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.Delete.Size = new System.Drawing.Size(120, 22);
            this.Delete.Text = "删除";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(892, 520);
            this.Controls.Add(this.MotaScene);
            this.Controls.Add(this.GameState);
            this.Controls.Add(this.GameSelectWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔王的试炼";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.GameSelectWindow)).EndInit();
            this.GameState.ResumeLayout(false);
            this.GameState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotaScene)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameSelectWindow;
        private System.Windows.Forms.Panel GameState;
        private System.Windows.Forms.Label PlayerDefence;
        private System.Windows.Forms.Label PlayerCoins;
        private System.Windows.Forms.Label PlayerAttack;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.PictureBox PropPack;
        private System.Windows.Forms.Label PlayerLevel;
        private System.Windows.Forms.Label PlayerLives;
        private System.Windows.Forms.PictureBox MotaScene;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label PlayerAgility;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label PlayerMagic;
        private System.Windows.Forms.Label PlayerExp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.ToolStripMenuItem 剪贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;


    }
}

