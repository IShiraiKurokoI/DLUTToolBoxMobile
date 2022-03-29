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
    }
}