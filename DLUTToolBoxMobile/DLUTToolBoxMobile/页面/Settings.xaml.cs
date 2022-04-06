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
    public partial class Settings : ContentPage
    {
        bool SettingsInitialized=false;
        public Settings()
        {
            InitializeComponent();
            SettingsLoader();
            DarkModeLoader();
        }

        void DarkModeLoader()
        {
            if (Application.Current.Properties.ContainsKey("DarkMode") == true)
            {
                if (Application.Current.Properties["DarkMode"].ToString() == "true")
                {
                    Xamarin.Forms.Application.Current.UserAppTheme=OSAppTheme.Dark;
                }
                else
                {
                    Xamarin.Forms.Application.Current.UserAppTheme=OSAppTheme.Light;
                }
            }
        }

        void SettingsLoader()
        {
            if(Application.Current.Properties.ContainsKey("Uid") ==true)
            {
                Uid.Text = Application.Current.Properties["Uid"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("UnionPassword") ==true)
            {
                UnionPassword.Text = Application.Current.Properties["UnionPassword"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("NetworkPassword") ==true)
            {
                NetworkPassword.Text = Application.Current.Properties["NetworkPassword"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("MailAddress") ==true)
            {
                MailAddress.Text = Application.Current.Properties["MailAddress"].ToString();
            }
            if(Application.Current.Properties.ContainsKey("MailPassword") ==true)
            {
                MailPassword.Text = Application.Current.Properties["MailPassword"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("DarkMode") ==true)
            {
                if(Application.Current.Properties["DarkMode"].ToString()=="true")
                {
                    DarkMode.Text = "关闭黑夜模式";
                }
                else
                {
                    DarkMode.Text = "开启黑夜模式";
                }
            }
            SettingsInitialized=true;
        }


        private void Uid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true) 
                Application.Current.Properties["Uid"]=Uid.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void UnionPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["UnionPassword"] = UnionPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void NetworkPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["NetworkPassword"] = NetworkPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void MailAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["MailAddress"] = MailAddress.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void MailPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SettingsInitialized == true)
                Application.Current.Properties["MailPassword"] = MailPassword.Text;
            Application.Current.SavePropertiesAsync();
        }

        private void ShowPasswordButton_Clicked(object sender, EventArgs e)
        {
            if(ShowPasswordButton.Text =="显示密码")
            {
                ShowPasswordButton.Text = "隐藏密码";
                UnionPassword.IsPassword = false;
                NetworkPassword.IsPassword = false;
                MailPassword.IsPassword = false;
            }
            else
            {
                ShowPasswordButton.Text = "显示密码";
                UnionPassword.IsPassword = true;
                NetworkPassword.IsPassword = true;
                MailPassword.IsPassword = true;
            }
        }

        private void DarkMode_Clicked(object sender, EventArgs e)
        {
            if(DarkMode.Text== "开启黑夜模式")
            {
                DarkMode.Text = "关闭黑夜模式";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DarkMode"] = "true";
                Application.Current.SavePropertiesAsync();
                DarkModeLoader();

            }
            else
            {
                DarkMode.Text = "开启黑夜模式";
                if (SettingsInitialized == true)
                    Application.Current.Properties["DarkMode"] = "false";
                Application.Current.SavePropertiesAsync();
                DarkModeLoader();
            }
        }
    }
}