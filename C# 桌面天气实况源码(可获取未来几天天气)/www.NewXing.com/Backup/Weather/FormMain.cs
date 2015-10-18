using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Weather
{
    public partial class FormMain : Form
    {
        private static ChineseLunisolarCalendar chineseDate = new ChineseLunisolarCalendar();           //农历计算器
        public delegate void ControlSet(Control control, string properties, object value);              //设置控件属性
        public delegate void LinkControl(LinkLabel linkControl, int start, int length, object url);   //设置“查看详情”链接

        public struct WeatherInfo   //天气信息
        {
            //city":"河源","cityid":"101281201","temp":"7.1","WD":"东北风","WS":"小于3级","SD":"40%","AP":"1018.7hPa","njd":"暂无实况","WSE":"<3","time":"23:10","sm":"5","isRadar":"0","Radar":"
            public string city;     //城市名称
            public string cityid;   //城市ID
            public string temp;     //温度
            public string WD;       //风向
            public string WS;       //风力
            public string SD;       //湿度
            public string AP;       //气压
            public string njd;      //
            public string WSE;      //
            public string time;     //发布时间
            public string sm;       //风速
            public string isRadar;  //
            public string Radar;    //雷达

            public bool getWeatherInfo(string weatherinfo)
            {
                try
                {
                    string[] info = Regex.Split(Regex.Replace(weatherinfo, "\":\"", "|"), "\",\"");
                    foreach (string item in info)
                    {
                        switch (item.Split('|')[0])
                        {
                            case "city":
                                this.city = item.Split('|')[1];
                                break;
                            case "cityid":
                                this.cityid = item.Split('|')[1];
                                break;
                            case "temp":
                                this.temp = item.Split('|')[1] == "暂无实况" ? "暂无实况" : item.Split('|')[1] + "℃";
                                break;
                            case "WD":
                                this.WD = item.Split('|')[1];
                                break;
                            case "WS":
                                this.WS = item.Split('|')[1];
                                break;
                            case "SD":
                                this.SD = item.Split('|')[1];
                                break;
                            case "AP":
                                this.AP = item.Split('|')[1];
                                break;
                            case "njd":
                                this.njd = item.Split('|')[1];
                                break;
                            case "WSE":
                                this.WSE = item.Split('|')[1];
                                break;
                            case "time":
                                this.time = item.Split('|')[1];
                                break;
                            case "sm":
                                this.sm = item.Split('|')[1] == "暂无实况" ? "暂无实况" : item.Split('|')[1] + "m/s";
                                break;
                            case "isRadar":
                                this.isRadar = item.Split('|')[1];
                                break;
                            case "Radar":
                                this.Radar = item.Split('|')[1];
                                break;
                            default:
                                break;
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        #region 程序相关字段及属性
        #region 字段
        public List<string> CityList = new List<string>();
        public Thread threadReflash = null;
        public Thread threadTimer = null;
        public const string ConfigFileName = "Config.xml";
        private string _ConfigPath = string.Empty;
        private FormSet frmSet = null;
        private string _City1 = string.Empty;   //城市1，格式：省|市|县
        private string _City2 = string.Empty;   //城市2，格式：省|市|县
        private int reflashTemp = 0;            //临时变量
        private TimeSpan _timeSpan;              //远程服务器与本机的时间差
        private int _CityQuery = 1;             //数字为1时，只显示City1的天气，为2时只显示City2的天气，为3时两个都显示，默认只显示一个
        private int _ReFlashSpan = 600;         //自动刷新间隔(单位：秒，但以分钟的形式存储)
        private string _FrameColor = "Red";     //主窗体背景色
        private string _FontColor = "Black";    //主窗体文字颜色
        private bool _ReFlashEnable = true;     //是否自动刷新天气情况
        private bool _PinTODeskTop = true;      //是否嵌入到桌面（启用后无边框效果）
        private bool _AutoRun = false;          //是否随系统启动
        private IntPtr _DefaultParent;          //默认父窗体
        private IntPtr _DeskTopParent;          //桌面作为侈窗体
        private Rectangle _WorkingArea;         //工作区域
        private string _nongli = "";            //农历
        #endregion

        #region 属性
        public string ConfigPath
        {
            get { return _ConfigPath; }
            set { _ConfigPath = value; }
        }

        public string City1
        {
            get
            {
                if (_City1.Split('|').Length == 3)
                    return _City1;
                else
                {
                    this.SaveConfig("City1","广东|河源|河源市");
                    return "广东|河源|河源市";
                }
            }
            set { _City1 = value; }
        }

        public string City2
        {
            get
            {
                if (_City2.Split('|').Length == 3)
                    return _City2;
                else
                {
                    this.SaveConfig("City2","江西|宜春|上高县");
                    return "江西|宜春|上高县";
                }
            }
            set { _City2 = value; }
        }

        public int CityQuery
        {
            get { return _CityQuery; }
            set { _CityQuery = value; }
        }

        public int ReFlashSpan
        {
            get { return _ReFlashSpan; }
            set { _ReFlashSpan = value; }
        }

        public IntPtr DeskTopParent
        {
            get { return _DeskTopParent; }
            set { _DeskTopParent = value; }
        }

        public IntPtr DefaultParent
        {
            get { return _DefaultParent; }
            set { _DefaultParent = value; }
        }

        public bool PinTODeskTop
        {
            get { return _PinTODeskTop; }
            set { _PinTODeskTop = value; }
        }

        public bool AutoRun
        {
            get { return _AutoRun; }
            set { _AutoRun = value; }
        }

        public bool ReFlashEnable
        {
            get { return _ReFlashEnable; }
            set { _ReFlashEnable = value; }
        }

        public string FrameColor
        {
            get { return _FrameColor; }
            set { _FrameColor = value; }
        }

        public string FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }

        public TimeSpan timeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }

        public Rectangle WorkingArea
        {
            get { return _WorkingArea; }
            set { _WorkingArea = value; }
        }

        public string NongLi
        {
            get { return _nongli; }
            set { _nongli = value; }
        }
        #endregion
        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.WorkingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(this.WorkingArea.Right - this.Width, this.WorkingArea.Bottom - this.Height);
                this.Init();                                                            //初始化各控件及相关参数
                this.ShowWeather();                                                     //显示天气情况
                this.DesktopIntegration();                                              //设置父窗体（是否集成到桌面）
                this.threadReflash = new Thread(new ThreadStart(this.ReflashWeather));  //采用线程刷新
                this.threadReflash.SetApartmentState(ApartmentState.STA);               //解决：“当前线程不在单线程单元中，因此无法实例化 ActiveX 控”错误的问题
                this.threadReflash.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦：" + ex.Message, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 初始化各控件及相关参数
        private void Init()
        {
            this.ConfigPath = this.GetPath() + ConfigFileName;              //初始化配置文件路径
            if (File.Exists(this.ConfigPath))
            {
                this.ReadCityListFromConfigFile();
            }
            else
            {
                this.RemoteCityListInit();
                this.CreateXmlFile();
            }
            this.City1 = this.GetConfigInfo("City1", "广东|河源|河源市");
            this.City2 = this.GetConfigInfo("City2", "江西|宜春|上高县");
            try
            {
                this.CityQuery = Convert.ToInt32(this.GetConfigInfo("CityShow", "1"));
            }
            catch (FormatException)
            {
                this.CityQuery = 1;
                this.SaveConfig("CityShow", "1");
            }
            try
            {
                this.ReFlashSpan = Convert.ToInt32(this.GetConfigInfo("ReFlashSpan", "10")) * 60;
            }
            catch (FormatException)
            {
                this.ReFlashSpan = 600;
                this.SaveConfig("ReFlashSpan", "10");
            }
            try
            {
                this.ReFlashEnable = Convert.ToBoolean(this.GetConfigInfo("ReFlash", "True"));
            }
            catch (FormatException)
            {
                this.ReFlashEnable = true;
                this.SaveConfig("ReFlash", "True");
            }
            try
            {
                this.PinTODeskTop = Convert.ToBoolean(this.GetConfigInfo("PinTODeskTop", "True"));
            }
            catch (FormatException)
            {
                this.PinTODeskTop = true;
                this.SaveConfig("PinTODeskTop", "True");
            }
            try
            {
                this.AutoRun = Convert.ToBoolean(this.GetConfigInfo("AutoRun", "False"));
            }
            catch (FormatException)
            {
                this.AutoRun = false;
                this.SaveConfig("AutoRun", "False");
            }
            this.SetAutoRun();  //修正自动运行设置
            this.FrameColor = this.GetColor(this.GetConfigInfo("FrameColor", "Red"), "Red");
            this.FontColor = this.GetColor(this.GetConfigInfo("FontColor", "Black"), "Black");
            this.FormColorInit();                                               //初始化窗体颜色
            this.GetRemoteTime();                                               //获取远程服务器与本机的时间差
            this.NongLi = this.GetChineseDate(DateTime.Now + this.timeSpan);    //计算农历
            this.threadTimer = new Thread(new ThreadStart(this.ThreadTimer));   //采用线程替代Timer控制时间
            this.threadTimer.Start();
            this.DefaultParent = GetParent(this.Handle);                        //默认父窗体
            this.DeskTopParent = FindWindow("Progman", "Program Manager");      //桌面父窗体
        }

        public void FormColorInit()
        {
            this.BackColor = this.GetColor(this.FrameColor, Color.Red);
            this.TransparencyKey = this.BackColor;
            this.label1.ForeColor = this.GetColor(this.FontColor, Color.Black);
            this.label2.ForeColor = this.GetColor(this.FontColor, Color.Black);
            this.lblTitle.ForeColor = this.GetColor(this.FontColor, Color.Black);
            this.llbView1.LinkColor = this.GetColor(this.FontColor, Color.Black);
            this.llbView2.LinkColor = this.GetColor(this.FontColor, Color.Black);
            this.llbReFlash1.LinkColor = this.GetColor(this.FontColor, Color.Black);
            this.llbReFlash2.LinkColor = this.GetColor(this.FontColor, Color.Black);
            this.gb1.ForeColor = this.GetColor(this.FontColor, Color.Black);
            this.gb2.ForeColor = this.GetColor(this.FontColor, Color.Black);
        }

        public void ShowWeather()
        {
            string url1 = "";
            string url2 = "";
            string msg1 = "";
            string msg2 = "";
            string weather = "";
            switch (this.CityQuery)
            {
                case 1:
                    msg1 = this.GetWeather(this.City1.Split('|')[0], this.City1.Split('|')[1], this.City1.Split('|')[2], out url1, out weather);
                    this.ShowResult(1, this.City1.Split('|')[2], msg1, url1, weather);
                    break;
                case 2:
                    msg2 = this.GetWeather(this.City2.Split('|')[0], this.City2.Split('|')[1], this.City2.Split('|')[2], out url2, out weather);
                    this.ShowResult(2, this.City2.Split('|')[2], msg2, url2, weather);
                    break;
                default:
                    msg1 = this.GetWeather(this.City1.Split('|')[0], this.City1.Split('|')[1], this.City1.Split('|')[2], out url1, out weather);
                    this.ShowResult(1, this.City1.Split('|')[2], msg1, url1, weather);
                    msg2 = this.GetWeather(this.City2.Split('|')[0], this.City2.Split('|')[1], this.City2.Split('|')[2], out url2, out weather);
                    this.ShowResult(2, this.City2.Split('|')[2], msg2, url2, weather);
                    break;
            }
        }
        #endregion

        #region 初始化省、市、区列表框
        public void CmbInit(ComboBox cmbprovince, ComboBox cmbcity, ComboBox cmbcounty)
        {
            this.CmbProvinceInit(cmbprovince);
            this.CmbCityInit(cmbprovince, cmbcity);
            this.CmbCountyInit(cmbprovince, cmbcity, cmbcounty);
        }
        public void CmbProvinceInit(ComboBox cmbprovince)
        {
            cmbprovince.Items.Clear();
            List<string> list = new List<string>();
            foreach (string item in this.CityList)
            {
                if (!list.Contains(item.Split('|')[0]))
                    list.Add(item.Split('|')[0]);
            }
            foreach (string item in list)
            {
                cmbprovince.Items.Add(item.Split('|')[0]);
            }
            if (cmbprovince.Items.Count > 0)
                cmbprovince.SelectedIndex = 0;
        }

        public void CmbCityInit(ComboBox cmbprovince, ComboBox cmbcity)
        {
            cmbcity.Items.Clear();
            List<string> list = new List<string>();
            foreach (string item in this.CityList)
            {
                if (item.Split('|')[0] == cmbprovince.Text && !list.Contains(item.Split('|')[0] + "|" + item.Split('|')[1]))
                    list.Add(item.Split('|')[0] + "|" + item.Split('|')[1]);
            }
            foreach (string item in list)
            {
                cmbcity.Items.Add(item.Split('|')[1]);
            }
            if (cmbcity.Items.Count > 0)
                cmbcity.SelectedIndex = 0;
        }

        public void CmbCountyInit(ComboBox cmbprovince, ComboBox cmbcity, ComboBox cmbcounty)
        {
            cmbcounty.Items.Clear();
            foreach (string item in this.CityList)
            {
                if (item.Split('|')[0] == cmbprovince.Text && item.Split('|')[1] == cmbcity.Text)
                {
                    cmbcounty.Items.Add(item.Split('|')[2]);
                }
            }
            if (cmbcounty.Items.Count > 0)
                cmbcounty.SelectedIndex = 0;
        }
        #endregion

        #region 菜单相关功能代码及窗体事件
        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.Show();
        }

        private void 设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(frmSet != null && (!frmSet.IsDisposed)))
            {
                frmSet = new FormSet(this);
            }
            frmSet.Show();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!File.Exists(this.ConfigPath))
                return;
            if (!(frmSet != null && (!frmSet.IsDisposed)))
            {
                frmSet = new FormSet(this);
            }
            frmSet.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.threadReflash != null)
                this.threadReflash.Abort();
            if (this.threadTimer != null)
                this.threadTimer.Abort();
        }
        #endregion

        #region 桌面集成
        public void DesktopIntegration()
        {
            if (this.PinTODeskTop)
            {
                SetParent(this.Handle, this.DeskTopParent);
            }
            else
            {
                SetParent(this.Handle, this.DefaultParent);
            }
        }
        #endregion

        #region 设置自动运行
        public void SetAutoRun()
        {
            RegistryKey root = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (this.AutoRun)
            {
                root.SetValue("Weather", Application.ExecutablePath);
            }
            else
            {
                try
                {
                    root.DeleteValue("Weather");
                }
                catch (ArgumentException){}
            }
        }
        #endregion

        #region 获取配置文件路径
        private string GetPath()
        {
            string path = Application.StartupPath;
            if (path.Substring(path.Length - 1, 1) == @"\")
            {
                return path;
            }
            else
            {
                return path + "\\";
            }
        }
        #endregion

        #region 将 CityList 中的数据 生成字符串，用于保存
        public string GetCityListStringForSave()
        {
            string strCity = "";
            for (int i = 0; i < this.CityList.Count; i++)
            {
                strCity += (i != this.CityList.Count - 1 ? this.CityList[i] + "||" : this.CityList[i]);  //(char)41462
            }
            return strCity;
        }
        #endregion

        #region 创建XML配置文件
        private void CreateXmlFile()
        {
            try
            {
                XmlTextWriter xmlwriter = new XmlTextWriter(this.ConfigPath, Encoding.Default);
                xmlwriter.Formatting = Formatting.Indented;
                xmlwriter.Indentation = 4;

                xmlwriter.WriteStartDocument();
                xmlwriter.WriteStartElement("", "Config", "");

                xmlwriter.WriteStartElement("", "FrameColor", "");
                xmlwriter.WriteString("Red");
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "FontColor", "");
                xmlwriter.WriteString("Black");
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "AutoRun", "");
                xmlwriter.WriteString("False");    //是否随系统启动
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "ReFlash", "");
                xmlwriter.WriteString("True");    //是否开启自动刷新：分钟
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "PinTODeskTop", "");
                xmlwriter.WriteString("True");    //是否嵌入到桌面
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "ReFlashSpan", "");
                xmlwriter.WriteString("10");    //单位：分钟
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "CityShow", "");
                xmlwriter.WriteString("3");     //为1时只显示城市1的天气情况，为2时只显示城市2的天气情况，为3时都显示
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "City1", "");
                xmlwriter.WriteString("广东|河源|河源市");
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "City2", "");
                xmlwriter.WriteString("江西|宜春|上高县");
                xmlwriter.WriteEndElement();

                xmlwriter.WriteStartElement("", "CityList", "");
                xmlwriter.WriteString(this.GetCityListStringForSave());
                xmlwriter.WriteEndElement();

                xmlwriter.WriteEndElement();
                xmlwriter.WriteEndDocument();

                xmlwriter.Flush();
                xmlwriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦：" + ex.Message, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 保存设置到配置文件
        public void SaveConfig(string nodeName, string nodeValue)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(this.ConfigPath);
            XmlNamespaceManager xmlmanager = new XmlNamespaceManager(xmldoc.NameTable);
            XmlNode node = xmldoc.SelectSingleNode("/Config/" + nodeName, xmlmanager);
            if (node != null)
            {
                node.InnerText = nodeValue;
            }
            else
            {
                node = xmldoc.SelectSingleNode("Config", xmlmanager);
                XmlElement subElement = xmldoc.CreateElement(nodeName);
                subElement.InnerText = nodeValue;
                node.AppendChild(subElement);
            }
            xmldoc.Save(this.ConfigPath);
        }
        #endregion

        #region  从配置文件读取信息
        public string GetConfigInfo(string nodeName, string normalReturn)
        {
            string inf = string.Empty;
            XmlTextReader xmlreader = new XmlTextReader(this.ConfigPath);
            while (xmlreader.Read())
            {
                if (xmlreader.NodeType == XmlNodeType.Element && xmlreader.Name == nodeName)
                {
                    xmlreader.Read();
                    inf = xmlreader.Value;
                    xmlreader.Close();
                    break;
                }
            }
            if (!string.IsNullOrEmpty(inf))
            {
                return inf;
            }
            else
            {
                if (xmlreader.ReadState != ReadState.Closed)
                    xmlreader.Close();
                this.SaveConfig(nodeName, normalReturn);
                return normalReturn;
            }
        }
        #endregion

        #region 从配置文件读取城市列表及XML文件名称
        private void ReadCityListFromConfigFile()
        {
            string[] list = null;
            XmlTextReader reader = new XmlTextReader(this.ConfigPath);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "CityList")
                {
                    reader.Read();
                    list = Regex.Split(reader.Value, "\\|\\|");
                    foreach (string item in list)
                    {
                        this.CityList.Add(item);
                    }
                    reader.Close();
                    break;
                }
            }
            if (list == null || list.Length == 1 || string.IsNullOrEmpty(list[0].Trim()) || list[0].Split('|').Length != 5)
            {
                if (reader.ReadState != ReadState.Closed)
                    reader.Close();
                this.RemoteCityListInit();
                this.SaveConfig("CityList", this.GetCityListStringForSave());
            }
        }
        #endregion

        #region 从远程服务器获取城市列表及XML文件名称
        public void RemoteCityListInit()
        {
            this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "开始生成城市列表信息，大概需要十几秒钟的时间，请稍后...", ToolTipIcon.Info);
            List<string> pList = new List<string>();
            List<string> cList = new List<string>();
            XmlDocument xml = new XmlDocument();
            xml.Load("http://flash.weather.com.cn/wmaps/xml/china.xml");
            XmlElement root = xml.DocumentElement;
            XmlNodeList nodes = root.ChildNodes;
            for (int i = 0; i < nodes.Count; i++)    //获取各省的XML文件名称
            {
                pList.Add(nodes[i].Attributes["quName"].Value + "|" + nodes[i].Attributes["pyName"].Value);
            }
            for (int j = 0; j < pList.Count; j++)   //获取各市XML文件名称
            {
                xml.Load("http://flash.weather.com.cn/wmaps/xml/" + pList[j].Split('|')[1] + ".xml");
                root = xml.DocumentElement;
                nodes = root.ChildNodes;
                for (int x = 0; x < nodes.Count; x++)   //格式：省|市|各市XML文件名称，例如：广东|河源|heyuan|下级城市不存在时使用的XML|下级城市不存在时使用的详情链接URL
                {
                    //cList.Add(pList[j].Split('|')[0] + "|" + nodes[x].Attributes["cityname"].Value + "|" + nodes[x].Attributes["pyName"].Value + "|" + pList[j].Split('|')[1]);
                    cList.Add(pList[j].Split('|')[0] + "|" + nodes[x].Attributes["cityname"].Value + "|" + nodes[x].Attributes["pyName"].Value + "|" + pList[j].Split('|')[1] + "|" + nodes[x].Attributes["url"].Value);
                }
            }
            this.CityList.Clear();  //清空数据重新填充
            for (int y = 0; y < cList.Count; y++)
            {
                try
                {
                    xml.Load("http://flash.weather.com.cn/wmaps/xml/" + cList[y].Split('|')[2] + ".xml");
                    root = xml.DocumentElement;
                    nodes = root.ChildNodes;
                    for (int m = 0; m < nodes.Count; m++)   //格式：省|市|县|各市XML文件名称，例如：广东|河源|紫金县|heyuan|详情URL，如：http://www.weather.com.cn/weather/101281201.shtml?from=cn
                    {
                        //this.CityList.Add(cList[y].Split('|')[0] + "|" + cList[y].Split('|')[1] + "|" + nodes[m].Attributes["cityname"].Value + "|" + cList[y].Split('|')[2]);
                        this.CityList.Add(cList[y].Split('|')[0] + "|" + cList[y].Split('|')[1] + "|" + nodes[m].Attributes["cityname"].Value + "|" + cList[y].Split('|')[2] + "|" + nodes[m].Attributes["url"].Value);
                    }
                }
                catch (XmlException)
                {
                    //this.CityList.Add(cList[y].Split('|')[0] + "|" + cList[y].Split('|')[1] + "|" + cList[y].Split('|')[1] + "|" + cList[y].Split('|')[3]);
                    this.CityList.Add(cList[y].Split('|')[0] + "|" + cList[y].Split('|')[1] + "|" + cList[y].Split('|')[1] + "|" + cList[y].Split('|')[3] + "|" + cList[y].Split('|')[4]);
                }
            }
        }
        #endregion

        #region 获取对应城市天所情况XML文件或天气详情URL地址
        /// <summary>
        /// 获取对应城市天所情况XML文件或天气详情URL地址
        /// </summary>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <param name="county">区、县</param>
        /// <param name="urlType">返回地址类型，为0时返回最新实况，否则返回详情URL</param>
        /// <returns></returns>
        private string GetUrl(string province, string city, string county, int urlType)
        {
            string url = urlType == 0 ? "" : "http://www.weather.com.cn/forecast/index.shtml";
            foreach (string item in this.CityList)
            {
                if (item.Split('|')[0] == province && item.Split('|')[1] == city && item.Split('|')[2] == county)
                {
                    url = urlType == 0 ? "http://www.weather.com.cn/data/sk/" + item.Split('|')[4] + ".html?" + System.Guid.NewGuid().ToString("N") : "http://www.weather.com.cn/weather/" + item.Split('|')[4] + ".shtml?from=cn";
                    break;
                }
            }
            return url;
            #region 返回XML文件及详情网页的做法
            //string url = urlType == 0 ? "http://flash.weather.com.cn/wmaps/xml/china.xml" : "http://www.weather.com.cn/forecast/index.shtml";
            //foreach (string item in this.CityList)
            //{
            //    if (item.Split('|')[0] == province && item.Split('|')[1] == city && item.Split('|')[2] == county)
            //    {
            //        url = urlType == 0 ? "http://flash.weather.com.cn/wmaps/xml/" + item.Split('|')[3] + ".xml" : "http://www.weather.com.cn/weather/" + item.Split('|')[4] + ".shtml?from=cn";
            //        break;
            //    }
            //}
            //return url;
            #endregion
        }
        #endregion

        #region 获取指定城市的实时天气情况
        public string GetWeather(string province, string city, string county, out string url,out string weather)
        {
            //{"weatherinfo":{"city":"河源","cityid":"101281201","temp":"7.1","WD":"东北风","WS":"小于3级","SD":"40%","AP":"1018.7hPa","njd":"暂无实况","WSE":"<3","time":"23:10","sm":"5","isRadar":"0","Radar":""}}
            url = this.GetUrl(province, city, county, 1);
            weather = "";
            string Text = "";
            string TextDetail = "";
            HttpWebRequest request;
            HttpWebResponse response = null;
            Stream streamReceive;
            StreamReader streamReader;
            #region 获取当前天气实时数据
            try
            {
                request = (HttpWebRequest)WebRequest.Create(this.GetUrl(province, city, county, 0));
                request.Timeout = 8000;
                request.Headers.Set("Pragma", "no-cache");
                //HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    //this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "从网络获取数据时出现错误：" + err.Message, ToolTipIcon.Info);
                    throw new ApplicationException("获取当前天气详细数据失败！\n");
                }
                streamReceive = response.GetResponseStream();
                streamReader = new StreamReader(streamReceive);
                string strTemp = streamReader.ReadToEnd();
                if (response != null)
                    response.Close();
                int infoStart = strTemp.IndexOf("{\"weatherinfo\":{\"", 0);
                int infoEnd = strTemp.IndexOf("\"}}", infoStart);
                string strInfo = strTemp.Substring(infoStart + 17, infoEnd - infoStart - 17);
                //city":"河源","cityid":"101281201","temp":"7.1","WD":"东北风","WS":"小于3级","SD":"40%","AP":"1018.7hPa","njd":"暂无实况","WSE":"<3","time":"23:10","sm":"5","isRadar":"0","Radar":"
                WeatherInfo info = new WeatherInfo();
                if (!info.getWeatherInfo(strInfo))
                    throw new ApplicationException("获取当前天气详细数据失败！\n");
                Text += "时间：" + info.time + "\n";
                Text += "气温：" + info.temp + "\n";
                Text += "湿度：" + info.SD + "\n";
                Text += "风向：" + info.WD + "\n";
                Text += "风力：" + info.WS + (info.sm == "暂无实况" ? "" : "[" + info.sm + "]") + "\n";
            }
            catch (Exception)
            {
                Text = "获取当前天气详细数据失败！\n";
            }
            #endregion
            #region 获取未来几天天气情况
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 8000;
                request.Headers.Set("Pragma", "no-cache");
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException)
                {
                    //this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "获取未来几天天气信息失败：\n" + err.Message, ToolTipIcon.Info);
                    TextDetail = "获取未来几天天气信息失败！";
                }
                streamReceive = response.GetResponseStream();
                streamReader = new StreamReader(streamReceive, Encoding.GetEncoding("UTF-8"));
                string strTemp = streamReader.ReadToEnd();
                if (response != null)
                    response.Close();
                int detailStart = strTemp.IndexOf("<!--day 1-->", 0) + 12;
                int detailEnd = strTemp.IndexOf("<!--day 4-->", detailStart);
                string strWeb = strTemp.Substring(detailStart, detailEnd - detailStart);
                WebBrowser webb = new WebBrowser();
                webb.Navigate("about:blank");
                HtmlDocument htmldoc = webb.Document.OpenNew(true);
                htmldoc.Write(strWeb);
                HtmlElementCollection htmlTR = htmldoc.GetElementsByTagName("tr");
                string strDay = "今日";
                bool d1 = false;
                bool d2 = false;
                foreach (HtmlElement tr in htmlTR)
                {
                    string strDate = "";
                    string strDayNight = "";
                    string strWeather = "";
                    string strTemperature = "";
                    string strWind = "";
                    string strImg = "";
                    if (tr.GetElementsByTagName("td").Count == 7)
                    {
                        strDate = tr.GetElementsByTagName("td")[0].InnerText.Trim();
                        strDayNight = tr.GetElementsByTagName("td")[1].InnerText.Trim();
                        strImg = tr.GetElementsByTagName("td")[2].InnerHtml.Replace("<A href=\"http://www.weather.com.cn/static/html/legend.shtml\"", "").Replace("target=_blank>", "").Replace("</A>", "").Replace("\">", "").Replace("<IMG src=\"/m2/i/icon_weather/29x20/", "").Replace(" ", "");
                        strWeather = tr.GetElementsByTagName("td")[3].InnerText.Trim();
                        strTemperature = tr.GetElementsByTagName("td")[4].InnerText.Trim();
                        strWind = tr.GetElementsByTagName("td")[6].InnerText.Trim();
                        strDay = strDate.Substring(0, strDate.Length - 3);
                    }
                    else
                    {
                        strDayNight = tr.GetElementsByTagName("td")[0].InnerText.Trim();
                        strImg = tr.GetElementsByTagName("td")[1].InnerHtml.Replace("<A href=\"http://www.weather.com.cn/static/html/legend.shtml\"", "").Replace("target=_blank>", "").Replace("</A>", "").Replace("\">", "").Replace("<IMG src=\"/m2/i/icon_weather/29x20/", "").Replace(" ", "");
                        strWeather = tr.GetElementsByTagName("td")[2].InnerText.Trim();
                        strTemperature = tr.GetElementsByTagName("td")[3].InnerText.Trim();
                        strWind = tr.GetElementsByTagName("td")[5].InnerText.Trim();
                    }
                    if (!d1)
                    {
                        //if (strDayNight.IndexOf("白") > -1)
                        //{
                        //    //weather = strDay + "|" + strDayNight + "|D" + strWeather;
                        //    weather = "D" + strWeather;
                        //}
                        //else
                        //{
                        //    //weather = strDay + "|" + strDayNight + "|N" + strWeather;
                        //    weather = "N" + strWeather;
                        //}
                        //weather += "|" + strImg;
                        weather = strImg;
                        d1 = true;
                    }
                    else if (!d2)
                    {
                        //if (strDayNight.IndexOf("白") > -1)
                        //{
                        //    //weather += "|" + strDay + "|" + strDayNight + "|D" + strWeather;
                        //    weather += "|D" + strWeather;
                        //}
                        //else
                        //{
                        //    //weather += "|" + strDay + "|" + strDayNight + "|N" + strWeather;
                        //    weather += "|N" + strWeather;
                        //}
                        //weather += "|" + strImg;
                        weather += "|" + strImg;
                        d2 = true;
                    }
                    TextDetail += strDay + "|" + strDayNight + "|" + strWeather + "|" + strTemperature.Substring(2).Trim() + "|" + strWind + "\n";
                }
                webb.Dispose();
            }
            catch (Exception)
            {
                TextDetail = "获取未来几天天气信息失败！";
            }
            #endregion
            return Text + "\n" + TextDetail;
        }
        #region 之前的做法：读取XML文件，但数据更新不够及时
        //public string GetWeather(string province, string city, string county,out string url)
        //{
        //    XmlDocument xml = new XmlDocument();
        //    xml.Load(this.GetUrl(province, city, county) + "?" + new Random().Next(1, 100000));    //后面加 “？随机数” 是为了防止读取的是“同一个”XML文件而缓存到本地，造成数据不准确  //DateTime.Now.Ticks.ToString()
        //    XmlElement root = xml.DocumentElement;
        //    XmlNodeList citys = root.ChildNodes;
        //    for (int i = 0; i < citys.Count; i++)
        //    {
        //        if (citys[i].Attributes["cityname"].Value == county)
        //        {
        //            string Text = "";
        //            Text += "发布时间：" + citys[i].Attributes["time"].Value + "\n";
        //            Text += "天气情况：" + citys[i].Attributes["stateDetailed"].Value + "\n";
        //            Text += "实时温度：" + citys[i].Attributes["temNow"].Value + "℃" + "\n";
        //            Text += "温度范围：" + citys[i].Attributes["tem1"].Value + "-" + citys[i].Attributes["tem2"].Value + "℃\n";
        //            Text += "湿度：" + citys[i].Attributes["humidity"].Value + "\n";
        //            Text += "风向：" + citys[i].Attributes["windDir"].Value + "\n";
        //            Text += "风力：" + citys[i].Attributes["windPower"].Value;
        //            url = "http://www.weather.com.cn/weather/" + citys[i].Attributes["url"].Value + ".shtml?from=cn";
        //            return Text;
        //        }
        //    }
        //    url = "http://flash.weather.com.cn/wmaps/index.swf?url1=http:%2F%2Fwww.weather.com.cn%2Fweather%2F&url2=.shtml&from=cn";
        //    return "获取当前天气详细数据失败！";
        //}
        #endregion
        #endregion

        #region 设置控件属性
        public void SetControls(Control control, string properties, object value)
        {
            control.GetType().GetProperty(properties).SetValue(control, value, null);
        }

        public void SetControl(Control control, string property, object value)
        {
            if (control.InvokeRequired)
                this.Invoke(new ControlSet(SetControls), new object[] { control, property, value });
            else
                control.GetType().GetProperty(property).SetValue(control, value, null);
        }

        public void SetLink(LinkLabel linkControl, int start, int length, object url)
        {
            linkControl.Links.Clear();
            linkControl.Links.Add(start, length, url);
            //linkControl.Links.GetType().GetMethod("Clear").Invoke(linkControl.Links, null);
            //linkControl.Links.GetType().GetMethod("Add", new Type[] { typeof(int), typeof(int), typeof(object) }).Invoke(linkControl.Links, new object[] { 0, 4, url });
        }
        #endregion

        #region 显示天气查询结果
        /// <summary>
        /// 显示天气查询结果
        /// </summary>
        /// <param name="cityNo">城市编号，为1时在label1显示结果，为2时在label2显示结果</param>
        /// <param name="cityName">城市名称</param>
        /// <param name="result">需要显示出来的结果</param>
        /// <param name="url">详情URL</param>
        /// <param name="weather">天气图标资源文件名称</param>
        public void ShowResult(int cityNo, string cityName, string result, string url, string weather)
        {
            Type type = Type.GetType("Weather.Properties.Resources");
            PropertyInfo tip1 = null;
            PropertyInfo tip2 = null;
            if (weather.Split('|').Length == 2)
            {
                tip1 = type.GetProperty(weather.Split('|')[0].Replace(".gif", ""));
                tip2 = type.GetProperty(weather.Split('|')[1].Replace(".gif", ""));
            }
            switch (this.CityQuery)
            {
                case 1:case 2:
                    this.SetControl(gbTitle, "Width", 213);
                    this.SetControl(gb1, "Visible", false);
                    this.SetControl(gb2, "Location", new Point(5, 58));
                    this.SetControl(this, "Width", 223);
                    this.SetControl(this, "Location", new Point(this.WorkingArea.Right - this.Width, this.WorkingArea.Bottom - this.Height));
                    this.SetControl(gb2, "Text", "[" + cityName + "]天气实况：");
                    this.SetControl(label2, "Text", result);
                    if (llbView2.InvokeRequired)
                        this.Invoke(new LinkControl(SetLink), new object[] { llbView2, 0, 4, url });
                    else
                    {
                        llbView2.Links.Clear();
                        this.llbView2.Links.Add(0, 4, url);
                    }
                    if (tip1 != null)
                        this.SetControl(Pic2, "Image", (Bitmap)tip1.GetValue(null, null));
                    else
                        this.SetControl(Pic2, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[0] + "?" + System.Guid.NewGuid().ToString("N"));
                    if (tip2 != null)
                        this.SetControl(PicBox2, "Image", (Bitmap)tip2.GetValue(null, null));
                    else
                        this.SetControl(PicBox2, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[1] + "?" + System.Guid.NewGuid().ToString("N"));
                    break;
                default:
                    this.SetControl(this, "Width", 442);
                    this.SetControl(this, "Location", new Point(this.WorkingArea.Right - this.Width, this.WorkingArea.Bottom - this.Height));
                    this.SetControl(gb2, "Location", new Point(224, 58));
                    this.SetControl(gbTitle, "Width", 432);
                    this.SetControl(gb1, "Visible", true);
                    if (cityNo == 1)
                    {
                        this.SetControl(gb1, "Text", "[" + cityName + "]天气实况：");
                        this.SetControl(label1, "Text", result);
                        if (llbView1.InvokeRequired)
                            this.Invoke(new LinkControl(SetLink), new object[] { llbView1, 0, 4, url });
                        else
                        {
                            llbView1.Links.Clear();
                            this.llbView1.Links.Add(0, 4, url);
                        }
                        if (tip1 != null)
                            this.SetControl(Pic1, "Image", (Bitmap)tip1.GetValue(null, null));
                        else
                            this.SetControl(Pic1, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[0] + "?" + System.Guid.NewGuid().ToString("N"));
                        if (tip2 != null)
                            this.SetControl(PicBox1, "Image", (Bitmap)tip2.GetValue(null, null));
                        else
                            this.SetControl(PicBox1, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[1] + "?" + System.Guid.NewGuid().ToString("N"));
                    }
                    else
                    {
                        this.SetControl(gb2, "Text", "[" + cityName + "]天气实况：");
                        this.SetControl(label2, "Text", result);
                        if (llbView2.InvokeRequired)
                            this.Invoke(new LinkControl(SetLink), new object[] { llbView2, 0, 4, url });
                        else
                        {
                            llbView2.Links.Clear();
                            this.llbView2.Links.Add(0, 4, url);
                        }
                        if (tip1 != null)
                            this.SetControl(Pic2, "Image", (Bitmap)tip1.GetValue(null, null));
                        else
                            this.SetControl(Pic2, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[0] + "?" + System.Guid.NewGuid().ToString("N"));
                        if (tip2 != null)
                            this.SetControl(PicBox2, "Image", (Bitmap)tip2.GetValue(null, null));
                        else
                            this.SetControl(PicBox2, "ImageLocation", @"http://www.weather.com.cn/m/i/icon_weather/42x30/" + weather.Split('|')[1] + "?" + System.Guid.NewGuid().ToString("N"));
                    }
                    break;
            }
        }
        #endregion

        #region 查看详情链接、立即刷新
        private void llbView1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.llbView1.Links[0].LinkData.ToString());
        }
        private void llbView1_Enter(object sender, EventArgs e)
        {
            this.lblTitle.Focus();
        }

        private void llbView2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.llbView2.Links[0].LinkData.ToString());
        }
        private void llbView2_Enter(object sender, EventArgs e)
        {
            this.lblTitle.Focus();
        }

        private void llbReFlash1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblTitle.Focus();
            try
            {
                string url = "";
                string msg = "";
                string weather = "";
                msg = this.GetWeather(this.City1.Split('|')[0], this.City1.Split('|')[1], this.City1.Split('|')[2], out url, out weather);
                this.ShowResult(1, this.City1.Split('|')[2], msg, url, weather);
            }
            catch (Exception ex)
            {
                this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "出错啦：" + ex.Message, ToolTipIcon.Error);
            }
        }

        private void llbReFlash2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblTitle.Focus();
            try
            {
                string url = "";
                string msg = "";
                string weather = "";
                if (this.CityQuery == 1)
                {
                    msg = this.GetWeather(this.City1.Split('|')[0], this.City1.Split('|')[1], this.City1.Split('|')[2], out url, out weather);
                    this.ShowResult(2, this.City1.Split('|')[2], msg, url, weather);
                }
                else
                {
                    msg = this.GetWeather(this.City2.Split('|')[0], this.City2.Split('|')[1], this.City2.Split('|')[2], out url, out weather);
                    this.ShowResult(2, this.City2.Split('|')[2], msg, url, weather);
                }
            }
            catch (Exception ex)
            {
                this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "出错啦：" + ex.Message, ToolTipIcon.Error);
            }
        }
        #endregion

        #region 获取远程Web服务器时间并计算与本地的时间差
        private void GetRemoteTime()
        {
            DateTime d1 = DateTime.Now;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://flash.weather.com.cn/wmaps/config.xml?" + DateTime.Now.Ticks.ToString());
                request.Timeout = 8000;
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    for (int i = 1; i < response.Headers.Count; i++)
                    {
                        try
                        {
                            DateTime dt = Convert.ToDateTime(response.Headers[i]);
                            DateTime d2 = DateTime.Now;
                            dt += (d2 - d1);
                            this.timeSpan = dt - DateTime.Now;
                            break;
                        }
                        catch (Exception) { }
                    }
                }
                catch (WebException)
                {
                    this.timeSpan = d1 - d1;    //无法获取远程服务器时间时使用本地时间，即时间差为0
                    this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "无法获取远程服务器时间，程序将使用本地时间！", ToolTipIcon.Info);
                }
                if (response != null)
                    response.Close();
            }
            catch (Exception)
            {
                this.timeSpan = d1 - d1;
                this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "获取远程服务器时间时发生错误，程序将使用本地时间！", ToolTipIcon.Info);
            }
        }
        #endregion

        #region 根据中文件颜色获取英文颜色、英文颜色获取中文颜色、根据英文颜色获取颜色
        public string GetColorEN(string ColorCN, string defaultColor)
        {
            switch (ColorCN)
            {
                case "红色":
                    return "Red";
                case "黄色":
                    return "Yellow";
                case "蓝色":
                    return "Blue";
                case "绿色":
                    return "Green";
                case "黑色":
                    return "Black";
                case "白色":
                    return "White";
                default:
                    return defaultColor;
            }
        }

        public string GetColorCN(string ColorEN, string defaultColor)
        {
            switch (ColorEN)
            {
                case "Red":
                    return "红色";
                case "Yellow":
                    return "黄色";
                case "Blue":
                    return "蓝色";
                case "Green":
                    return "绿色";
                case "Black":
                    return "黑色";
                case "White":
                    return "白色";
                default:
                    return defaultColor;
            }
        }

        public Color GetColor(string ColorEN, Color defaultColor)
        {
            switch (ColorEN)
            {
                case "Red":
                    return Color.Red;
                case "Yellow":
                    return Color.Yellow;
                case "Blue":
                    return Color.Blue;
                case "Green":
                    return Color.Green;
                case "Black":
                    return Color.Black;
                case "White":
                    return Color.White;
                default:
                    return defaultColor;
            }
        }

        public string GetColor(string ColorEN, string defaultColor)
        {
            switch (ColorEN)
            {
                case "Red":
                    return "Red";
                case "Yellow":
                    return "Yellow";
                case "Blue":
                    return "Blue";
                case "Green":
                    return "Green";
                case "Black":
                    return "Black";
                case "White":
                    return "White";
                default:
                    return defaultColor;
            }
        }
        #endregion

        #region 用线程代替Timer控件
        private void ThreadTimer()
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    DateTime dt = DateTime.Now + this.timeSpan;
                    if (this.CityQuery == 1 || this.CityQuery == 2)
                    {
                        //this.lblTitle.Text = (dt).ToString("yyyy年MM月dd日 [" + this._nongli + "]\ndddd  HH:mm:ss");
                        this.SetControl(lblTitle, "Text", (dt).ToString("yyyy年MM月dd日 [" + this._nongli + "]\ndddd  HH:mm:ss"));
                    }
                    else
                    {
                        //this.lblTitle.Text = (dt).ToString("yyyy年MM月dd日  [" + this._nongli + "]  dddd  HH:mm:ss");
                        this.SetControl(lblTitle, "Text", (dt).ToString("yyyy年MM月dd日  [" + this._nongli + "]  dddd  HH:mm:ss"));
                    }
                    //this.lblTitle.Top = this.gbTitle.Height / 2 - this.lblTitle.Height / 2 + 3;
                    //this.lblTitle.Left = this.gbTitle.Width / 2 - this.lblTitle.Width / 2;
                    this.SetControl(lblTitle, "Top", this.gbTitle.Height / 2 - this.lblTitle.Height / 2 + 3);
                    this.SetControl(lblTitle, "Left", this.gbTitle.Width / 2 - this.lblTitle.Width / 2);
                }
                catch (Exception ex)
                {
                    this.notifyIcon1.ShowBalloonTip(3000, Application.ProductName, "出错啦：" + ex.Message, ToolTipIcon.Error);
                }
            }
        }
        #endregion

        #region  定时刷新天气实况并计算农历（线程控制）
        private void ReflashWeather()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (this.ReFlashEnable)
                {
                    if (this.reflashTemp >= this.ReFlashSpan)
                    {
                        this.ShowWeather();
                        this.reflashTemp = 0;
                        this.GetRemoteTime();   //重新获取远程服务器与本机的时间差
                    }
                    else
                    {
                        this.reflashTemp++;
                    }
                }
                this.NongLi = this.GetChineseDate(DateTime.Now + this.timeSpan);
            }
        }
        #endregion

        #region 计算农历
        private string GetChineseDate(DateTime dt)
        {
            string nongli = "";
            int cnYear = chineseDate.GetYear(dt);
            int cnMonth = chineseDate.GetMonth(dt);
            int cnDay = chineseDate.GetDayOfMonth(dt);
            int leapMonth = chineseDate.GetLeapMonth(cnYear);
            if (leapMonth > 0)
            {
                if (cnMonth == leapMonth)
                {
                    nongli = "农历" + "闰" + (cnMonth - 1) + "月" + cnDay + "日";
                }
                else if (cnMonth > leapMonth)
                {
                    nongli = "农历" + (cnMonth - 1) + "月" + cnDay + "日";
                }
                else
                {
                    nongli = "农历" + cnMonth + "月" + cnDay + "日";
                }
            }
            else
            {
                nongli = "农历" + cnMonth + "月" + cnDay + "日";
            }
            return nongli;
        }
        #endregion

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);
    }
}
