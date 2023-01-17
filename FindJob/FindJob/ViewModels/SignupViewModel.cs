using System;
using Xamarin.Forms;
using FindJob.Models;
using System.Net.Http;
using FindJob.Views;

using System.Collections.ObjectModel;

using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Text;
using FindJob.Services;
using Xamarin.Essentials;
using MonkeyCache.FileStore;

namespace FindJob.ViewModels
{
    public class SignupViewModel:BaseViewModel
    {
        public Command OnSignUp { get; }

        public Command OnLogin { get; }

        UsersService service = new UsersService();

        public SignupViewModel()
        {
            OnLogin = new Command(GoToLogin);
            OnSignUp = new Command(async()=>await SignUp());
        }

        private User user = new User();

        public User u
        {
            get => user;
            set { user = value; OnPropertyChanged(); }
        } 

        private async Task SignUp()
        {
            User us = new User()
            {
                firstname = u.firstname,
                secondname = u.secondname,
                email = u.email,
                salt = u.salt,
                saltedhashedpassword = u.saltedhashedpassword,
                phone = u.phone
            };
            var result =  await service.PostUser(us);
            Preferences.Set("isLogined", true);
            Preferences.Set("userId", result.Id);

            Barrel.Current.Add(key: "logined_user", data: user, expireIn: TimeSpan.FromDays(30));

            await Shell.Current.GoToAsync("//VacanciesPage");
        }

        private async void GoToLogin()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
