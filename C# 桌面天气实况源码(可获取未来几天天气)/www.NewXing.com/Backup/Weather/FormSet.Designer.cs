namespace Weather
{
    partial class FormSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.cmbCounty = new System.Windows.Forms.ComboBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbProvince2 = new System.Windows.Forms.ComboBox();
            this.cmbCounty2 = new System.Windows.Forms.ComboBox();
            this.cmbCity2 = new System.Windows.Forms.ComboBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnView1 = new System.Windows.Forms.Button();
            this.cbCity1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnView2 = new System.Windows.Forms.Button();
            this.cbCity2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFrameColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFontColor = new System.Windows.Forms.ComboBox();
            this.chkReFlash = new System.Windows.Forms.CheckBox();
            this.txtReFlash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPinToDeskTop = new System.Windows.Forms.CheckBox();
            this.btnReGetCityList = new System.Windows.Forms.Button();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProvince
            // 
            this.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince.Enabled = false;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Location = new System.Drawing.Point(6, 20);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(88, 20);
            this.cmbProvince.TabIndex = 6;
            this.cmbProvince.SelectedIndexChanged += new System.EventHandler(this.cmbProvince_SelectedIndexChanged);
            // 
            // cmbCounty
            // 
            this.cmbCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty.Enabled = false;
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Location = new System.Drawing.Point(6, 72);
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(88, 20);
            this.cmbCounty.TabIndex = 5;
            this.cmbCounty.SelectedIndexChanged += new System.EventHandler(this.cmbCounty_SelectedIndexChanged);
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Enabled = false;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(6, 46);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(88, 20);
            this.cmbCity.TabIndex = 4;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // cmbProvince2
            // 
            this.cmbProvince2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvince2.Enabled = false;
            this.cmbProvince2.FormattingEnabled = true;
            this.cmbProvince2.Location = new System.Drawing.Point(6, 20);
            this.cmbProvince2.Name = "cmbProvince2";
            this.cmbProvince2.Size = new System.Drawing.Size(88, 20);
            this.cmbProvince2.TabIndex = 10;
            this.cmbProvince2.SelectedIndexChanged += new System.EventHandler(this.cmbProvince2_SelectedIndexChanged);
            // 
            // cmbCounty2
            // 
            this.cmbCounty2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty2.Enabled = false;
            this.cmbCounty2.FormattingEnabled = true;
            this.cmbCounty2.Location = new System.Drawing.Point(6, 72);
            this.cmbCounty2.Name = "cmbCounty2";
            this.cmbCounty2.Size = new System.Drawing.Size(88, 20);
            this.cmbCounty2.TabIndex = 9;
            this.cmbCounty2.SelectedIndexChanged += new System.EventHandler(this.cmbCounty2_SelectedIndexChanged);
            // 
            // cmbCity2
            // 
            this.cmbCity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity2.Enabled = false;
            this.cmbCity2.FormattingEnabled = true;
            this.cmbCity2.Location = new System.Drawing.Point(6, 46);
            this.cmbCity2.Name = "cmbCity2";
            this.cmbCity2.Size = new System.Drawing.Size(88, 20);
            this.cmbCity2.TabIndex = 8;
            this.cmbCity2.SelectedIndexChanged += new System.EventHandler(this.cmbCity2_SelectedIndexChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnView1);
            this.gb1.Controls.Add(this.cbCity1);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.cmbProvince);
            this.gb1.Controls.Add(this.cmbCounty);
            this.gb1.Controls.Add(this.cmbCity);
            this.gb1.Enabled = false;
            this.gb1.Location = new System.Drawing.Point(3, 3);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(143, 124);
            this.gb1.TabIndex = 11;
            this.gb1.TabStop = false;
            this.gb1.Text = "城市一：";
            // 
            // btnView1
            // 
            this.btnView1.Enabled = false;
            this.btnView1.Location = new System.Drawing.Point(63, 95);
            this.btnView1.Name = "btnView1";
            this.btnView1.Size = new System.Drawing.Size(72, 23);
            this.btnView1.TabIndex = 15;
            this.btnView1.Text = "查看";
            this.btnView1.UseVisualStyleBackColor = true;
            this.btnView1.Click += new System.EventHandler(this.btnView1_Click);
            // 
            // cbCity1
            // 
            this.cbCity1.AutoSize = true;
            this.cbCity1.Location = new System.Drawing.Point(9, 98);
            this.cbCity1.Name = "cbCity1";
            this.cbCity1.Size = new System.Drawing.Size(48, 16);
            this.cbCity1.TabIndex = 8;
            this.cbCity1.Text = "开启";
            this.cbCity1.UseVisualStyleBackColor = true;
            this.cbCity1.CheckedChanged += new System.EventHandler(this.cbCity1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "区/县";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "市";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "省";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.btnView2);
            this.gb2.Controls.Add(this.cbCity2);
            this.gb2.Controls.Add(this.label4);
            this.gb2.Controls.Add(this.label5);
            this.gb2.Controls.Add(this.label6);
            this.gb2.Controls.Add(this.cmbProvince2);
            this.gb2.Controls.Add(this.cmbCity2);
            this.gb2.Controls.Add(this.cmbCounty2);
            this.gb2.Enabled = false;
            this.gb2.Location = new System.Drawing.Point(152, 3);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(143, 124);
            this.gb2.TabIndex = 12;
            this.gb2.TabStop = false;
            this.gb2.Text = "城市二：";
            // 
            // btnView2
            // 
            this.btnView2.Enabled = false;
            this.btnView2.Location = new System.Drawing.Point(63, 94);
            this.btnView2.Name = "btnView2";
            this.btnView2.Size = new System.Drawing.Size(72, 23);
            this.btnView2.TabIndex = 15;
            this.btnView2.Text = "查看";
            this.btnView2.UseVisualStyleBackColor = true;
            this.btnView2.Click += new System.EventHandler(this.btnView2_Click);
            // 
            // cbCity2
            // 
            this.cbCity2.AutoSize = true;
            this.cbCity2.Location = new System.Drawing.Point(6, 98);
            this.cbCity2.Name = "cbCity2";
            this.cbCity2.Size = new System.Drawing.Size(48, 16);
            this.cbCity2.TabIndex = 14;
            this.cbCity2.Text = "开启";
            this.cbCity2.UseVisualStyleBackColor = true;
            this.cbCity2.CheckedChanged += new System.EventHandler(this.cbCity2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "区/县";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "市";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "省";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(3, 190);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(142, 23);
            this.btnSet.TabIndex = 13;
            this.btnSet.Text = "修改";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "边框颜色：";
            // 
            // cmbFrameColor
            // 
            this.cmbFrameColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrameColor.Enabled = false;
            this.cmbFrameColor.FormattingEnabled = true;
            this.cmbFrameColor.Items.AddRange(new object[] {
            "红色",
            "黄色",
            "蓝色",
            "绿色",
            "黑色",
            "白色"});
            this.cmbFrameColor.Location = new System.Drawing.Point(66, 138);
            this.cmbFrameColor.Name = "cmbFrameColor";
            this.cmbFrameColor.Size = new System.Drawing.Size(80, 20);
            this.cmbFrameColor.TabIndex = 15;
            this.cmbFrameColor.SelectedIndexChanged += new System.EventHandler(this.cmbFrameColor_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "文字颜色：";
            // 
            // cmbFontColor
            // 
            this.cmbFontColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontColor.Enabled = false;
            this.cmbFontColor.FormattingEnabled = true;
            this.cmbFontColor.Items.AddRange(new object[] {
            "红色",
            "黄色",
            "蓝色",
            "绿色",
            "黑色",
            "白色"});
            this.cmbFontColor.Location = new System.Drawing.Point(66, 164);
            this.cmbFontColor.Name = "cmbFontColor";
            this.cmbFontColor.Size = new System.Drawing.Size(80, 20);
            this.cmbFontColor.TabIndex = 15;
            this.cmbFontColor.SelectedIndexChanged += new System.EventHandler(this.cmbFontColor_SelectedIndexChanged);
            // 
            // chkReFlash
            // 
            this.chkReFlash.AutoSize = true;
            this.chkReFlash.Enabled = false;
            this.chkReFlash.Location = new System.Drawing.Point(152, 141);
            this.chkReFlash.Name = "chkReFlash";
            this.chkReFlash.Size = new System.Drawing.Size(15, 14);
            this.chkReFlash.TabIndex = 16;
            this.chkReFlash.UseVisualStyleBackColor = true;
            // 
            // txtReFlash
            // 
            this.txtReFlash.Enabled = false;
            this.txtReFlash.Location = new System.Drawing.Point(172, 138);
            this.txtReFlash.MaxLength = 3;
            this.txtReFlash.Name = "txtReFlash";
            this.txtReFlash.Size = new System.Drawing.Size(42, 21);
            this.txtReFlash.TabIndex = 17;
            this.txtReFlash.Text = "10";
            this.txtReFlash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReFlash.TextChanged += new System.EventHandler(this.txtReFlash_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "分钟刷新一次";
            // 
            // chkPinToDeskTop
            // 
            this.chkPinToDeskTop.AutoSize = true;
            this.chkPinToDeskTop.Enabled = false;
            this.chkPinToDeskTop.Location = new System.Drawing.Point(152, 166);
            this.chkPinToDeskTop.Name = "chkPinToDeskTop";
            this.chkPinToDeskTop.Size = new System.Drawing.Size(60, 16);
            this.chkPinToDeskTop.TabIndex = 19;
            this.chkPinToDeskTop.Text = "钉桌面";
            this.chkPinToDeskTop.UseVisualStyleBackColor = true;
            this.chkPinToDeskTop.CheckedChanged += new System.EventHandler(this.chkPinToDeskTop_CheckedChanged);
            // 
            // btnReGetCityList
            // 
            this.btnReGetCityList.Location = new System.Drawing.Point(152, 190);
            this.btnReGetCityList.Name = "btnReGetCityList";
            this.btnReGetCityList.Size = new System.Drawing.Size(142, 23);
            this.btnReGetCityList.TabIndex = 20;
            this.btnReGetCityList.Text = "重新生成城市列表";
            this.btnReGetCityList.UseVisualStyleBackColor = true;
            this.btnReGetCityList.Click += new System.EventHandler(this.btnReGetCityList_Click);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Enabled = false;
            this.chkAutoRun.Location = new System.Drawing.Point(212, 166);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(84, 16);
            this.chkAutoRun.TabIndex = 21;
            this.chkAutoRun.Text = "随系统启动";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 218);
            this.Controls.Add(this.chkAutoRun);
            this.Controls.Add(this.btnReGetCityList);
            this.Controls.Add(this.chkPinToDeskTop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReFlash);
            this.Controls.Add(this.chkReFlash);
            this.Controls.Add(this.cmbFontColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbFrameColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(303, 213);
            this.Name = "FormSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "桌面实时天气参数设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSet_FormClosing);
            this.Load += new System.EventHandler(this.FormSet_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormSet_KeyPress);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.ComboBox cmbCounty;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbProvince2;
        private System.Windows.Forms.ComboBox cmbCounty2;
        private System.Windows.Forms.ComboBox cmbCity2;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox cbCity1;
        private System.Windows.Forms.CheckBox cbCity2;
        private System.Windows.Forms.Button btnView1;
        private System.Windows.Forms.Button btnView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFrameColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbFontColor;
        private System.Windows.Forms.CheckBox chkReFlash;
        private System.Windows.Forms.TextBox txtReFlash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPinToDeskTop;
        private System.Windows.Forms.Button btnReGetCityList;
        private System.Windows.Forms.CheckBox chkAutoRun;
    }
}