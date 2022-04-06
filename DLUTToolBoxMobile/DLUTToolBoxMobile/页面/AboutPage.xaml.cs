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