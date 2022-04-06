using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net;
using Xamarin.Essentials;

namespace DLUTToolBoxMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        bool SettingsInitialized=false;
        public Settings()
        {
            InitializeComponent();
            SettingsLoader();
            DarkModeLoader();
        }

        void DarkModeLoader()
        {
            if (Application.Current.Properties.ContainsKey("DarkMode") == true)
            {
                if (Application.Current.Properties["DarkMode"].ToString() == "true")
                {
                    Xamarin.Forms.Application.Current.UserAppTheme=OSAppTheme.Dark;
                }
                else
                {
                    Xamarin.Forms.Application.Current.UserAppTheme=OSAppTheme.Light;
                }
            }
        }

        void SettingsLoader()
        {
            if(Application.Current.Properties.ContainsKey("Uid") ==true)
            {
                Uid.Text = Application.Current.Properties["Uid"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("UnionPassword") ==true)
            {
                UnionPassword.Text = Application.Current.Properties["UnionPassword"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("NetworkPassword") ==true)
            {
                NetworkPassword.Text = Application.Current.Properties["NetworkPassword"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("MailAddress") ==true)
            {
                MailAddress.Text = Application.Current.Properties["MailAddress"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("MailPassword") ==true)
            {
                MailPassword.Text = Application.Current.Properties["MailPassword"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("DoAutoUpdate") ==true)
            {
                if (Application.Current.Properties["DoAutoUpdate"].ToString() == "true")
                {
                    DoAutoUpdate.Text = "关闭自动检查更新";
                }
                else
                {
                    DoAutoUpdate.Text = "开启自动检查更新";
                }
            }
            if (Application.Current.Properties.ContainsKey("DarkMode") ==true)
            {
                if(Application.Current.Properties["DarkMode"].ToString()=="true")
                {
                    DarkMode.Text = "关闭黑夜模式";
                }
                else
                {
                    DarkMode.Text = "开启黑夜模式";
                }
            }
            SettingsInitialized=true;
        }


        private void Uid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true) 
                Application.Current.Properties["Uid"]=Uid.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void UnionPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["UnionPassword"] = UnionPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void NetworkPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["NetworkPassword"] = NetworkPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void MailAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["MailAddress"] = MailAddress.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void MailPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["MailPassword"] = MailPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void ShowPasswordButton_Clicked(object sender, EventArgs e)
        {
            if(ShowPasswordButton.Text =="显示密码")
            {
                ShowPasswordButton.Text = "隐藏密码";
                UnionPassword.IsPassword = false;
                NetworkPassword.IsPassword = false;
                MailPassword.IsPassword = false;
            }
            else
            {
                ShowPasswordButton.Text = "显示密码";
                UnionPassword.IsPassword = true;
                NetworkPassword.IsPassword = true;
                MailPassword.IsPassword = true;
            }
        }

        private void DarkMode_Clicked(object sender, EventArgs e)
        {
            if(DarkMode.Text== "开启黑夜模式")
            {
                DarkMode.Text = "关闭黑夜模式";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DarkMode"] = "true";
                Application.Current.SavePropertiesAsync();
                DependencyService.Get<IToast>().ShortAlert("黑夜模式已开启");
                DarkModeLoader();

            }
            else
            {
                DarkMode.Text = "开启黑夜模式";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DarkMode"] = "false";
                Application.Current.SavePropertiesAsync();
                DependencyService.Get<IToast>().ShortAlert("黑夜模式已关闭");
                DarkModeLoader();
            }
        }

        private void CheckUpdate_Clicked(object sender, EventArgs e)
        {
            UpdateChecker();
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
                            bool ret = await DisplayAlert("检测到新版本，是否下载新版？", "版本号：" + versionname + "\n大小：" + size + "\n更新日期：" + upddate + "\n更新内容：\n" + body, "更新", "忽略");
                            if (ret == true)
                            {
                                Launcher.OpenAsync(downloadurl);
                            }
                        });
                        //downloadurl
                    }
                    else
                    {
                        DependencyService.Get<IToast>().ShortAlert("您当前使用的已经是最新版本了！");
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.ToString());
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

        private void DoAutoUpdate_Clicked(object sender, EventArgs e)
        {
            if (DoAutoUpdate.Text == "开启自动检查更新")
            {
                DoAutoUpdate.Text = "关闭自动检查更新";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DoAutoUpdate"] = "true";
                Application.Current.SavePropertiesAsync();
                DependencyService.Get<IToast>().ShortAlert("自动更新已开启");
                UpdateChecker();
            }
            else
            {
                DoAutoUpdate.Text = "开启自动检查更新";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DoAutoUpdate"] = "false";
                Application.Current.SavePropertiesAsync();
                DependencyService.Get<IToast>().ShortAlert("自动更新已关闭");
            }
        }
    }
}