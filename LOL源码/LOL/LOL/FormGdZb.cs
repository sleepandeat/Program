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
    public partial class FormGdZb : Form
    {
        public string Str = "";
        public string NameURL = "";
        public FormGdZb()
        {
            InitializeComponent();
        }

        private void FormGdZb_Load(object sender, EventArgs e)
        {
            this.plLX.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
            this.plSjT.BackColor = System.Drawing.ColorTranslator.FromHtml("#D8E7F1");
            this.plShengLi.BackColor = System.Drawing.ColorTranslator.FromHtml("#129E0E");
            this.plShiBai.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB2728");
            zd(Str);
        }

        Regex reg;
        //ul数据，li短数据，TxURL头像，ZT状态
        string ul, li, TxURL, ZT;
        int t = 0, i = 0;
        public void zd(string str)
        {
            reg = new Regex(@"<a([\s\S]+?)>([\s\S]+?)（([\s\S]+?)）</a>");
            string name = reg.Match(str).ToString().Replace("</a>", "");
            i = name.LastIndexOf('>');
            this.Text = name.Substring(i, name.Length - i).Replace(">", "");
            //截取<ul>
            reg = new Regex(@"<ul>([\s\S]+?)</ul>");
            ul = reg.Match(str).ToString();

            string input = str.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            string pattern = @"<liid=""([\s\S]+?)"">([\s\S]+?)</li>";
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                t++;
                switch (t)
                {
                    case 1:
                        RzDh(match, this.ycz1, this.picbox1, this.lbZT1, this.lbPp1, this.lbTime1);
                        break;
                    case 2:
                        RzDh(match, this.ycz2, this.picbox2, this.lbZT2, this.lbPp2, this.lbTime2);
                        break;
                    case 3:
                        RzDh(match, this.ycz3, this.picbox3, this.lbZT3, this.lbPp3, this.lbTime3);

                        break;
                    case 4:
                        RzDh(match, this.ycz4, this.picbox4, this.lbZT4, this.lbPp4, this.lbTime4);
                        break;
                    case 5:
                        RzDh(match, this.ycz5, this.picbox5, this.lbZT5, this.lbPp5, this.lbTime5);
                        break;
                    case 6:
                        RzDh(match, this.ycz6, this.picbox6, this.lbZT6, this.lbPp6, this.lbTime6);
                        break;
                    case 7:
                        RzDh(match, this.ycz7, this.picbox7, this.lbZT7, this.lbPp7, this.lbTime7);
                        break;
                    case 8:
                        RzDh(match, this.ycz8, this.picbox8, this.lbZT8, this.lbPp8, this.lbTime8);
                        break;
                    default:
                        break;
                }
            }
        }

        //日志导航
        public void RzDh(Match match, Label ycz, PictureBox picbox, Label lbZT, Label lbPp, Label lbTime)
        {
            li = match.Value.ToString();
            reg = new Regex(@"<liid=""([\s\S]+?)"">");
            ycz.Text = reg.Match(li).ToString().Replace(@"<liid=""", "").Replace(@""">", "");
            reg = new Regex(@"<imgsrc=""([\s\S]+?)""alt=""([\s\S]+?)""title=""([\s\S]+?)""/>");
            TxURL = reg.Match(li).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/champions/", "").Replace(@"""alt=""", "").Replace(@"""title=""", "").Replace(@"""/>", "");
            i = TxURL.LastIndexOf('g');
            TxURL = TxURL.Substring(0, i + 1);
            picbox.Image = Image.FromFile(@"Yx_Tx\" + TxURL);
            reg = new Regex(@"<emclass=""([\s\S]+?)"">([\s\S]+?)</em>");
            ZT = reg.Match(li).ToString().Replace(@"<emclass=""", "").Replace(@""">", "").Replace(@"</em>", "");
            if (ZT == "red失败")
            {
                lbZT.ForeColor = Color.Red;
                lbZT.Text = "失败";
            }
            else
            {
                lbZT.ForeColor = Color.Green;
                lbZT.Text = "成功";
            }
            reg = new Regex(@"<spanclass=""game"">([\s\S]+?)</span>");
            lbPp.Text = reg.Match(li).ToString().Replace(@"<spanclass=""game"">", "").Replace(@"</span>", "");
            reg = new Regex(@"</span>([\s\S]+?)</p></li>");
            lbTime.Text = reg.Match(li).ToString().Replace(@"</span>&nbsp;", "").Replace(@"</p></li>", "");
        }

        #region 特效

        private void p1_MouseEnter(object sender, EventArgs e)
        {
            this.p1.BackColor = Color.White;
        }

        private void p1_MouseLeave(object sender, EventArgs e)
        {
            this.p1.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p2_MouseEnter(object sender, EventArgs e)
        {
            this.p2.BackColor = Color.White;
        }

        private void p2_MouseLeave(object sender, EventArgs e)
        {
            this.p2.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p3_MouseEnter(object sender, EventArgs e)
        {
            this.p3.BackColor = Color.White;
        }

        private void p3_MouseLeave(object sender, EventArgs e)
        {
            this.p3.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p4_MouseLeave(object sender, EventArgs e)
        {
            this.p4.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p4_MouseEnter(object sender, EventArgs e)
        {
            this.p4.BackColor = Color.White;
        }

        private void p5_MouseEnter(object sender, EventArgs e)
        {
            this.p5.BackColor = Color.White;
        }

        private void p5_MouseLeave(object sender, EventArgs e)
        {
            this.p5.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p6_MouseLeave(object sender, EventArgs e)
        {
            this.p6.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void p6_MouseEnter(object sender, EventArgs e)
        {
            this.p6.BackColor = Color.White;
        }

        private void p7_MouseEnter(object sender, EventArgs e)
        {
            this.p7.BackColor = Color.White;
        }

        private void p7_MouseLeave(object sender, EventArgs e)
        {
            this.p7.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void picbox8_MouseLeave(object sender, EventArgs e)
        {
            this.p8.BackColor = System.Drawing.ColorTranslator.FromHtml("#cddee8");
        }

        private void picbox8_MouseEnter(object sender, EventArgs e)
        {
            this.p8.BackColor = Color.White;
        }

        #endregion

        //获取选中日志
        string zdstr;
        HttpWebRequest requset = null;
        HttpWebResponse response = null;
        Stream stream;
        string Cookiesstr = string.Empty;
        CookieContainer cc;
        string strss;
        RegexOptions options;
        Regex regex;
        MatchCollection matches;
        public string Hq_Rz(string id)
        {
            i = NameURL.LastIndexOf('?');
            strss = NameURL.Substring(i, NameURL.Length - i).Replace("?", "");
            //获取信息
            string gethost = string.Empty;
            cc = new CookieContainer();
            try
            {
                //第一次POST请求
                string postdata = "";
                string LoginUrl = "http://lolbox.duowan.com/matchList/ajaxMatchDetail2.php?matchId=" + id.Replace("cli", "") + "&" + strss;
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
                //登陆成功。
                return content;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //单个日志
        string tr, txurl, Txpic, ulzb, imgsrc,imgzbsrc;
        public void WjRz(int tt,Match match, PictureBox picBoxTx, Label lnWj, Label lbjq, Label lbssz, PictureBox picboxZB1, PictureBox picboxZB2, PictureBox picboxZB3, PictureBox picboxZB4, PictureBox picboxZB5, PictureBox picboxZB6, PictureBox picboxZB7) 
        {

            tr = match.Value.ToString().Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            reg = new Regex(@"<img([\s\S]+?)/>");
            txurl = reg.Match(tr).ToString().Replace(@"<imgclass=""avatar""src=""http://img.lolbox.duowan.com/champions/", "")
                .Replace(@"""data-playerName=""", "").Replace(@"""data-indent=""" + tt + "", "").Replace(@"""/>", "");
            i = txurl.LastIndexOf('.');
            Txpic = txurl.Substring(0, i + 4);
            picBoxTx.Image = Image.FromFile(@"Yx_Tx\" + Txpic);
            i = txurl.LastIndexOf('.');
            lnWj.Text = txurl.Substring(i, txurl.Length - i).Replace(".jpg", "");
            reg = new Regex(@"<tdclass=""col2"">([\s\S]+?)</td>");
            lbjq.Text = reg.Match(tr).ToString().Replace(@"<tdclass=""col2"">", "").Replace("</td>", "");
            reg = new Regex(@"<tdclass=""col3"">([\s\S]+?)</td>");
            lbssz.Text = reg.Match(tr).ToString().Replace(@"<tdclass=""col3"">", "").Replace("</td>", "");
            reg = new Regex(@"<ulclass=""chuzhuang"">([\s\S]+?)</ul>");
            ulzb = reg.Match(tr).ToString();

            string pattern = @"<li>([\s\S]+?)</li>";
            options = RegexOptions.None;
            regex = new Regex(pattern, options);
            matches = regex.Matches(ulzb);
            t = 0;
            string str;
            foreach (Match match1 in matches)
            {
                t++;
                switch (t)
                {
                    case 1:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB1.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 2:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB2.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 3:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB3.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 4:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB4.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 5:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB5.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 6:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB6.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    case 7:
                        imgsrc = match1.Value.ToString().Replace("<li>", "").Replace("</li>", "");
                        reg = new Regex(@"<img([\s\S]+?)/>");
                        imgzbsrc = reg.Match(imgsrc).ToString().Replace(@"<imgsrc=""http://img.lolbox.duowan.com/zb/", "").Replace(@"""/>", "").Replace(@"""title=""", "");
                        i = imgzbsrc.LastIndexOf('g');
                        str=imgzbsrc.Substring(0, i + 1);
                        picboxZB7.Image = Image.FromFile(@"Yx_Tx\" + str);
                        break;
                    default:
                        break;
                }
            }
        }

        //p1
        string RzStr = "";
        int tt = 0;
        int wt = 0;
        private void p1_Click(object sender, EventArgs e)
        {
            Pk(this.ycz1.Text);
        }

        //p2
        private void p2_Click(object sender, EventArgs e)
        {
            Pk(this.ycz2.Text);
        }

        //p3
        private void p3_Click(object sender, EventArgs e)
        {
            Pk(this.ycz3.Text);
        }


        public void Pk(string id) 
        {
            RzStr = Hq_Rz(id);
            reg = new Regex(@"<div class=""r-top"">([\s\S]+?)</div>");
            string span = reg.Match(RzStr).ToString().Replace(@"<div class=""r-top"">", "").Replace(@"</div>", "");
            string pattern = @"<span>([\s\S]+?)</span>";
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(span);
            t = 0;
            foreach (Match match in matches)
            {
                t++;
                switch (t)
                {
                    case 1:
                        this.lbLx.Text = match.Value.ToString().Replace("<span>", "").Replace("</span>", "");
                        break;
                    case 2:
                        this.lbSc.Text = match.Value.ToString().Replace("<span>", "").Replace("</span>", "");
                        break;
                    case 3:
                        this.lbJs.Text = match.Value.ToString().Replace("<span>", "").Replace("</span>", "");
                        break;
                    case 4:
                        this.lbRt.Text = match.Value.ToString().Replace("<span>", "").Replace("</span>", "");
                        break;
                    case 5:
                        this.lbJq.Text = match.Value.ToString().Replace("<span>", "").Replace("</span>", "");
                        break;
                    default:
                        break;
                }
            }

            pattern = @"<tr class="""" >([\s\S]+?)</tr>";
            options = RegexOptions.None;
            regex = new Regex(pattern, options);
            matches = regex.Matches(RzStr.Replace("double-line", ""));

            t = 0;
            foreach (Match match in matches)
            {
                wt++;
                tt++;
                switch (wt)
                {
                    case 1:
                        WjRz(tt, match, this.picBoxTx1, lnWj1, this.lbJq1, this.lbssz1, this.picboxZBw1c1, this.picboxZBw1c2, this.picboxZBw1c3, this.picboxZBw1c4, this.picboxZBw1c5, this.picboxZBw1c6, this.picboxZBw1c7);
                        break;
                    case 2:
                        WjRz(tt, match, this.picBoxTx2, lnWj2, this.lbJq2, this.lbssz2, this.picboxZBw2c1, this.picboxZBw2c2, this.picboxZBw2c3, this.picboxZBw2c4, this.picboxZBw2c5, this.picboxZBw2c6, this.picboxZBw2c7);
                        break;
                    case 3:
                        WjRz(tt, match, this.picBoxTx3, lnWj3, this.lbJq3, this.lbssz3, this.picboxZBw3c1, this.picboxZBw3c2, this.picboxZBw3c3, this.picboxZBw3c4, this.picboxZBw3c5, this.picboxZBw3c6, this.picboxZBw3c7);
                        break;
                    case 4:
                        WjRz(tt, match, this.picBoxTx4, lnWj4, this.lbJq4, this.lbssz4, this.picboxZBw4c1, this.picboxZBw4c2, this.picboxZBw4c3, this.picboxZBw4c4, this.picboxZBw4c5, this.picboxZBw4c6, this.picboxZBw4c7);
                        break;
                    case 5:
                        WjRz(tt, match, this.picBoxTx5, lnWj5, this.lbJq5, this.lbssz5, this.picboxZBw5c1, this.picboxZBw5c2, this.picboxZBw5c3, this.picboxZBw5c4, this.picboxZBw5c5, this.picboxZBw5c6, this.picboxZBw5c7);
                        break;
                    case 6:
                        WjRz(tt, match, this.picBoxTx6, lnWj6, this.lbJq6, this.lbssz6, this.picboxZBw6c1, this.picboxZBw6c2, this.picboxZBw6c3, this.picboxZBw6c4, this.picboxZBw6c5, this.picboxZBw6c6, this.picboxZBw6c7);
                        break;
                    case 7:
                        WjRz(tt, match, this.picBoxTx7, lnWj7, this.lbJq7, this.lbssz7, this.picboxZBw7c1, this.picboxZBw7c2, this.picboxZBw7c3, this.picboxZBw7c4, this.picboxZBw7c5, this.picboxZBw7c6, this.picboxZBw7c7);
                        break;
                    case 8:
                        WjRz(tt, match, this.picBoxTx8, lnWj8, this.lbJq8, this.lbssz8, this.picboxZBw8c1, this.picboxZBw8c2, this.picboxZBw8c3, this.picboxZBw8c4, this.picboxZBw8c5, this.picboxZBw8c6, this.picboxZBw8c7);
                        break;
                    case 9:
                        WjRz(tt, match, this.picBoxTx9, lnWj9, this.lbJq9, this.lbssz9, this.picboxZBw9c1, this.picboxZBw9c2, this.picboxZBw9c3, this.picboxZBw9c4, this.picboxZBw9c5, this.picboxZBw9c6, this.picboxZBw9c7);
                        break;
                    case 10:
                        WjRz(tt, match, this.picBoxTx10, lnWj10, this.lbJq10, this.lbssz10, this.picboxZBw10c1, this.picboxZBw10c2, this.picboxZBw10c3, this.picboxZBw10c4, this.picboxZBw10c5, this.picboxZBw10c6, this.picboxZBw10c7);
                        wt = 0;
                        tt = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        //p4
        private void p4_Click(object sender, EventArgs e)
        {
            Pk(this.ycz4.Text);
        }

        //p5
        private void p5_Click(object sender, EventArgs e)
        {
            Pk(this.ycz5.Text);
        }

        //p6
        private void p6_Click(object sender, EventArgs e)
        {
            Pk(this.ycz6.Text);
        }

        //p7
        private void p7_Click(object sender, EventArgs e)
        {
            Pk(this.ycz7.Text);
        }

        //p8
        private void p8_Click(object sender, EventArgs e)
        {
            Pk(this.ycz8.Text);
        }

    }
}
