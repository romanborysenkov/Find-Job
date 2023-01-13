using System;
using Xamarin.Forms;
using FindJob.Models;
using FindJob.Services;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace FindJob.ViewModels
{
	public class ResumeViewModel:BaseViewModel
	{
		public Command OnSaveResume { get; }

		public Command LoadResumeCommand { get; }

	
        ResumeService service = new ResumeService();
		UsersService userService = new UsersService();

		public ResumeViewModel()
		{
			LoadResumeCommand = new Command(async () => await ExecuteLoadCommand()); ;
			OnSaveResume = new Command( SaveResume);
        }

		private User us = new User();

		private Resume res = new Resume();

		public Resume resume
		{
			get => res;
            set { res = value; OnPropertyChanged(); }
        }

		public User user
		{
			get => us;
			set { us = value; OnPropertyChanged(); }
		}

		public async Task ExecuteLoadCommand()
		{
			IsBusy = true;
			user = await userService.GetUserById(Preferences.Get("userId", "0"));
		     resume = await service.GetResumeByUserId(Preferences.Get("userId", "0"));
			IsBusy = false;
		}

		public async void SaveResume()
		{
			if(string.IsNullOrEmpty(resume.userId))
			{
				resume.userId = Preferences.Get("userId","0");
				await service.PostResume(resume);
				await userService.PutUser(user);
            }
			else
			{
				await userService.PutUser(user);
				await service.PutResume(resume);
			}
		}
	}
}

