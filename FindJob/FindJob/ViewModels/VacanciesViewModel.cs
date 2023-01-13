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


using Xamarin.Essentials;

using Xamarin.Forms.Xaml;
using System.Linq;

namespace FindJob.ViewModels
{
  
    public class VacanciesViewModel:BaseViewModel
    {
        public VacanciesService service = new VacanciesService();

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

        private string username = Preferences.Get("firstname", "")+" "+ Preferences.Get("secondname", "");

        public string UserName
        {
            get=> username;
        }

        public VacanciesViewModel()
        {
             LoadVacanciesCommand = new Command(async () => await ExecuteLoadCommand());
            Title = "Main page";
            VacancyTapped = new Command<Vacancy>(OnSelected);
        
            GoToLogin = new Command(OnLoginUser);
            isLogined = !Preferences.Get("isLogined", false);

            ExecuteLoadCommand();
        }

        public bool IsLogined
        {
            get => isLogined;
            set{ SetProperty(ref isLogined, value); }
        }

        public async Task ExecuteLoadCommand()
        {
            IsBusy = true;
            Vacancies = await service.GetVacanciesAsync();
            IsBusy = false;
        }

        public async void ExecuteSearchCommand()
          {
                Vacancies = await service.GetVacanciesAsync();
             
                Vacancies = vacancies.Where(s => s.vacancyname.ToLower().Contains(SearchString.ToLower())
                || s.description.ToLower().Contains(SearchString.ToLower())
                || s.category.ToLower().Contains(SearchString.ToLower())).ToList();
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
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?{nameof(VacancyDetailsViewModel.VacancyId)}={vacancy.vacancyId.ToString()}");
        }
    }
}

