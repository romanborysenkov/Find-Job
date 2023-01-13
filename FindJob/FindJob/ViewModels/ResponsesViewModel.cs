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
    public class ResponsesViewModel :BaseViewModel
    {
        public VacanciesService service = new VacanciesService();

        public Command LoadResponsesCommand { get; }

        public Command<Vacancy> VacancyTapped { get; }

        private Vacancy _selectedVacancy;

        public Vacancy SelectedVacancy
        {
            get => _selectedVacancy;
            set
            {
                SetProperty(ref _selectedVacancy, value);
                OnSelected(value);
            }
        }

        private List<Vacancy> vacancies= new List<Vacancy>();

        public List<Vacancy> Vacancies
        {
            get => vacancies;
            set { vacancies = value; OnPropertyChanged(); }
        }

        public ResponsesViewModel()
        {
            LoadResponsesCommand = new Command(async () => await ExecuteLoadCommand());
            Title = "Main page";
            VacancyTapped = new Command<Vacancy>(OnSelected);

            ExecuteLoadCommand();

        }

        public async Task ExecuteLoadCommand()
        {
            IsBusy = true;
            Vacancies = await service.GetRespondedVacancies();
            IsBusy = false;
        }

       
        public async void OnSelected(Vacancy vacancy)
        {
            if (vacancy == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?{nameof(VacancyDetailsViewModel.VacancyId)}={vacancy.vacancyId.ToString()}");
        }
    }
}

