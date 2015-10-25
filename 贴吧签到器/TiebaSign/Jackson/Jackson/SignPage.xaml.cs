using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.IsolatedStorage;
using Coding4Fun.Toolkit.Controls;
using System.Threading;
using System.Windows.Media.Imaging;
using ImageTools.IO.Gif;
using ImageTools.IO.Bmp;
using ImageTools.IO.Jpeg;
using ImageTools.IO.Png;
using Microsoft.Xna.Framework.GamerServices;
using System.Diagnostics;

namespace Jackson
{
    public partial class SignPage : PhoneApplicationPage
    {
        public SignPage()
        {
            InitializeComponent();
        }

        private string userName = "";
        private string password = "";
        private string verifyCode = "";
        private string imageUrl = "";
        private List<ListItem> displayList = new List<ListItem>();
        private List<string> numList = new List<string>();
        private List<string> urlList = new List<string>();
        private List<string> gradeList = new List<string>();
        private List<string> valueList = new List<string>();
        private List<string> updateInfoList = new List<string>();
        private List<string> nameList = new List<string>();
        private static CookieContainer cc = null;
        // 单个贴吧页面的url省略的部分
        private string singleTiebaPageUrlPart = "";

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string un = "";
            string pw = "";
            if (NavigationContext.QueryString.TryGetValue("username", out un))
                userName = HttpUtility.UrlEncode(un);
            if (NavigationContext.QueryString.TryGetValue("password", out pw))
                password = HttpUtility.UrlEncode(pw);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // 移除后退堆栈内的所有页面
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void GoSignButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Guide.IsScreenSaverEnabled = false;
            displayList.Clear();
            TiebaList.ItemsSource = null;
            DoHttpWebRequestPOST("http://wappass.baidu.com/wp/login?uname_login=1");
            GoSignButton.Visibility = Visibility.Collapsed;
        }

        #region 使用POST方式登录
        private void DoHttpWebRequestPOST(string paraUrl)
        {
            string url = paraUrl;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (cc == null)
                cc = new CookieContainer();
            request.CookieContainer = cc;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.76 Safari/537.36";
            request.Method = "POST";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            //返回异步操作的状态
            request.BeginGetRequestStream(new AsyncCallback(RequestStreamCallbackPOST), request);
        }

        private void RequestStreamCallbackPOST(IAsyncResult result)
        {

            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            Stream postStream = request.EndGetRequestStream(result);
            //POST提交服务器的资源
            string PostData = "username=" + userName + "&password=" + password
                + "&submit=%E7%99%BB%E5%BD%95&quick_user=0&isphone=0&sp_login=waprate&uname_login=&loginmerge=1&vcodestr=";
            Dispatcher.BeginInvoke(() =>
            {
                ToastPrompt tp = new ToastPrompt();
                tp.Message = "正在登录";
                tp.Show();
            });
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(PostData);
            postStream.Write(byteArray, 0, PostData.Length);
            postStream.Close();
            request.BeginGetResponse(new AsyncCallback(ResponseCallbackPOST), request);
        }

        private void ResponseCallbackPOST(IAsyncResult result)
        {
            string webPageContentString = "";
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                WebResponse response = request.EndGetResponse(result);
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        webPageContentString = reader.ReadToEnd();
                    }
                }
                FindTiebaEntrance(webPageContentString);
            }
            catch
            {
                if (webPageContentString.Contains("请您输入验证码"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "这次登录需要验证码哦！";
                        tp.Show();
                    });
                    FindVerifyCodeImageUrl(webPageContentString);
                }
                else if (webPageContentString.Contains("您输入的密码有误"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "登录失败，请返回检查一下用户名和密码！";
                        tp.Show();
                    });
                }
                else
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "未知错误，请返回上一页面重试一下吧！";
                        tp.Show();
                    });
                }
            }
        }
        #endregion

        #region 使用POST方式登录WithVerfyCode
        private void DoHttpWebRequestPOSTWithVerifyCode(string paraUrl)
        {
            string url = paraUrl;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (cc == null)
                cc = new CookieContainer();
            request.CookieContainer = cc;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.76 Safari/537.36";
            request.Method = "POST";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            //返回异步操作的状态
            request.BeginGetRequestStream(new AsyncCallback(RequestStreamCallbackPOSTWithVerifyCode), request);
        }

        private void RequestStreamCallbackPOSTWithVerifyCode(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            Stream postStream = request.EndGetRequestStream(result);
            //POST提交服务器的资源
            string PostData = "username=" + userName + "&password=" + password + "&verifycode=" + verifyCode
                + "&submit=%E7%99%BB%E5%BD%95&quick_user=0&isphone=0&sp_login=waprate&uname_login=&loginmerge=1&vcodestr="
                + imageUrl.Substring(imageUrl.IndexOf('?') + 1);
            Dispatcher.BeginInvoke(() =>
            {
                ToastPrompt tp = new ToastPrompt();
                tp.Message = "正在登录";
                tp.Show();
            });
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(PostData);
            postStream.Write(byteArray, 0, PostData.Length);
            postStream.Close();
            request.BeginGetResponse(new AsyncCallback(ResponseCallbackPOSTWithVerifyCode), request);
        }

        private void ResponseCallbackPOSTWithVerifyCode(IAsyncResult result)
        {
            string webPageContentString = "";
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                WebResponse response = request.EndGetResponse(result);
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        webPageContentString = reader.ReadToEnd();
                    }
                }
                FindTiebaEntrance(webPageContentString);
            }
            catch
            {
                if (webPageContentString.Contains("下次再绑定"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "百度网站提示需要绑定手机或邮箱才能继续，请自行绑定后重试！";
                        tp.TextWrapping = TextWrapping.Wrap;
                        tp.Show();
                    });
                }
                else if (webPageContentString.Contains("请您输入验证码"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "这次登录需要验证码哦！";
                        tp.Show();
                    });
                    FindVerifyCodeImageUrl(webPageContentString);
                }
                else if (webPageContentString.Contains("您输入的验证码有误"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "验证码输错了，返回重试一下吧！";
                        tp.Show();
                    });
                }
                else if (webPageContentString.Contains("您输入的密码有误"))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "登录失败，请返回检查一下用户名和密码！";
                        tp.Show();
                    });
                }
                else
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        ToastPrompt tp = new ToastPrompt();
                        tp.Message = "未知错误，请返回上一页面重试一下吧！";
                        tp.Show();
                    });
                }
            }
        }

        #endregion

        #region 获取并输入验证码
        private void FindVerifyCodeImageUrl(string s)
        {
            string rs = "(请您输入验证码)(.*?)(验证码：<img src=\")(.*?)(\" alt=\"wait...\")";
            Regex r = new Regex(rs, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(s);
            for (; m.Success; m = m.NextMatch())
            {
                imageUrl = m.Groups[4].ToString();
            }
            ShowVerifyCodeInput(imageUrl);
        }

        private void ShowVerifyCodeInput(string imgUrl)
        {
            Dispatcher.BeginInvoke(() =>
            {
                VerifyCodeStack.Visibility = Visibility.Visible;
                ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
                ImageTools.IO.Decoders.AddDecoder<BmpDecoder>();
                ImageTools.IO.Decoders.AddDecoder<JpegDecoder>();
                ImageTools.IO.Decoders.AddDecoder<PngDecoder>();
                ImageTools.ExtendedImage img = new ImageTools.ExtendedImage();
                img.UriSource = new Uri(imgUrl, UriKind.RelativeOrAbsolute);
                VerifyCodeImage.Source = img;
            });
        }

        private void VerifyCodeConfirmButtom_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            verifyCode = VerifyCode.Text;
            DoHttpWebRequestPOSTWithVerifyCode("http://wappass.baidu.com/passport/login");
            Dispatcher.BeginInvoke(() =>
            {
                VerifyCodeStack.Visibility = Visibility.Collapsed;
            });
        }
        #endregion

        #region 从登陆成功后返回的页面中找到贴吧的入口链接
        private void FindTiebaEntrance(string s)
        {
            string tiebaUrl = "";
            string rs = "(tieba.baidu.com)(.*?)(\">贴吧)";
            Regex r = new Regex(rs, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(s);
            for (; m.Success; m = m.NextMatch())
            {
                tiebaUrl = "http://waptieba.baidu.com" + m.Groups[2].ToString();
            }
            GetTiebaMainPage(tiebaUrl);
        }
        #endregion

        #region 获取贴吧主页
        private void GetTiebaMainPage(string tiebaUrl)
        {
            string url = tiebaUrl;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (cc == null)
                cc = new CookieContainer();
            request.CookieContainer = cc;
            request.Method = "GET";
            //返回异步操作的状态
            IAsyncResult result = (IAsyncResult)request.BeginGetResponse(GetTiebaMainPageResponse, request);
        }

        private void GetTiebaMainPageResponse(IAsyncResult result)
        {
            string webPageContentString = "";
            //获取异步操作返回的的信息
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            //结束对 Internet 资源的异步请求
            WebResponse response = request.EndGetResponse(result);
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    webPageContentString = reader.ReadToEnd();
                }
            }
            FindTiebaListEntrance(webPageContentString);
        }
        #endregion

        #region 在贴吧主页中找到关注的贴吧列表入口链接
        private void FindTiebaListEntrance(string s)
        {
            int indexOfFavor = s.IndexOf("favorite");
            s = s.Remove(indexOfFavor + 8);
            int indexOfLastHttp = s.LastIndexOf("http");
            s = s.Substring(indexOfLastHttp);
            // 获得单个贴吧页面的url省略的部分
            int indexOfLastTn = s.LastIndexOf("m?tn");
            singleTiebaPageUrlPart = s.Remove(indexOfLastTn);
            GetTiebaList(s);
        }
        #endregion

        #region 获取贴吧列表页面
        private void GetTiebaList(string tiebaUrl)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ToastPrompt tp = new ToastPrompt();
                tp.Message = "正在获取贴吧列表";
                tp.Show();
            });
            string url = tiebaUrl;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (cc == null)
                cc = new CookieContainer();
            request.CookieContainer = cc;
            request.Method = "GET";
            //返回异步操作的状态
            IAsyncResult result = (IAsyncResult)request.BeginGetResponse(GetTiebaListResponse, request);
        }

        private void GetTiebaListResponse(IAsyncResult result)
        {
            string webPageContentString = "";
            //获取异步操作返回的的信息
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            //结束对 Internet 资源的异步请求
            WebResponse response = request.EndGetResponse(result);
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    webPageContentString = reader.ReadToEnd();
                }
            }
            FindTiebaListInfo(webPageContentString);
        }
        #endregion

        #region 找到每一个贴吧的地址形成的列表
        private void FindTiebaListInfo(string s)
        {
            string rs = "(<td>)(.*?)(<a href=\")(.*?)(\">)(.*?)(</a></td><td align=\"center\">)(.*?)(</td><td align=\"center\">)(.*?)(</td>)";
            Regex r = new Regex(rs, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(s);
            for (; m.Success; m = m.NextMatch())
            {
                numList.Add(m.Groups[2].ToString());
                urlList.Add(singleTiebaPageUrlPart + m.Groups[4].ToString());
                nameList.Add(m.Groups[6].ToString());
                gradeList.Add(m.Groups[8].ToString());
                valueList.Add(m.Groups[10].ToString());
                updateInfoList.Add("请稍候");
            }
            BindListBox();
            VisitEachPage(urlList);
        }
        #endregion

        #region 遍历列表获取每个贴吧的页面
        private void VisitEachPage(List<string> urlList)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ToastPrompt tp = new ToastPrompt();
                tp.Message = "正在签到";
                tp.Show();
            });
            foreach (string url in urlList)
            {
                VisitSinglePage(url);
                //Dispatcher.BeginInvoke(() =>
                //{
                //    BindListBox();
                //});
                Thread.Sleep(1000);
            }
            Dispatcher.BeginInvoke(() =>
            {
                ToastPrompt tp = new ToastPrompt();
                tp.Message = "签到已完成";
                tp.Show();
                Guide.IsScreenSaverEnabled = true;
            });
        }

        private void VisitSinglePage(string ss)
        {
            string url = ss;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //返回异步操作的状态
            IAsyncResult result = (IAsyncResult)request.BeginGetResponse(VisitSinglePageResponse, request);
        }

        private void VisitSinglePageResponse(IAsyncResult result)
        {
            string singleTiebaPageContentString = "";
            //获取异步操作返回的的信息
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            //结束对 Internet 资源的异步请求
            WebResponse response = request.EndGetResponse(result);
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    singleTiebaPageContentString = reader.ReadToEnd();
                }
            }
            FindSignAddress(singleTiebaPageContentString);
            Dispatcher.BeginInvoke(() =>
            {
                BindListBox();
            });
        }
        #endregion

        #region 在单个贴吧页面中找到签到地址
        private void FindSignAddress(string stps)
        {
            if (!CheckIfSigned(stps))
            {
                string signAddress = "";
                string rs = "(等级)(.*?)(href=\")(.*?)(\">签到)";
                Regex r = new Regex(rs, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match m = r.Match(stps);
                for (; m.Success; m = m.NextMatch())
                {
                    signAddress = "http://waptieba.baidu.com" + m.Groups[4].ToString();
                }
                signAddress = signAddress.Replace(';', '&');
                GoSign(signAddress);
            }
        }

        // 检查是否已经签到
        private Boolean CheckIfSigned(string s)
        {
            try
            {
                if (!s.Contains("签到"))
                {
                    int startIndex = s.IndexOf("<title>");
                    int endIndex = s.IndexOf("</title>");
                    s = s.Substring(startIndex + 7, endIndex - startIndex - 13);
                    updateInfoList[nameList.IndexOf(s)] = "已签到";
                    return true;
                }
                else if (s.Contains("已签到"))
                {
                    int startIndex = s.IndexOf("<title>");
                    int endIndex = s.IndexOf("</title>");
                    s = s.Substring(startIndex + 7, endIndex - startIndex - 13);
                    updateInfoList[nameList.IndexOf(s)] = "已签到";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Debug.WriteLine("check if signed exception");
                return true;
            }
        }
        #endregion

        #region 访问签到地址
        private void GoSign(string signAdd)
        {
            string signUrl = signAdd;
            //创建WebRequest类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(signUrl);
            //返回异步操作的状态
            IAsyncResult result = (IAsyncResult)request.BeginGetResponse(GoSignResponse, request);
        }

        private void GoSignResponse(IAsyncResult result)
        {
            string signedPageContentString = "";
            //获取异步操作返回的的信息
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            //结束对 Internet 资源的异步请求
            WebResponse response = request.EndGetResponse(result);
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    signedPageContentString = reader.ReadToEnd();
                }
            }
            FindUpdate(signedPageContentString);
            Dispatcher.BeginInvoke(() =>
            {
                BindListBox();
            });
        }
        #endregion

        #region 在签到后返回的页面中找到经验值上升提示
        private void FindUpdate(string sUpdate)
        {
            string updateInfoString = "";
            string rs = "(签到成功，经验值上升<span class=\"light\">)(.*?)(</span>)";
            Regex r = new Regex(rs, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(sUpdate);
            for (; m.Success; m = m.NextMatch())
            {
                updateInfoString = "签到成功，经验值上升" + m.Groups[2].ToString();
            }
            int startIndex = sUpdate.IndexOf("<title>");
            int endIndex = sUpdate.IndexOf("</title>");
            sUpdate = sUpdate.Substring(startIndex + 7, endIndex - startIndex - 13);
            updateInfoList[nameList.IndexOf(sUpdate)] = updateInfoString;
        }
        #endregion

        private void BindListBox()
        {
            displayList.Clear();
            for (int i = 0; i < numList.Count; i++)
            {
                displayList.Add(new ListItem
                {
                    num = numList[i],
                    name = nameList[i],
                    grade = gradeList[i],
                    value = valueList[i],
                    updateInfo = updateInfoList[i]
                });
            }
            Dispatcher.BeginInvoke(() =>
            {
                TiebaList.ItemsSource = null;
                TiebaList.ItemsSource = displayList;
            });
        }
    }
}