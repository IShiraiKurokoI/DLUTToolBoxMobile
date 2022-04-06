using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLUTToolBoxMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Other : ContentPage
    {
        public Other()
        {
            InitializeComponent();
            DarkModeLoader();
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
        private void XueGong_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("学工系统", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421f4e2558f267e6c5c6b1cc7a99c406d36b7/cas", 16));
        }

        private void Mail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("大工邮箱", "https://mail.dlut.edu.cn/coremail/common/xphone_dllg/index.jsp", 17));
        }

        private void Pan_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("大工网盘", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421e0f64fd2233c7d44300d8db9d6562d/cas", 0));
        }

        private void Market_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("跳蚤市场", "https://res.dlut.edu.cn/tp_cgp/view?m=cgp", 0));
        }

        private void Complain_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("吐槽反馈", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fcomplainpraise&response_type=code&scope=base_api&state=dlut", 0));
        }

        private void Charge_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("校园缴费平台", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421f5f4408e23206949730d87b8d6512f209640763a21f75b0c/#/dashboard", 0));
        }

        private void Net_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("网络自助系统", "https://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421e0f85388263c2654721d9de29d51367b3449/sso/sso_zzxt.jsp", 0));
        }

        private void Return_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("返校申请", "https://ehall.dlut.edu.cn/fp/s/dcLKox?from=rj", 0));
        }
    }
}