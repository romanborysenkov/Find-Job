using System;
using System.Collections.Generic;
using FindJob.Views;
using MonkeyCache.FileStore;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FindJob
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            InitializeComponent();
          
            Routing.RegisterRoute(nameof(VacanciesPage), typeof(VacanciesPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
            Routing.RegisterRoute(nameof(ResumePage), typeof(ResumePage));
            Routing.RegisterRoute(nameof(ResponsesPage), typeof(ResponsesPage));

            if (Preferences.Get("isLogined", false))
            {
               
              //  Name =
               header.Text = Preferences.Get("firstname", "") +" " +Preferences.Get("secondname", "");
                responses.IsVisible = true;
                login.IsVisible = false;
                resume.IsVisible = true;
            }
            else
            {
                logout.Text = "";
                login.IsVisible = true;
                resume.IsVisible = false;
                responses.IsVisible = false;
            }
        }

       void logout_Clicked(System.Object sender, System.EventArgs e)
        {
          
            Preferences.Remove("userId", "");
            Preferences.Set("isLogined", false);
            Barrel.Current.Empty(key: "logined_user");


            Application.Current.MainPage = new AppShell();
            OnAppearing();
        }
    }
}

