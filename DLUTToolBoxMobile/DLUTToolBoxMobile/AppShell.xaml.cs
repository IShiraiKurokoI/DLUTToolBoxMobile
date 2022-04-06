using DLUTToolBoxMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DLUTToolBoxMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IClose>().CloseApp();
        }
    }
}
