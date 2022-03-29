using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using System.Diagnostics;

namespace DLUTToolBoxMobile.Droid
{
    internal class PayImpl:IPay
    {
        public void startpay(string url)
        {
            Console.WriteLine("收到支付地址："+url);
            try
            {
                Launcher.OpenAsync(url).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误:"+ex.Message);
            }
        }
    }
}