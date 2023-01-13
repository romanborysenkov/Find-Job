using System;
using Xamarin.Forms;
using FindJob.Views;
using FindJob.Services;
using Xamarin.Essentials;

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
           
       var user = await service.LoginUser(Email, Password);
            if(user==null) { }
            else
            {
                Preferences.Set("email", user.email);
                Preferences.Set("firstname", user.firstname);
                Preferences.Set("secondname", user.secondname);
                Preferences.Set("phone", user.phone);
                Preferences.Set("userId", user.Id);
                Preferences.Set("isLogined", true);

                //   await Shell.Current.GoToAsync("//VacanciesPage");
                //await Shell.Current.GoToAsync($"{nameof(VacanciesPage)}?{nameof(VacanciesViewModel.IsLogined)}={false}");

                Application.Current.MainPage = new AppShell();
               // await Shell.Current.GoToAsync($"///{nameof(VacanciesPage)}?{nameof(VacanciesPage.isLogined)}={true}");
            }
        }

        private async void SignUp()
        {
             await Shell.Current.GoToAsync(nameof(SignupPage));
        }
    }
}

