using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DLUTToolBoxMobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://space.bilibili.com/310144483");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://github.com/MuoRanLY/DLUTToolBoxMobile");
        }
    }
}