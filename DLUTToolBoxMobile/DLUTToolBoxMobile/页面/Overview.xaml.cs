using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.IO;
using Xamarin.Essentials;

namespace DLUTToolBoxMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {
        public Overview()
        {
            InitializeComponent();
            SettingsChecker();
            DarkModeLoader();
            if (Application.Current.Properties["DoAutoUpdate"].ToString() == "true")
            {
                UpdateChecker();
            }
            try
            {
                Web.Reload();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task UpdateChecker()
        {
            Task.Run(() =>
            {
                string Version = DependencyService.Get<IVersion>().GetVersion();
                //https://api.github.com/repos/MuoRanLY/DLUTToolBoxMobile/releases/latest
                try
                {
                    string updmessage = GetWebRequest("https://api.github.com/repos/MuoRanLY/DLUTToolBoxMobile/releases/latest", Encoding.ASCII);
                    var lines = updmessage.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string versionname = Array.Find(lines, line => line.IndexOf("\"name\":") != -1).Split(new string[] { "\"name\": \"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"," }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string size = formatdataflow(Array.Find(lines, line => line.IndexOf("\"size\":") != -1).Split(new string[] { "\"size\":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    string upddate = Array.Find(lines, line => line.IndexOf("\"updated_at\":") != -1).Split(new string[] { "\"updated_at\": \"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"," }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "T" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string downloadurl = Array.Find(lines, line => line.IndexOf("\"browser_download_url\":") != -1).Split(new string[] { "\"browser_download_url\": \"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string body = Array.Find(lines, line => line.IndexOf("\"body\":") != -1).Split(new string[] { "\"body\": \"" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    body = body.Replace("\\r\\n", "\n");
                    if (versionname != Version)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            bool ret =await DisplayAlert("检测到新版本，是否下载新版？", "版本号：" + versionname + "\n大小：" + size + "\n更新日期：" + upddate + "\n更新内容：\n" + body, "更新","忽略");
                            if(ret==true)
                            {
                                Launcher.OpenAsync(downloadurl);
                            }
                        });
                        //downloadurl
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            });
        }
        private string GetWebRequest(string url, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.61 Safari/537.36";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                int statusCode = (int)response.StatusCode;
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }
        string formatdataflow(string num)
        {
            //num = num.Substring(4);
            double temp = double.Parse(num);
            string re = "";
            if (temp > 1000000000)
            {
                temp /= (double)(1024 * 1024 * 1024);
                re = temp.ToString() + "G";
            }
            else if (temp > 1000000)
            {
                temp /= (double)(1024 * 1024);
                re = temp.ToString() + "M";
            }
            else
            {
                temp /= (double)1024;
                re = temp.ToString() + "K";
            }
            return re + "B";
        }

        void DarkModeLoader()
        {
            if (Application.Current.Properties.ContainsKey("DarkMode") == true)
            {
                if (Application.Current.Properties["DarkMode"].ToString() == "true")
                {
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Dark;
                }
                else
                {
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Light;
                }
            }
        }
        async Task SettingsChecker()
        {
            Task.Run(() => {
                if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length * Application.Current.Properties["NetworkPassword"].ToString().Length == 0)
                {
                    DisplayAlert("提示：", "请先完善参数配置中的相关信息！\n向右侧滑或点击左上可以显示导航栏", "知道了");
                    Navigation.PushAsync(new Settings());
                }
            });
        }

        string url = "";

        private void Web_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.IndexOf("courseschedule") == -1)
            {
                Web.Source = new Uri("https://api.m.dlut.edu.cn/login?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fcourseschedule&response_type=code");
                e.Cancel = true;
                return;
            }
            url = e.Url;
        }

        private void Web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            string un = Application.Current.Properties["Uid"].ToString();
            string upd = Application.Current.Properties["UnionPassword"].ToString();
            if (un.Length * upd.Length == 0)
            {
                DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
                return;
            }
            if (url.IndexOf("api") != -1)
            {
                apiloginforClassTable();
            }
            if (url == "https://lightapp.m.dlut.edu.cn/courseschedule")
            {

            }
            trans();
        }

        async Task trans()
        {
            Web.EvaluateJavaScriptAsync(Properties.Resources.Funload);
            Web.EvaluateJavaScriptAsync("window.onload=funload;");
        }

        async Task apiloginforClassTable()
        {
            try
            {
                if(Application.Current.Properties["Uid"].ToString().Length* Application.Current.Properties["UnionPassword"].ToString().Length==0)
                {
                    DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
                }
                string jscode = "username.value='" + Application.Current.Properties["Uid"].ToString() + "'";
                string jscode1 = "password.value='" + Application.Current.Properties["UnionPassword"].ToString() + "'";
                await Web.EvaluateJavaScriptAsync(jscode);
                await Web.EvaluateJavaScriptAsync(jscode1);
                string jsenable = "submit.disabled=''";
                await Web.EvaluateJavaScriptAsync(jsenable);
                string jscode2 = "submit.click()";
                await Web.EvaluateJavaScriptAsync(jscode2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}