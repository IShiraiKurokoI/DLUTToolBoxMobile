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
    public partial class Study : ContentPage
    {
        public Study()
        {
            InitializeComponent();
        }

        private void Weektable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("本周课表", "https://api.m.dlut.edu.cn/login?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fcourseschedule&response_type=code", 0));
        }

        private void room_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("空闲教室", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2femptyclassroom&response_type=code&scope=base_api&state=dlut", 0));
        }

        private void Course_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("开课查询", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 8));
        }

        private void Table_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("我的课表", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 9));
        }

        private void ClassTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("班级课表", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 10));
        }

        private void Plan_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("培养方案", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 11));
        }

        private void Seat_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("图书馆座位预约", "https://sso.dlut.edu.cn/cas/login?service=http://seat.lib.dlut.edu.cn/yanxiujian/client/login.php?redirect=areaSelectSeat.php", 12));
        }

        private void Report_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("外出报备", "https://ehall.dlut.edu.cn/fp/s/qyUXbf?from=rj", 0));
        }

        private void Notice_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("校内通知", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fmemo&response_type=code&scope=base_api&state=dlut", 0));
        }
    }
}