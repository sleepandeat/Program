using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Weather
{
    public partial class FormSet : Form
    {
        private FormMain frmMain = null;
        public FormSet(FormMain frm)
        {
            InitializeComponent();
            this.frmMain = frm;
            frm.CmbProvinceInit(this.cmbProvince);  //初始化城市一下拉列表框
            frm.CmbProvinceInit(this.cmbProvince2); //初始化城市二下拉列表框
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            this.Init(); //初始化各控件
        }

        #region 保存按钮
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (this.btnSet.Text == "修改")
            {
                this.gb1.Enabled = true;
                this.gb2.Enabled = true;
                if (!frmMain.PinTODeskTop)
                    this.cmbFrameColor.Enabled = true;
                this.cmbFontColor.Enabled = true;
                this.chkReFlash.Enabled = true;
                this.txtReFlash.Enabled = true;
                this.chkPinToDeskTop.Enabled = true;
                this.chkAutoRun.Enabled = true;
                this.gb1Init();
                this.gb2Init();
                this.btnSet.Text = "保存";
            }
            else
            {
                this.gb1.Enabled = false;
                this.gb2.Enabled = false;
                this.cmbFrameColor.Enabled = false;
                this.cmbFontColor.Enabled = false;
                this.chkReFlash.Enabled = false;
                this.txtReFlash.Enabled = false;
                this.chkPinToDeskTop.Enabled = false;
                this.chkAutoRun.Enabled = false;

                frmMain.PinTODeskTop = this.chkPinToDeskTop.Checked;
                frmMain.SaveConfig("PinTODeskTop", this.chkPinToDeskTop.Checked.ToString());
                frmMain.DesktopIntegration();
                
                frmMain.AutoRun = this.chkAutoRun.Checked;
                frmMain.SaveConfig("AutoRun", this.chkAutoRun.Checked.ToString());
                frmMain.SetAutoRun();

                frmMain.FrameColor = frmMain.GetColorEN(this.cmbFrameColor.Text, "Red");
                frmMain.SaveConfig("FrameColor", frmMain.FrameColor);
                frmMain.FontColor = frmMain.GetColorEN(this.cmbFontColor.Text, "Black");
                frmMain.SaveConfig("FontColor", frmMain.FontColor);
                frmMain.FormColorInit();

                frmMain.SaveConfig("ReFlash", this.chkReFlash.Checked.ToString());
                frmMain.ReFlashEnable = this.chkReFlash.Checked;
                frmMain.SaveConfig("ReFlashSpan", this.txtReFlash.Text.Trim());
                frmMain.ReFlashSpan = Convert.ToInt32(this.txtReFlash.Text.Trim()) * 60;

                if (this.cbCity1.Checked)
                {
                    frmMain.City1 = this.cmbProvince.Text + "|" + this.cmbCity.Text + "|" + this.cmbCounty.Text;
                    frmMain.SaveConfig("City1", frmMain.City1);
                }
                if (this.cbCity2.Checked)
                {
                    frmMain.City2 = this.cmbProvince2.Text + "|" + this.cmbCity2.Text + "|" + this.cmbCounty2.Text;
                    frmMain.SaveConfig("City2", frmMain.City2);
                }
                if (this.cbCity1.Checked & this.cbCity2.Checked)
                    frmMain.CityQuery = 3;
                else if (this.cbCity1.Checked & !this.cbCity2.Checked)
                    frmMain.CityQuery = 1;
                else if (!this.cbCity1.Checked & this.cbCity2.Checked)
                    frmMain.CityQuery = 2;
                frmMain.SaveConfig("CityShow", frmMain.CityQuery.ToString());
                frmMain.ShowWeather();
                this.btnSet.Text = "修改";
            }
        }
        #endregion

        #region 各控件及参数初始化
        private void Init()
        {
            switch (frmMain.CityQuery)
            {
                case 1:
                    this.cbCity1.Checked = true;
                    break;
                case 2:
                    this.cbCity2.Checked = true;
                    break;
                default:
                    this.cbCity1.Checked = true;
                    this.cbCity2.Checked = true;
                    break;
            }
            if (frmMain.City1.Split('|').Length == 3)
            {
                this.cmbProvince.Text = frmMain.City1.Split('|')[0];
                this.cmbCity.Text = frmMain.City1.Split('|')[1];
                this.cmbCounty.Text = frmMain.City1.Split('|')[2];
            }
            if (frmMain.City2.Split('|').Length == 3)
            {
                this.cmbProvince2.Text = frmMain.City2.Split('|')[0];
                this.cmbCity2.Text = frmMain.City2.Split('|')[1];
                this.cmbCounty2.Text = frmMain.City2.Split('|')[2];
            }
            this.chkPinToDeskTop.Checked = frmMain.PinTODeskTop;
            this.chkAutoRun.Checked = frmMain.AutoRun;
            this.chkReFlash.Checked = frmMain.ReFlashEnable;
            this.txtReFlash.Text = (frmMain.ReFlashSpan / 60).ToString();
            this.cmbFrameColor.Text = frmMain.GetColorCN(frmMain.FrameColor, "红色");
            this.cmbFontColor.Text = frmMain.GetColorCN(frmMain.FontColor, "黑色");
        }

        private void gb1Init()
        {
            if (this.cbCity1.Checked)
            {
                this.cmbProvince.Enabled = true;
                this.cmbCity.Enabled = true;
                this.cmbCounty.Enabled = true;
                this.btnView1.Enabled = true;
            }
            else
            {
                if (!this.cbCity2.Checked)
                    this.cbCity2.Checked = true;    //保证至少开启一个
                this.cmbProvince.Enabled = false;
                this.cmbCity.Enabled = false;
                this.cmbCounty.Enabled = false;
                this.btnView1.Enabled = false;
            }
        }
        private void gb2Init()
        {
            if (this.cbCity2.Checked)
            {
                this.cmbProvince2.Enabled = true;
                this.cmbCity2.Enabled = true;
                this.cmbCounty2.Enabled = true;
                this.btnView2.Enabled = true;
            }
            else
            {
                if (!this.cbCity1.Checked)
                    this.cbCity1.Checked = true;    //保证至少开启一个
                this.cmbProvince2.Enabled = false;
                this.cmbCity2.Enabled = false;
                this.cmbCounty2.Enabled = false;
                this.btnView2.Enabled = false;
            }
        }

        private void frmMainCityQueryInit()
        {
            if (this.cbCity1.Checked && this.cbCity2.Checked)
                frmMain.CityQuery = 3;
            else if (this.cbCity1.Checked && !this.cbCity2.Checked)
                frmMain.CityQuery = 1;
            else if (!this.cbCity1.Checked && this.cbCity2.Checked)
                frmMain.CityQuery = 2;
        }
        #endregion

        #region 各省、市、区下拉列表自动填充
        private void cbCity1_CheckedChanged(object sender, EventArgs e)
        {
            this.gb1Init();
        }

        private void cbCity2_CheckedChanged(object sender, EventArgs e)
        {
            this.gb2Init();
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain.CmbCityInit(this.cmbProvince, this.cmbCity);
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain.CmbCountyInit(this.cmbProvince, this.cmbCity, this.cmbCounty);
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.cmbCounty.Text))
            //{
            //    this.frmMainCityQueryInit();
            //    string url = "";
            //    string msg = frmMain.GetWeather(this.cmbProvince.Text, this.cmbCity.Text, this.cmbCounty.Text, out url);
            //    frmMain.ShowResult(1, this.cmbCounty.Text, msg, url);
            //}
        }

        private void cmbProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain.CmbCityInit(this.cmbProvince2, this.cmbCity2);
        }

        private void cmbCity2_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmMain.CmbCountyInit(this.cmbProvince2, this.cmbCity2, this.cmbCounty2);
        }

        private void cmbCounty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.cmbCounty2.Text))
            //{
            //    this.frmMainCityQueryInit();
            //    string url = "";
            //    string msg = frmMain.GetWeather(this.cmbProvince2.Text, this.cmbCity2.Text, this.cmbCounty2.Text, out url);
            //    frmMain.ShowResult(2, this.cmbCounty2.Text, msg, url);
            //}
        }
        #endregion

        #region 城市一及城市二的“查看”按钮
        private void btnView1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbCounty.Text))
            {
                this.frmMainCityQueryInit();
                string url = "";
                string weather = "";
                string msg = frmMain.GetWeather(this.cmbProvince.Text, this.cmbCity.Text, this.cmbCounty.Text, out url, out weather);
                frmMain.ShowResult(1, this.cmbCounty.Text, msg, url, weather);
            }
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbCounty2.Text))
            {
                this.frmMainCityQueryInit();
                string url = "";
                string weather = "";
                string msg = frmMain.GetWeather(this.cmbProvince2.Text, this.cmbCity2.Text, this.cmbCounty2.Text, out url, out weather);
                frmMain.ShowResult(2, this.cmbCounty2.Text, msg, url, weather);
            }
        }
        #endregion

        #region 防止边框颜色跟字体颜色一致，导致看不到文字内容
        private void cmbFrameColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbFrameColor.SelectedIndex == this.cmbFontColor.SelectedIndex)
            {
                if (!this.chkPinToDeskTop.Checked)
                {
                    frmMain.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "边框颜色与字体颜色相同会导致看不到文字信息！", ToolTipIcon.Info);
                    this.cmbFrameColor.SelectedIndex = this.cmbFrameColor.SelectedIndex == 0 ? this.cmbFrameColor.Items.Count - 1 : this.cmbFrameColor.SelectedIndex - 1;
                }
            }
        }

        private void cmbFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbFontColor.SelectedIndex == this.cmbFrameColor.SelectedIndex)
            {
                if (!this.chkPinToDeskTop.Checked)
                {
                    frmMain.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "边框颜色与字体颜色相同会导致看不到文字信息！", ToolTipIcon.Info);
                    this.cmbFontColor.SelectedIndex = this.cmbFontColor.SelectedIndex == 0 ? this.cmbFontColor.Items.Count - 1 : this.cmbFontColor.SelectedIndex - 1;
                }
                else
                {
                    this.cmbFrameColor.SelectedIndex = this.cmbFrameColor.SelectedIndex == 0 ? this.cmbFrameColor.Items.Count - 1 : this.cmbFrameColor.SelectedIndex - 1;
                }
            }
        }
        #endregion

        private void FormSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.btnSet.Text=="保存")
            {
                if (MessageBox.Show("当前设置未保存，您确定要退出吗？","是否退出？",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    int ci = frmMain.CityQuery;
                    try
                    {
                        ci = Convert.ToInt32(frmMain.GetConfigInfo("CityShow", ci.ToString()));
                    }
                    catch (FormatException)
                    {
                        ci = 1;
                        frmMain.SaveConfig("CityShow", "1");
                    }
                    frmMain.CityQuery = ci;
                    frmMain.ShowWeather();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtReFlash_TextChanged(object sender, EventArgs e)
        {
            this.txtReFlash.Text = Regex.Replace(this.txtReFlash.Text, "[^0-9]", "");
            if (this.txtReFlash.Text.Trim() != "" && this.txtReFlash.Text.Substring(0,1) == "0")
            {
                this.txtReFlash.Text = this.txtReFlash.Text.Substring(1);
            }
        }

        private void chkPinToDeskTop_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkPinToDeskTop.Checked && this.btnSet.Text == "保存")
            {
                this.cmbFrameColor.Enabled = true;
                this.cmbFrameColor_SelectedIndexChanged(null, null);
            }
            else
            {
                this.cmbFrameColor.Enabled = false;
                //this.cmbFontColor_SelectedIndexChanged(null, null);
            }
        }

        private void btnReGetCityList_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("重新生成城市列表可能较慢，是否生成？", "是否生成？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmMain.RemoteCityListInit();
                    frmMain.SaveConfig("CityList", frmMain.GetCityListStringForSave());
                }
            }
            catch (Exception ex)
            {
                frmMain.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "出错啦：" + ex.Message, ToolTipIcon.Info);
            }
        }

        private void FormSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                this.Close();
        }
    }
}
