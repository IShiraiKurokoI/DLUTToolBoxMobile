using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using DLUTToolBoxMobile.Droid;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Xamarin.Android;
using Android.Net.Wifi;
using Android.Net;

namespace DLUTToolBoxMobile.Droid
{
    [Activity(Label = "DLUTToolBox手机版", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.DependencyService.Register<DLUTToolBoxMobile.IToast, ToastImpl>();
            Xamarin.Forms.DependencyService.Register<DLUTToolBoxMobile.IPay, PayImpl>();
            Xamarin.Forms.DependencyService.Register<DLUTToolBoxMobile.INotify, NotifyImpl>();
            Xamarin.Forms.DependencyService.Register<DLUTToolBoxMobile.IVersion, VersionImpl>();
            Xamarin.Forms.DependencyService.Register<DLUTToolBoxMobile.IClose, CloseImpl>();
            NetworkCallbackImpl networkCallback = new NetworkCallbackImpl();
            NetworkRequest.Builder builder = new NetworkRequest.Builder();
            NetworkRequest request = builder.Build();
            ConnectivityManager connMgr = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            if (connMgr != null)
            {
                connMgr.RegisterNetworkCallback(request, networkCallback);
            }
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        bool doubleBackToExitPressedOnce = false;
        public override void OnBackPressed()
        {
            if (doubleBackToExitPressedOnce)
            {
                base.OnBackPressed();
                FinishAffinity();
                return;
            }

            this.doubleBackToExitPressedOnce = true;
            Toast.MakeText(this, "再按一次退出程序", ToastLength.Short).Show();

            new Handler().PostDelayed(() => {
                doubleBackToExitPressedOnce = false;
            }, 2000);
        }
    }
}