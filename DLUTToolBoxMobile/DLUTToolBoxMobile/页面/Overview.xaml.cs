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
    public partial class Overview : ContentPage
    {
        public Overview()
        {
            InitializeComponent();
            SettingsChecker();
            try
            {
                Web.Reload();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async Task SettingsChecker()
        {
            Task.Run(() => {
                if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length * Application.Current.Properties["NetworkPassword"].ToString().Length == 0)
                {
                    DisplayAlert("提示：", "请先完善参数配置中的相关信息！\n向右侧滑或点击左上可以显示导航栏", "知道了");
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

            }
        }
    }
}