using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.App.Usage;
using Android.Net;
using Android.Net.Wifi;
using Xamarin.Android;
using Xamarin.Essentials;
using Android.Content.PM;
using DLUTToolBoxMobile.Droid;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.IO;
using Xamarin.Forms;

namespace DLUTToolBoxMobile.Droid
{
    public class NetworkCallbackImpl : ConnectivityManager.NetworkCallback
    {
        bool IsBlocked = true;
        public override void OnAvailable(Android.Net.Network network)
        {
            base.OnAvailable(network);
        }

        public override void OnLost(Android.Net.Network network)
        {
            base.OnLost(network);
        }

        public override void OnCapabilitiesChanged(Android.Net.Network network, NetworkCapabilities networkCapabilities)
        {
            base.OnCapabilitiesChanged(network, networkCapabilities);
            if (networkCapabilities.HasCapability(NetCapability.Validated))
            {
                if (networkCapabilities.HasTransport(Android.Net.TransportType.Wifi))
                {
                    if(IsBlocked==true)
                    {
                        using (WebClient cli = new WebClient())
                        {
                            string test = cli.DownloadString("http://mrtg.dlut.edu.cn/internal/dut.html");
                            if (test.IndexOf("Unauthorized") == -1)
                            {
                                try
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        string netinfo = client.DownloadString("http://172.20.20.1:801/include/auth_action.php?action=get_online_info");
                                        if (netinfo == "not_online")
                                        {
                                            Toast.MakeText(Android.App.Application.Context, "EDA WIFI已连接 需要登陆", ToastLength.Long).Show();
                                            ManualConnect();
                                        }
                                    }
                                }
                                catch
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        async Task ManualConnect()
        {
            Task.Run(async () =>
            {
                string command = "action=login&ac_id=3&user_ip=&nas_ip=&user_mac=&url=&username=" + Xamarin.Forms.Application.Current.Properties["Uid"] + "&password=" + Xamarin.Forms.Application.Current.Properties["NetworkPassword"] + "&save_me=1";
                Console.WriteLine(PostWebRequest("http://172.20.20.1:801/srun_portal_pc.php?ac_id=3&", command, Encoding.ASCII));
                Device.BeginInvokeOnMainThread(() =>
                {
                    Toast.MakeText(Android.App.Application.Context, "正在执行登录", ToastLength.Long).Show();
                });
                Thread.Sleep(1000);
                LoadNetInfo();
            });
        }
        string info = "";
        void LoadNetInfo()
        {
            using (WebClient client = new WebClient())
            {
                string netinfo = client.DownloadString("http://172.20.20.1:801/include/auth_action.php?action=get_online_info");
                string[] data = netinfo.Split(new[] { "," }, StringSplitOptions.None);
                if (data.Length > 2)
                {
                    info = "校园网余额:  " + data[2] + "\n校园网已用流量:  " + formatdataflow(data[0]);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Toast.MakeText(Android.App.Application.Context, "自动连接成功\n" + info, ToastLength.Long).Show();
                    });
                    if (datawarn == true)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Toast.MakeText(Android.App.Application.Context, "本月流量使用已超过90G，请留意！", ToastLength.Long).Show();
                        });
                    }
                }
            }
        }
        bool datawarn=false;
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
        private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new System.Uri(postUrl));
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
        public override void OnBlockedStatusChanged(Android.Net.Network network, bool blocked)
        {
            base.OnBlockedStatusChanged(network, blocked);
            IsBlocked=blocked;
        }
    }
}