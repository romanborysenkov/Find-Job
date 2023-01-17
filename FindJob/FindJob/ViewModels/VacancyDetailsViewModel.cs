using System;
using System.Net.Http;
using FindJob.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using FindJob.Services;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Xamarin.Essentials;

namespace FindJob.ViewModels
{
	[QueryProperty(nameof(VacancyId), nameof(VacancyId))]
	public class VacancyDetailsViewModel:BaseViewModel
	{
		ResponsesService responsesservice = new ResponsesService();
		VacanciesService service = new VacanciesService();

		private string vacancyId;

        public string VacancyId
        {
            get { return vacancyId; }
            set {  vacancyId = value; ExecuteLoadVacancyCommand(); }
        }

        private Vacancy vac = new Vacancy();

        public Vacancy vacancy
        {
            get => vac;
            set => SetProperty(ref vac, value);
        }



        private bool withresponse;

		public bool WithResponse
		{
			get => withresponse;
			set
			{
				withresponse = value; OnPropertyChanged();
			}
		}

		private bool forButton;

		public bool ForButton
		{
			get => forButton;
			set { forButton = value; OnPropertyChanged(); }
		}

        public Command LoadVacancyCommand { get; }

        public Command OnSendAnswer { get; }

        public VacancyDetailsViewModel()
		{
			Title = "Details";
			LoadVacancyCommand = new Command(ExecuteLoadVacancyCommand);
			OnSendAnswer = new Command(SendAnswer);

        }

		public async void responded()
		{
			withresponse = 
			await  responsesservice.GetResponseByVacancyId(VacancyId);
			
		}
	

        private async void SendAnswer(object obj)
        {
			var resp = new Responses()
			{
				WorkerId = Preferences.Get("userId", ""),
				VacancyId = VacancyId
			};
			await responsesservice.PostResponse(resp);
            await Shell.Current.GoToAsync($"///{nameof(Views.VacanciesPage)}");
        }

		public string TimePub
		{
			get => vacancy.publishtime.ToShortDateString();
		}

        public async void ExecuteLoadVacancyCommand()
           {
			IsBusy = true;
            var  v = await service.GetVacancyById(VacancyId);
			WithResponse =await responsesservice.GetResponseByVacancyId(VacancyId);
            ForButton = !WithResponse;

            vacancy = v;

			IsBusy = false;
        }
	}
}

