using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Threading;

namespace DLUTToolBoxMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Network : ContentPage
    {

        bool InsideEDA=false;
        public Network()
        {
            InitializeComponent();
            NetInfo.IsVisible = false;
            LoadNetInfo();
        }

        bool datawarn = false;
        async Task LoadNetInfo()
        {
            Task.Run(() =>
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string test = client.DownloadString("http://mrtg.dlut.edu.cn/internal/dut.html");
                        if (test.IndexOf("Unauthorized") != -1)
                        {
                            Device.BeginInvokeOnMainThread(() => { 
                                Info.Text = "当前不在校园网内!";
                                EDANetShell.IsVisible = false;
                            });
                            return;
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => { Info.Text = "校园网已接入"; });
                            Device.BeginInvokeOnMainThread(() => {
                                NetInfo.IsVisible = true;
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        NetInfo.IsVisible = false;
                    });
                    Device.BeginInvokeOnMainThread(() => {
                        if(e.Message.IndexOf("401")!=-1)
                        {
                            Info.Text = "当前不在校园网内。";
                            EDANetShell.IsVisible = false;
                            return;
                        }
                        else
                        {
                            Info.Text = "您当前可能没有连接互联网？";
                            EDANetShell.IsVisible=false;
                            return;
                        }
                    });
                    return;
                }
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string netinfo = client.DownloadString("http://172.20.20.1:801/include/auth_action.php?action=get_online_info");
                        if(netinfo== "not_online")
                        {
                            Device.BeginInvokeOnMainThread(() => {
                                EDANetShell.IsVisible = true;
                                Manual_Connect.WidthRequest = ((this.Width - 30) / 2);
                                Manual_Disconnect.WidthRequest = ((this.Width - 30) / 2);
                                InsideEDA = true;
                                DependencyService.Get<IToast>().ShortAlert("您已连接校园网，但并未登录");
                                NetInfo.IsVisible = false;
                            });
                        }
                        string[] data = netinfo.Split(new[] { "," }, StringSplitOptions.None);
                        if (data.Length > 2)
                        {
                            Device.BeginInvokeOnMainThread(() => {
                                Info.Text += "\n校园网余额:  " + data[2] + "\n校园网已用流量:  " + formatdataflow(data[0]) + "\nIPV4地址:\n" + data[5] + "\n网卡MAC地址:\n" + data[3];
                            });
                            InsideEDA=true;
                            Device.BeginInvokeOnMainThread(() => {
                                EDANetShell.IsVisible = true;
                                Manual_Connect.WidthRequest = ((this.Width - 30) / 2);
                                Manual_Disconnect.WidthRequest = ((this.Width - 30) / 2);
                            });
                        }
                        if (datawarn == true)
                        {
                            Device.BeginInvokeOnMainThread(() => {
                                Info.Text += "\n|本月流量使用已超过90G，请留意！！|\n";
                            });
                        }
                    }
                }
                catch
                {
                    return;
                }
            });
            //http://mrtg.dlut.edu.cn/internal/dut.html
        }

        string formatdataflow(string num)
        {
            //num = num.Substring(4);
            double temp = double.Parse(num);
            string re = "";
            if (temp > (double)96636764160)
            {
                datawarn = true;
            }
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

        private void NetInfo_Navigating(object sender, WebNavigatingEventArgs e)
        {
            e.Cancel = true;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = Properties.Resources.Monitor;
            NetInfo.Source = htmlSource;
        }

        private void Manual_Connect_Clicked(object sender, EventArgs e)
        {
            ManualConnect();
        }

        private void Manual_Disconnect_Clicked(object sender, EventArgs e)
        {
            ManualDisconnect();
        }

        async Task ManualDisconnect()
        {
            Task.Run(async () =>
            {
                string command = "action=logout&username=" + Application.Current.Properties["Uid"] + "&password=" + Application.Current.Properties["NetworkPassword"] + "&ajax=1";
                string respose = PostWebRequest("http://172.20.20.1:801/include/auth_action.php",command,Encoding.ASCII);
                if(respose == "网络已断开")
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Info.Text = "您已连接校园网，但并未登录...";
                        DependencyService.Get<IToast>().ShortAlert("注销成功!");
                        NetInfo.IsVisible = false;
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Info.Text = "网络状态未知。。。";
                        DependencyService.Get<IToast>().ShortAlert("注销失败。。。");
                        NetInfo.IsVisible = false;
                        LoadNetInfo();
                    });
                }

            });
        }
        async Task ManualConnect()
        {
            Task.Run(async () =>
            {
                string command = "action=login&ac_id=3&user_ip=&nas_ip=&user_mac=&url=&username=" + Application.Current.Properties["Uid"] + "&password=" + Application.Current.Properties["NetworkPassword"] + "&save_me=1";
                Console.WriteLine(PostWebRequest("http://172.20.20.1:801/srun_portal_pc.php?ac_id=3&", command,Encoding.ASCII));
                Thread.Sleep(1000);
                LoadNetInfo();
                Device.BeginInvokeOnMainThread(() =>
                {
                    NetInfo.Reload();
                });
            });
        }

        private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        private void SelfService_Clicked(object sender, EventArgs e)
        {
            if(InsideEDA==true)
            {
                Navigation.PushAsync(new BrowserWindow("自服务", "http://172.20.20.1:8800/",1));
            }
            else
            {
                Navigation.PushAsync(new BrowserWindow("网络自助", "https://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421e0f85388263c2654721d9de29d51367b3449/sso/sso_zzxt.jsp",0));
            }
        }

        private void Charge_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("充值", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421f5f4408e23206949730d87b8d6512f209640763a21f75b0c/",0));
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            Info.Text = "加载信息中，请稍后。。。。";
            DependencyService.Get<IToast>().ShortAlert("正在更新信息");
            LoadNetInfo();
        }
    }
}