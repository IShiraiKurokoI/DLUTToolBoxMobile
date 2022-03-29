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
    public partial class Library : ContentPage
    {
        public Library()
        {
            InitializeComponent();
        }

        private void Record_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("图书馆预约记录", "https://sso.dlut.edu.cn/cas/login?service=http://seat.lib.dlut.edu.cn/yanxiujian/client/login.php?redirect=areaSelectSeat.php", 13));
        }

        private void Resource_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("图书馆资源列表", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421e7e056d22b396a1e7a049cb8d65027204e7199/sjkdhejlbyAtoZ/ALL.htm", 14));
        }

        private void ZhiWang_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("知网搜索", "https://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421f5e7549e6933665b774687a98c/kns/brief/result.aspx", 0));
        }

        private void WanFang_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("万方搜索", "http://webvpn.dlut.edu.cn/https/77726476706e69737468656265737421f7b9569d2936695e790c88b8991b203a18454272/index.html", 15));
        }
    }
}