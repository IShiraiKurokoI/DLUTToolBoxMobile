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
    public partial class Exam : ContentPage
    {
        public Exam()
        {
            InitializeComponent();
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("教务主页", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 0));
        }

        private void CourseSelect_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("选课系统", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 3));
        }

        private void ExamInfo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("考试信息", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 4));
        }

        private void Score_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("成绩信息", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 5));
        }

        private void Delay_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("缓考系统", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 6));
        }

        private void Evaluation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("评教系统", "https://webvpn.dlut.edu.cn/http/77726476706e69737468656265737421faef4690693464456a468ca88d1b203b/student/ucas-sso/login", 7));
        }

        private void Calendar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("学校校历", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fschcalendar&response_type=code&scope=base_api&state=dlut", 0));
        }

        private void Notice_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("公共通知", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=9qXqHnRQuhhViycC&redirect_uri=https%3a%2f%2flightapp.m.dlut.edu.cn%2fcheck%2fnotice&response_type=code&scope=base_api&state=dlut", 0));
        }

        private void YanJiuSheng_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowserWindow("研究生系统", "https://api.m.dlut.edu.cn/oauth/authorize?client_id=abccc53d6b78cb01&redirect_uri=http%3a%2f%2fdutgs.dlut.edu.cn%3a443%2fSmartWap%2foAuth.do&response_type=code&scope=base_api&state=dlut", 0));
        }
    }
}