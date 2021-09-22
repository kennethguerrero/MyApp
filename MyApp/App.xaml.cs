using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.Services;
using MyApp.Views;
using MonkeyCache.FileStore;
using Xamarin.Essentials;

namespace MyApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppInfo.PackageName;
            MainPage = new AppShell();
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
    }
}
