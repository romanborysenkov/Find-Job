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
            set { vacancyId = value; ExecuteLoadVacancyCommand(); }
        }

        public bool withResponse { get; set; }
		public bool forButton { get; set; }

        public Command LoadVacancyCommand { get; }

        public Command OnSendAnswer { get; }

        public VacancyDetailsViewModel()
		{
			Title = "Details";
			LoadVacancyCommand = new Command(ExecuteLoadVacancyCommand);
			OnSendAnswer = new Command(SendAnswer);
		
        }

		public async Task responded()
		{
			withResponse = 
			await  responsesservice.GetResponseByVacancyId(VacancyId);
			forButton= !withResponse;
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

		private Vacancy vac;

		public Vacancy vacancy
		{
			get => vac;
			set => SetProperty(ref vac, value);
		}

		

		public string TimePub
		{
			get => vacancy.publishtime.ToShortDateString();
			
		}

        public async void ExecuteLoadVacancyCommand()
           {
			IsBusy = true;
            var  v = await service.GetVacancyById(VacancyId);
			  vacancy = v;
			IsBusy = false;
        
        }
	}
}

