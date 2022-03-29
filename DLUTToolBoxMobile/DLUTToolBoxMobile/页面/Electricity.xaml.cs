using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Threading;

namespace DLUTToolBoxMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Electricity : ContentPage
    {
        public Electricity()
        {
            InitializeComponent();
        }

        string url = "";
        private void EleInfo_Navigating(object sender, WebNavigatingEventArgs e)
        {
            url = e.Url;
            if(url.IndexOf("/errorPage")!=-1)
            {
                e.Cancel = true;
            }
        }
        void apilogin()
        {
            if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length == 0)
            {
                DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
            }
            string jscode = "username.value='" + Application.Current.Properties["Uid"] + "'";
            string jscode1 = "password.value='" + Application.Current.Properties["UnionPassword"] + "'";
            EleInfo.EvaluateJavaScriptAsync(jscode);
            EleInfo.EvaluateJavaScriptAsync(jscode1);
            string jsenable = "btnpc.disabled=''";
            EleInfo.EvaluateJavaScriptAsync(jsenable);
            string jscode2 = "btnpc.click()";
            EleInfo.EvaluateJavaScriptAsync(jscode2);
        }
        async void EleInfo_Navigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                if (url.IndexOf("api") != -1)
                {
                    apilogin();
                }
                if (int.Parse(DateTime.Now.Hour.ToString()) <= 1 || int.Parse(DateTime.Now.Hour.ToString()) >= 23)
                {
                    ElectricityInfo.Text = "当前不在查询时间！";
                    return;
                }
                if (url.IndexOf("homerj") != -1 && url.IndexOf("api") == -1)
                {
                    ElectricityInfo.Text = "正在加载玉兰卡信息。。。";
                    EleInfo.EvaluateJavaScriptAsync("window.location.href='https://card.m.dlut.edu.cn/elepay/openElePay?openid='+openid[0].value+'&displayflag=1&id=30'");
                }
                if (url.IndexOf("openElePay") != -1)
                {
                    ElectricityInfo.Text = "玉兰卡信息加载完成\n正在发起查询。。。 3";
                    await EleInfo.EvaluateJavaScriptAsync(Properties.Resources.Send);
                    await EleInfo.EvaluateJavaScriptAsync(Properties.Resources.Eleget);
                    await EleInfo.EvaluateJavaScriptAsync("getinfo()");
                    getinfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        async Task getinfo()
        {
            await Task.Delay(1000);
            Device.BeginInvokeOnMainThread(() => {
                ElectricityInfo.Text = "玉兰卡信息加载完成\n正在发起查询。。。 2";
            });
            await Task.Delay(1000);
            Device.BeginInvokeOnMainThread(() => {
                ElectricityInfo.Text = "玉兰卡信息加载完成\n正在发起查询。。。 1";
            });
            await Task.Delay(1000);
            string info = await EleInfo.EvaluateJavaScriptAsync(Properties.Resources.roombalance);
            if (info != "0.00")
            {
                Device.BeginInvokeOnMainThread(() => {
                    ElectricityInfo.Text = "您寝室剩余电量为" + info + "度";
                });
                if (double.Parse(info) <= 10)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        ElectricityInfo.Text += "\n您剩余电量不足10度!\n请及时缴费,避免影响使用!";
                    });
                }
                //Eleinfo.Dispose();
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ElectricityInfo.Text = "服务器返回错误\n正在重新发起请求。。。";
                });
                EleInfo.EvaluateJavaScriptAsync("getinfo()");
                getinfo();
            }
        }
        private void Refresh_Clicked(object sender, EventArgs e)
        {
            EleInfo.Reload();
            DependencyService.Get<IToast>().ShortAlert("正在更新信息");
        }

        private void Ecard_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("玉兰卡", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=19b32196decf419a&redirect_uri=https%3A%2F%2Fcard.m.dlut.edu.cn%2Fhomerj%2FopenRjOAuthPage&response_type=code&scope=base_api&state=weishao", 2));
        }

        private void Charge_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("电费充值", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421f5f4408e23206949730d87b8d6512f209640763a21f75b0c/#/project/pay/eleCostOfDlutPay", 0));
        }
    }
}