using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace DLUTToolBoxMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            SettingsInitializer();
            try
            {
                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace+ex.Source);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        async Task SettingsInitializer()
        {
            Task.Run(() =>
            {
                if (Application.Current.Properties.ContainsKey("Uid") == false)
                {
                    Application.Current.Properties["Uid"] = "";
                }
                if (Application.Current.Properties.ContainsKey("UnionPassword") == false)
                {
                    Application.Current.Properties["UnionPassword"] = "";
                }
                if (Application.Current.Properties.ContainsKey("NetworkPassword") == false)
                {
                    Application.Current.Properties["NetworkPassword"] = "";
                }
                if (Application.Current.Properties.ContainsKey("MailAddress") == false)
                {
                    Application.Current.Properties["MailAddress"] = "";
                }
                if (Application.Current.Properties.ContainsKey("MailPassword") == false)
                {
                    Application.Current.Properties["MailPassword"] = "";
                }
                if (Application.Current.Properties.ContainsKey("DarkMode") == false)
                {
                    Application.Current.Properties["DarkMode"] = "false";
                }
                if (Application.Current.Properties.ContainsKey("DoAutoUpdate") == false)
                {
                    Application.Current.Properties["DoAutoUpdate"] = "true";
                }
                if (Application.Current.Properties.ContainsKey("DarkMode") == true)
                {
                    if (Xamarin.Forms.Application.Current.RequestedTheme == OSAppTheme.Dark)
                    {
                        Application.Current.Properties["DarkMode"] = "true";
                        Application.Current.SavePropertiesAsync();
                    }
                }
            });
        }
    }
}
