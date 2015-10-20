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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnDL_Click(object sender, EventArgs e)
        {
            MnFw();
        }

        ListViewItem lvi;
        HttpWebRequest requset = null;
        HttpWebResponse response = null;
        Stream stream;
        string Cookiesstr = string.Empty;
        CookieContainer cc;
        string strss;
        //查询 游戏名字 获取网页信息
        public void MnFw()
        {
            string gethost = string.Empty;
            cc = new CookieContainer();
            try
            {
                //第一次POST请求
                string postdata = "keyWords=" + this.txtName.Text + "";
                string LoginUrl = "http://lolbox.duowan.com/playerList.php";
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
                DTView(strss);
            }
            catch (Exception)
            {

                throw;
            }

        }

        int i;
        string result;
        //将数据显示在 ListView 上
        public void DTView(string str)
        {
            this.listView1.Items.Clear();  //只移除所有的项。 
            this.listView1.BeginUpdate();
            int t = 0;
            string input = str.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(@"class=""left""", "") ;
            string pattern = @"<td>([\s\S]+?)</td>";
            input = input.Trim().Replace("\t", "");
            input = input.Replace("\n", "");
            input = input.Replace("\r", "");
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(pattern, options);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {

                t++;
                switch (t)
                {
                    case 1:
                        lvi = new ListViewItem();
                        //lvi.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标 
                        i = match.Value.Replace("<td>", "").Replace("</td>", "").Replace("</a>","").LastIndexOf('>');
                        result = match.Value.Replace("<td>", "").Replace("</td>", "").Replace("</a>", "").Remove(0, i+1);
                        lvi.Text = result;
                        lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", "").Replace(@"<ahref=""", "").Replace(@""">" + this.txtName.Text + "</a>", ""));
                        break;
                    case 2:
                        lvi.SubItems.Add(match.Value.Replace("<td>", "").Replace("</td>", ""));    
                        break;
                    default:
                        break;
                }

                if (t == 2)
                {
                    t = 0;
                    this.listView1.Items.Add(lvi);
                }

            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("玩家名字", 150, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("玩家src",0, HorizontalAlignment.Left); //隐藏值 不能暴露，内置http链接
            this.listView1.Columns.Add("服务器", 150, HorizontalAlignment.Left); //一步添加
        }


        //点击ListView后 跳转下一个窗体  传送 数据
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                //获取订单id的连接
                string CkDd_LJ = listView1.SelectedItems[0].SubItems[1].Text;
                string DDss = DDGLQ_FF(CkDd_LJ);
                if (DDss == "" || DDss == null)
                {
                    MessageBox.Show("请重新打一场匹配恢复战绩。");
                }
                else
                {
                    Form3 f3 = new Form3();
                    f3.ss = DDss;
                    f3.src = CkDd_LJ;
                    f3.name = this.txtName.Text;
                    f3.ShowDialog();
                }
                
            }
        }


        string ss;
        /// <summary>
        /// 战绩访问管理器  
        /// 
        /// 传入src后 读取网页信息
        /// </summary>
        /// <param name="LJ"></param>
        /// <returns></returns>
        public string DDGLQ_FF(string LJ)
        {
            requset = (HttpWebRequest)WebRequest.Create("http://lolbox.duowan.com/" + LJ);
            requset.Method = "GET";
            requset.KeepAlive = true;
            requset.Headers.Add("Cookie:" + Cookiesstr);
            requset.CookieContainer = cc;
            requset.AllowAutoRedirect = false;
            response = (HttpWebResponse)requset.GetResponse();
            Cookiesstr = requset.CookieContainer.GetCookieHeader(requset.RequestUri);
            StreamReader sr1 = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            ss = sr1.ReadToEnd();
            sr1.Close();
            response.Close();

            return ss;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
