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
    public partial class WorkSpace : ContentPage
    {
        public WorkSpace()
        {
            InitializeComponent();
            try
            {
                Web.Reload();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string url = "";

        private void Web_Navigating(object sender, WebNavigatingEventArgs e)
        {
            try
            {
                url = e.Url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async void Web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                if (url.IndexOf("sso.dlut.edu.cn") != -1)
                {
                    if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length == 0)
                    {
                        DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
                    }
                    string jscode = "un.value='" + Application.Current.Properties["Uid"] + "'";
                    string jscode1 = "pd.value='" + Application.Current.Properties["UnionPassword"] + "'";
                    string rm = "rememberName.checked='checked'";
                    await Web.EvaluateJavaScriptAsync(rm);
                    await Web.EvaluateJavaScriptAsync(jscode);
                    await Web.EvaluateJavaScriptAsync(jscode1);
                    string jscode2 = "login()";
                    await Web.EvaluateJavaScriptAsync(jscode2);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}