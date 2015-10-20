using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace LOL
{
    public partial class Form3 : Form
    {
        //获取上一个窗体传入的数据
        public string ss = "";
        //获取网页信息的链接
        public string src = "";
        //查询 游戏名字
        public string name = "";
        public Form3()
        {
            InitializeComponent();
        }


        int List_1 = 0;
        ListViewItem lvi;
        Regex reg;
        string Sub;
        int i;
        string result;
        //基本信息
        public void test_1(string ss)
        {
            //头像
            reg = new Regex(@"<div class=""avatar"">([\s\S]+?)</div>");
            Sub = reg.Match(ss).ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "")
                .Replace(@"<divclass=""avatar"">", "")
                .Replace(@"<ahref=""" + src.Replace("playerDetail", "matchList") + @""">", "")
                .Replace(@"<imgsrc=""http://img.lolbox.duowan.com/profileIcon/", "")
                .Replace(@"/></a>", "").Replace(@"""<span></span>", "");
            i = Sub.LastIndexOf('g');
            result = Sub.Substring(0, i + 1).Replace("<em>", "");
            this.picboxTx.Image = Image.FromFile(@"Tx\" + result);
            //等级
            Sub = Sub.Replace("</em></div>", "");
            i = Sub.LastIndexOf('>');
            result = Sub.Substring(i, Sub.Length - i).Replace(">", "");
            this.lbDJ.Text = result;
            //名字
            reg = new Regex(@"<a id=""playerNameLink"">([\s\S]+?)</a>");
            this.lbName.Text = reg.Match(ss.Replace(@" href=""" + src + @""" title=""" + name + @"""", "")).ToString().Trim().Replace(@"<a id=""playerNameLink"">", "").Replace("</a>", "");
            //被赞
            reg = new Regex(@"<div title=""此玩家在游戏中被队友给的好评数，只有使用lol盒子的玩家才可以进行评价"">([\s\S]+?)</div>");
            this.lbBZ.Text = reg.Match(ss).ToString().Replace(@"<div title=""此玩家在游戏中被队友给的好评数，只有使用lol盒子的玩家才可以进行评价"">", "").Replace("</div>", "");
            //被黑
            reg = new Regex(@"<div title=""此玩家在游戏中被多少人拉黑，只有使用lol盒子的玩家才可以进行拉黑操作"">([\s\S]+?)</div>");
            this.lbBH.Text = reg.Match(ss).ToString().Replace(@"<div title=""此玩家在游戏中被多少人拉黑，只有使用lol盒子的玩家才可以进行拉黑操作"">", "").Replace("</div>", "");
            //战斗力
            reg = new Regex(@"<div class=""fighting"" title='点击查看战斗力详细计算方法'>([\s\S]+?)</div>");
            Sub = reg.Match(ss).ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "")
                .Replace(@"<divclass=""fighting""title='点击查看战斗力详细计算方法'><p><strong><ahref='http://lol.duowan.com/1112/187633871943.html?", "")
                .Replace(@"&openmode=default'target='_blank'style='color:white;cursor:help;'>战斗力</a></strong></p><p><em><spantitle='", "")
                .Replace(@"</span></em></p></div>", "");
            i = Sub.LastIndexOf('>');
            result = Sub.Substring(i, Sub.Length - i).Replace(">", "");
            this.lbZDL.Text = result;
        }
        //匹配模式
        public void test_2(string ss)
        {
            this.listView1.Items.Clear();  //只移除所有的项。 
            this.listView1.BeginUpdate();
            int t = 0;
            string input = ss.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            string pattern = @"<td>([\s\S]+?)</td>";
            input = input.Trim().Replace("\t", "");
            input = input.Replace("\n", "");
            input = input.Replace("\r", "");
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);
            int xz = 0;
            foreach (Match match in matches)
            {

                if (xz < 2)
                {
                    t++;
                    switch (t)
                    {
                        case 1:
                            lvi = new ListViewItem();
                            //lvi.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标 
                            lvi.Text = match.Value.Replace("<td>", "").Replace("</td>", "");
                            break;
                        case 2:
                            lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 3:
                            lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 4:
                            lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 5:
                            lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 6:
                            lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", "").Insert(5, " "));
                            break;
                        default:
                            break;
                    }

                    if (t == 6)
                    {

                        t = 0;
                        this.listView1.Items.Add(lvi);
                        xz++;
                        if (xz == 3)
                        {
                            this.listView1.EndUpdate();
                            return;
                        }
                    }

                }
                else
                {
                    if (match.Value != @"<td></td></tr><tr><tdcolspan=""3""><pclass=""note""style=""color:#999999"">目前仅显示战斗力大于5000的玩家的排名数据、且最多显示前5万名。</p></td>")
                    {
                        List_1 = 3;
                        t++;
                        switch (t)
                        {
                            case 1:
                                lvi = new ListViewItem();
                                //lvi.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标 
                                lvi.Text = match.Value.Replace("<td>", "").Replace("</td>", "");
                                break;
                            case 2:
                                lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                                break;
                            case 3:
                                lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                                break;
                            case 4:
                                lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                                break;
                            case 5:
                                lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                                break;
                            case 6:
                                lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", "").Insert(5, " "));
                                break;
                            default:
                                break;
                        }

                        if (t == 6)
                        {

                            t = 0;
                            this.listView1.Items.Add(lvi);
                            xz++;
                            if (xz == 3)
                            {
                                this.listView1.EndUpdate();
                                return;
                            }
                        }
                    }
                    else
                    {
                        List_1 = 2;
                        this.listView1.EndUpdate();
                        return;
                    }
                }



            }


            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 

        }
        //最近比赛
        ListViewItem lvi_2;
        public void test_3(string ss)
        {
            this.listView2.Items.Clear();  //只移除所有的项。 
            this.listView2.BeginUpdate();
            int t = 0;
            string input = ss.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(@"<td></td></tr><tr><tdcolspan=""3""><pclass=""note""style=""color:#999999"">目前仅显示战斗力大于5000的玩家的排名数据、且最多显示前5万名。</p></td>", "");
            string pattern = @"<td>([\s\S]+?)</td>";
            input = input.Trim().Replace("\t", "");
            input = input.Replace("\n", "");
            input = input.Replace("\r", "");
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);
            int qs = 0;
            foreach (Match match in matches)
            {

                if (qs < List_1)
                {
                    t++;
                    switch (t)
                    {
                        case 1:
                            lvi_2 = new ListViewItem();
                            //lvi.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标 
                            lvi_2.Text = match.Value.Replace("<td>", "").Replace("</td>", "");
                            break;
                        case 2:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 3:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 4:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 5:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 6:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            qs++;
                            break;
                        default:
                            break;
                    }

                    if (t == 6)
                    {
                        if (qs <= 3)
                        {
                            //this.listView2.Items.Clear();  //只移除所有的项。 
                            //this.listView2.BeginUpdate();
                            t = 0;
                        }
                    }
                }
                else
                {
                    t++;
                    switch (t)
                    {
                        case 1:
                            lvi_2 = new ListViewItem();
                            lvi_2.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标 
                            Sub = match.Value.Replace("<td>", "").Replace("</td>", "").Replace(@"<imgsrc=""http://img.lolbox.duowan.com/champions/", "").Replace(@"""title=""", "").Replace(@"""alt="""">", "");
                            i = Sub.LastIndexOf('g');
                            result = Sub.Substring(0, i + 1);
                            //名字
                            i = Sub.LastIndexOf('g');
                            result = Sub.Substring(i, Sub.Length - i).Replace("g", "");
                            lvi_2.Text = result;
                            break;
                        case 2:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));
                            break;
                        case 3:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", "").Replace(@"<emclass=""green"">", "").Replace(@"<emclass=""red"">", "").Replace("</em>", ""));
                            break;
                        case 4:
                            lvi_2.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", "").Insert(5, " "));
                            break;
                        default:
                            break;
                    }

                    if (t == 4)
                    {
                        t = 0;
                        this.listView2.Items.Add(lvi_2);
                    }
                }
            }
            this.listView2.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }
        //战斗日志
        string zdstr;
        HttpWebRequest requset = null;
        HttpWebResponse response = null;
        Stream stream;
        string Cookiesstr = string.Empty;
        CookieContainer cc;
        string strss;
        //更多战报
        public string test_4(string ss)
        {
            reg = new Regex(@"<div class=""recent-hd"">([\s\S]+?)</div>");
            zdstr = reg.Match(ss).ToString().Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "")
                .Replace(@"<divclass=""recent-hd""><h3>最近比赛</h3><ahref=""", "")
                .Replace(@""">更多战报&gt;&gt;</a></div>", "");
            //获取信息
            string gethost = string.Empty;
            cc = new CookieContainer();
            try
            {
                //第一次POST请求
                string postdata = "";
                string LoginUrl = "http://lolbox.duowan.com/" + zdstr;
                requset = (HttpWebRequest)WebRequest.Create(LoginUrl);//实例化Web访问类
                requset.Method = "POST";//数据请求方式为POST
                //模拟头
                requset.ContentType = "application/x-www-form-urlencoded";
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                requset.ContentLength = postdatabytes.Length;

                requset.AllowAutoRedirect = false;
                requset.CookieContainer = cc;
                requset.KeepAlive = true;

                //提交请求
                stream = requset.GetRequestStream();
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接受响应
                response = (HttpWebResponse)requset.GetResponse();
                //保存返回cookies
                response.Cookies = requset.CookieContainer.GetCookies(requset.RequestUri);
                CookieCollection cook = response.Cookies;
                string strook = requset.CookieContainer.GetCookieHeader(requset.RequestUri);
                Cookiesstr = strook;
                //取第一次GET跳转地址
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd();
                response.Close();
                strss = content;
                //登陆成功。

                return content;
                
            }
            catch (Exception)
            {

                throw;
            }
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = name + " - 详细信息";

            //模式
            this.listView1.Columns.Add("类型", 120, HorizontalAlignment.Center); //一步添加
            this.listView1.Columns.Add("总场次", 100, HorizontalAlignment.Center); //一步添加
            this.listView1.Columns.Add("胜率", 100, HorizontalAlignment.Center); //一步添加
            this.listView1.Columns.Add("胜场", 100, HorizontalAlignment.Center); //一步添加
            this.listView1.Columns.Add("负场", 100, HorizontalAlignment.Center); //一步添加
            this.listView1.Columns.Add("更新时间", 150, HorizontalAlignment.Center); //一步添加

            //战绩
            this.listView2.Columns.Add("英雄", 120, HorizontalAlignment.Center); //一步添加
            this.listView2.Columns.Add("模式", 120, HorizontalAlignment.Center); //一步添加
            this.listView2.Columns.Add("结果", 120, HorizontalAlignment.Center); //一步添加
            this.listView2.Columns.Add("时间", 120, HorizontalAlignment.Center); //一步添加


            test_1(ss);
            test_2(ss);
            test_3(ss);
        }

        //点击 战斗日志
        string zdSrc;
        private void lbGdZb_Click(object sender, EventArgs e)
        {
            zdSrc = test_4(ss);
            FormGdZb fgd = new FormGdZb();
            fgd.Str = zdSrc;
            fgd.NameURL = zdstr;
            fgd.ShowDialog();
        }
    }
}
