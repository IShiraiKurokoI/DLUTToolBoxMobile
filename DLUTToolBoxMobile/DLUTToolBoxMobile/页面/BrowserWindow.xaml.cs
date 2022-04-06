using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DLUTToolBoxMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BrowserWindow : ContentPage
	{
		int specialhandlenumber = 0;
        int count = 0;
		public BrowserWindow (string name, string uri,int sp)
		{
			InitializeComponent ();
            Web.WidthRequest = this.Width;
            Web.HeightRequest = this.Height;
			this.Title = name;
			specialhandlenumber = sp;
			Web.Source = uri;
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
        string url = "";

        private void Web_Navigating(object sender, WebNavigatingEventArgs e)
        {
			url = e.Url;
            try
            {
                if(url.StartsWith("weixin://")|| url.StartsWith("alipays://") || url.StartsWith("upwrp://"))
                {
                    Console.WriteLine("检测到支付地址："+url);
                    DependencyService.Get<IPay>().startpay(url);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        void login()
        {
            if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length == 0)
            {
                DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
            }
            string jscode = "un.value='" + Application.Current.Properties["Uid"] + "'";
            string jscode1 = "pd.value='" + Application.Current.Properties["UnionPassword"] + "'";
            string rm = "rememberName.checked='checked'";
            Web.EvaluateJavaScriptAsync(rm);
            Web.EvaluateJavaScriptAsync(jscode);
            Web.EvaluateJavaScriptAsync(jscode1);
            string jscode2 = "login()";
            Web.EvaluateJavaScriptAsync(jscode2);
        }

        void apilogin()
        {
            if (Application.Current.Properties["Uid"].ToString().Length * Application.Current.Properties["UnionPassword"].ToString().Length == 0)
            {
                DependencyService.Get<IToast>().ShortAlert("认证失败，账户名或密码未设置");
            }
            string jscode = "username.value='" + Application.Current.Properties["Uid"] + "'";
            string jscode1 = "password.value='" + Application.Current.Properties["UnionPassword"] + "'";
            Web.EvaluateJavaScriptAsync(jscode);
            Web.EvaluateJavaScriptAsync(jscode1);
            string jsenable = "btnpc.disabled=''";
            Web.EvaluateJavaScriptAsync(jsenable);
            string jscode2 = "btnpc.click()";
            Web.EvaluateJavaScriptAsync(jscode2);
        }

        void resize()
        {
            string rs = "document.getElementsByClassName('main-container')[0].style='margin:0px;padding:0px;width:100%'";
            Web.EvaluateJavaScriptAsync(rs);
            rs = "document.getElementsByClassName('container')[2].style='margin:0px;padding:0px;width:100%;'";
            Web.EvaluateJavaScriptAsync(rs);
            rs = "document.getElementsByClassName('row')[2].style='margin:0px;padding:0px;width:100%'";
            Web.EvaluateJavaScriptAsync(rs);
        }

        void resize_back()
        {
            string rs = "document.getElementsByClassName('main-container')[0].style=''";
            Web.EvaluateJavaScriptAsync(rs);
            rs = "document.getElementsByClassName('container')[2].style=''";
            Web.EvaluateJavaScriptAsync(rs);
            rs = "document.getElementsByClassName('row')[2].style=''";
            Web.EvaluateJavaScriptAsync(rs);
        }

        bool webvpn = false;
        bool warnshown = false;
        private void Web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (url == "https://webvpn.dlut.edu.cn/login")
            {
                string jsjump = "window.location.href='/login?cas_login=true'";
                Web.EvaluateJavaScriptAsync(jsjump);
                webvpn = true;
                return;
            }
            if (url.IndexOf("https://sso.dlut.edu.cn/cas/login?service=") != -1)
            {
                login();
                return;
            }
            if (url.IndexOf("cas/login?service=https%3A%2F%2Fwebvpn.dlut.edu.cn%2Flogin") != -1)
            {
                login();
                return;
            }
            if (url.IndexOf("api") != -1)
            {
                apilogin();
            }
            switch (specialhandlenumber)
            {
				    case 0:
                    {
                        LoadingNotice.IsVisible = false;
                        Web.IsVisible = true;
                        break;
                    }
					case 1:
                    {
                        LoadingNotice.IsVisible = false;
                        Web.IsVisible = true;
                        if (url == "http://172.20.20.1:8800/user/operate/index")
                        {
                            Web.EvaluateJavaScriptAsync("document.getElementsByClassName('radio')[0].innerHTML='<label><input type=\"radio\" name=\"OperateForm[shiftType]\" value=\"1\"> 立即生效</label><label><input type=\"radio\" name=\"OperateForm[shiftType]\" value=\"2\"> 下个周期生效</label>'");
                            Web.EvaluateJavaScriptAsync("document.getElementsByTagName('select')[1].innerHTML+='<option value=\"13\">包月限100G</option>'");
                        }
                        if (url == "http://172.20.20.1:8800/")
                        {
                            Web.EvaluateJavaScriptAsync("document.getElementById('loginform-username').value=" + Application.Current.Properties["Uid"]);
                            Web.EvaluateJavaScriptAsync("document.getElementById('loginform-password').value='" + Application.Current.Properties["NetworkPassword"] + "'");
                        }
                        break;
                    }
                case 2:
                    {
                        LoadingNotice.IsVisible = false;
                        Web.IsVisible = true;
                        if (url.IndexOf("https://card.m.dlut.edu.cn/virtualcard/openVirtualcard?") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("document.getElementsByClassName('code')[0].className=''");
                        }
                        break ;
                    }
                case 3:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/course-select'");
                        }
                        if (url.IndexOf("for-std/course-select") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 4:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/exam-arrange'");
                        }
                        if (url.IndexOf("exam-arrange") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 5:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/grade/sheet'");
                        }
                        if (url.IndexOf("grade/sheet") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 6:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/exam-delay-apply'");
                        }
                        if (url.IndexOf("exam-delay-apply") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 7:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/evaluation/summative'");
                        }
                        if (url.IndexOf("evaluation") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 8:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/lesson-search'");
                        }
                        if (url.IndexOf("lesson-search") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 9:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/course-table'");
                        }
                        if (url.IndexOf("course-table") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 10:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/adminclass-course-table'");
                        }
                        if (url.IndexOf("adminclass-course-table") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break;
                    }
                    case 11:
                    {
                        if (url.IndexOf("/student/home") != -1)
                        {
                            Web.EvaluateJavaScriptAsync("window.location.href='/student/for-std/program-completion-preview'");
                        }
                        if (url.IndexOf("program-completion-preview") != -1)
                        {
                            LoadingNotice.IsVisible = false;
                            Web.IsVisible = true;
                        }
                        break ;
                    }
                case 12:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    Web.Source = new Uri("http://seat.lib.dlut.edu.cn/yanxiujian/client/areaSelectSeat.php");
                                    break;
                                }
                            case 1:
                                {
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                {
                                    if (url.IndexOf("http://seat.lib.dlut.edu.cn/yanxiujian/client/orderSeat.php") != -1)
                                    {
                                        resize();
                                    }
                                    else
                                    {
                                        resize_back();
                                    }
                                    if (url.IndexOf("http://seat.lib.dlut.edu.cn/yanxiujian/client/areaSelectSeat.php") != -1 || url.IndexOf("http://seat.lib.dlut.edu.cn/yanxiujian/client/index.php") != -1)
                                    {
                                        LoadingNotice.IsVisible = false;
                                        Web.IsVisible = true;
                                    }
                                    else
                                    {
                                        LoadingNotice.IsVisible = false;
                                        Web.IsVisible = true;
                                    }
                                    break;
                                }
                        }
                        break ;
                    }
                case 13:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    Web.Source = new Uri("http://seat.lib.dlut.edu.cn/yanxiujian/client/orderInfo.php");
                                    break;
                                }
                            case 1:
                                {
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break ;
                    }
                case 14:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    if (url == "https://webvpn.dlut.edu.cn/login")
                                    {
                                        string jsjump = "window.location.href='/login?cas_login=true'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        webvpn = true;
                                    }
                                    else
                                    {
                                        string jsjump = "window.location.href='http://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421e7e056d22b396a1e7a049cb8d65027204e7199/sjkdhejlbyAtoZ/ALL.htm'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        LoadingNotice.IsVisible = false;
                                        Web.IsVisible = true;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (webvpn == true)
                                    {
                                        string jsjump = "window.location.href='http://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421e7e056d22b396a1e7a049cb8d65027204e7199/sjkdhejlbyAtoZ/ALL.htm'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                    }
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case 15:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    if (url == "https://webvpn.dlut.edu.cn/login")
                                    {
                                        string jsjump = "window.location.href='/login?cas_login=true'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        webvpn = true;
                                    }
                                    else
                                    {
                                        string jsjump = "window.location.href='http://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421f7b9569d2936695e790c88b8991b203a18454272/index.html'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        LoadingNotice.IsVisible = false;
                                        Web.IsVisible = true;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (webvpn == true)
                                    {
                                        string jsjump = "window.location.href='http://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421f7b9569d2936695e790c88b8991b203a18454272/index.html'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                    }
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                break;
                        }
                        break ;
                    }
                    case 16:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    if (url.IndexOf("https://webvpn.dlut.edu.cn/login") != -1)
                                    {
                                        string jsjump = "window.location.href='/login?cas_login=true'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        webvpn = true;
                                    }
                                    else
                                    {
                                        string jsjump = "window.location.href='http://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421f4e2558f267e6c5c6b1cc7a99c406d36b7/cas'";
                                        Web.EvaluateJavaScriptAsync(jsjump);
                                        LoadingNotice.IsVisible = false;
                                        Web.IsVisible = true;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (webvpn == true)
                                    {
                                        login();
                                    }
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case 17:
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    break;
                                }
                            case 1:
                                {
                                    string jscode = "username.value='" + Application.Current.Properties["MailAddress"] + "'";
                                    Web.EvaluateJavaScriptAsync(jscode);
                                    string jscode1 = "password.value='" + Application.Current.Properties["MailPassword"] + "'";
                                    Web.EvaluateJavaScriptAsync(jscode1);
                                    string rm = "domain.value='mail.dlut.edu.cn'";
                                    Web.EvaluateJavaScriptAsync(rm);
                                    Web.EvaluateJavaScriptAsync(jscode);
                                    string jscode2 = "document.getElementsByClassName('loginBtn')[0].click()";
                                    Web.EvaluateJavaScriptAsync(jscode2);
                                    LoadingNotice.IsVisible = false;
                                    Web.IsVisible = true;
                                    break;
                                }
                            default:
                                break;
                        }
                        break ;
                    }
                case 18:
                    {

                        break;
                    }
            }
            count++;
        }
    }
}