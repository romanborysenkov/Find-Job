using System;
using Xamarin.Forms;
using FindJob.Views;
using FindJob.Services;
using Xamarin.Essentials;
using MonkeyCache.FileStore;

namespace FindJob.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {

        public Command OnLogin { get; }
        public Command OnSignUp { get; }

        UsersService service = new UsersService();

        public LoginViewModel()
        {
            OnLogin = new Command(Login);
            OnSignUp = new Command(SignUp);
        }

        private string email;
        private string password;

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }

        private async void Login()
        {

            if(Connectivity.NetworkAccess==NetworkAccess.Internet)
            {
                var user = await service.LoginUser(Email, Password);
                if(!string.IsNullOrEmpty(user.email) && !string.IsNullOrEmpty(user.firstname))
                {
                    Barrel.Current.Add(key: "logined_user", data: user, expireIn: TimeSpan.FromDays(30));

                    Preferences.Set("userId", user.Id);
                    Preferences.Set("isLogined", true);

                    Application.Current.MainPage = new AppShell();
                }
            }
           
     
        }

        private async void SignUp()
        {
             await Shell.Current.GoToAsync(nameof(SignupPage));
        }
    }
}

