using System;
using MonkeyCache.FileStore;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindJob
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            Barrel.ApplicationId = "FindJob_ID";
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

