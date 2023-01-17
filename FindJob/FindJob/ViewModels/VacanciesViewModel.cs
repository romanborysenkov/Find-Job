using System;
using FindJob.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using System.Threading.Tasks;
using FindJob.Services;
using FindJob.Views;

using System.Collections.Generic;
using System.Windows.Input;
using FindJob.Interfaces;

using Xamarin.Essentials;

using Xamarin.Forms.Xaml;
using System.Linq;
using MonkeyCache.FileStore;

namespace FindJob.ViewModels
{
  
    public class VacanciesViewModel:BaseViewModel
    {
        public IVacancies service = new VacanciesService();

        public Command LoadVacanciesCommand { get; }

        public Command GoToLogin { get; }

        public Command<Vacancy> VacancyTapped { get; }

        private Vacancy _selectedVacancy;

        private bool isLogined;

        private string search;

        public string SearchString
        {
            get => search;
            set { SetProperty(ref search, value); ExecuteSearchCommand(); }
        }

        private List<Vacancy> vacancies  = new List<Vacancy>();

        public List<Vacancy> Vacancies
        {
            get => vacancies;
            set { vacancies = value; OnPropertyChanged(); }
        }

        private User user; // Preferences.Get("firstname", "")+" "+ Preferences.Get("secondname", "");

        public User UserThis
        {
            get=> user;
        }

        public string UserName
        {
            get;
            set;
        }

        public VacanciesViewModel()
        {
             LoadVacanciesCommand = new Command(async () => await ExecuteLoadCommand());
            Title = "Main page";
            VacancyTapped = new Command<Vacancy>(OnSelected);
        
            GoToLogin = new Command(OnLoginUser);
            isLogined = !Preferences.Get("isLogined", false);

            ExecuteLoadCommand();
            ExecuteUserCommand();
        }

        public bool IsLogined
        {
            get => isLogined;
            set{ SetProperty(ref isLogined, value); }
        }

        public  void ExecuteUserCommand()
        {
            if(Preferences.Get("isLogined", false))
            {
             user = Barrel.Current.Get<User>(key: "logined_user");
            UserName = user.firstname + " " + user.secondname;
            }
          
        }

        public async Task ExecuteLoadCommand()
        {
            IsBusy = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: "main_vacancies"))
            {
               await Task.Yield();
                var vacs = Barrel.Current.Get<IEnumerable<Vacancy>>(key: "main_vacancies");

                if(Vacancies.Count>0)
                {
                    Vacancies.Clear();
                    Vacancies = vacs.ToList();
                }
                else  Vacancies = vacs.ToList(); 
            }
            else
            {
                Vacancies = await service.GetVacanciesAsync();
                Barrel.Current.Add(key: "main_vacancies", data: this.Vacancies, expireIn: TimeSpan.FromDays(3));
            }
             IsBusy = false;
        }

        public async void ExecuteSearchCommand()
          {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Vacancies = await service.GetVacanciesAsync();

                Vacancies = vacancies.Where(s => s.vacancyname.ToLower().Contains(SearchString.ToLower())
                || s.description.ToLower().Contains(SearchString.ToLower())
                || s.category.ToLower().Contains(SearchString.ToLower())).ToList();
            }
            else
            {
                var localvacancies = Vacancies;
                Vacancies = vacancies.Where(s => s.vacancyname.ToLower().Contains(SearchString.ToLower())
                || s.description.ToLower().Contains(SearchString.ToLower())
                || s.category.ToLower().Contains(SearchString.ToLower())).ToList();
            }
          }
              

        private async void OnLoginUser()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        public Vacancy SelectedVacancy
        {
            get => _selectedVacancy;
            set
            {
                SetProperty(ref _selectedVacancy, value);
                OnSelected(value);
            }
        }

        public async void OnSelected(Vacancy vacancy)
        {
            if (vacancy == null)
                return;
            if(Connectivity.NetworkAccess == NetworkAccess.Internet)
                await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?{nameof(VacancyDetailsViewModel.VacancyId)}={vacancy.vacancyId.ToString()}");
        }
    }
}

