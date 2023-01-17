using System;
using Xamarin.Forms;
using FindJob.Models;
using FindJob.Services;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using MonkeyCache.FileStore;
using FindJob.Views;

namespace FindJob.ViewModels
{
	public class ResumeViewModel:BaseViewModel
	{

        ResumeService service = new ResumeService();
        UsersService userService = new UsersService();

        public Command OnSaveResume { get; }

		public Command LoadResumeCommand { get; }

		public Command OnSelectPhotoCommand { get; }

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

       
		Page page;

		public ResumeViewModel(Page page)
		{
			this.page = page;
			LoadResumeCommand = new Command(async () => await ExecuteLoadCommand()); ;
			OnSaveResume = new Command( SaveResume);
			OnSelectPhotoCommand = new Command(SelectPhoto);

            ExecuteLoadCommand();
        }

		FileResult file;
        MultipartFormDataContent formDataContent = new MultipartFormDataContent();

		private ImageSource photostream;

		public ImageSource PhotoStream
		{
			get => photostream;
			set { photostream = value; OnPropertyChanged(); }
		}

        public async void SelectPhoto()
		{
			file = await MediaPicker.PickPhotoAsync();

			if(file==null)
			{
				await Shell.Current.GoToAsync($"///{nameof(ResumePage)}");
			}
			else
			{
				formDataContent.Add(new StreamContent(await file.OpenReadAsync()),"file", file.FileName);

			 var stream = await file.OpenReadAsync();

				PhotoStream = ImageSource.FromStream(()=>stream);
			}
		}


		public async Task ExecuteLoadCommand()
		{
			IsBusy = true;

			if (Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				try
				{
					user = await userService.GetUserById(Preferences.Get("userId", "0"));
					resume = await service.GetResumeByUserId(Preferences.Get("userId", "0"));
					PhotoStream = resume.photoSrc;
				}
				catch
				{
                   resume = new Resume();
                }
			}
			else
			{
				if(!Barrel.Current.IsExpired(key: "user_resume"))
				{
					resume = Barrel.Current.Get<Resume>(key: "user_resume");
				}
				else resume = new Resume();

				if (!Barrel.Current.IsExpired(key: "logined_user"))
				{
					user = Barrel.Current.Get<User>(key: "logined_user");
				}
				else user = new User();

			//	await page.DisplayAlert("Error", "You haven't connection to Internet", "Ok");
			}
			IsBusy = false;
		}

		public async void SaveResume()
		{
			if(string.IsNullOrEmpty(resume.userId))
			{
				resume.photoFile = formDataContent;
				resume.photoName = file.FileName;
				 
                resume.userId = Preferences.Get("userId","0");
				await service.PostResume(resume);
				await userService.PutUser(user);
				Barrel.Current.Add(key:"user_resume", data:resume, expireIn:TimeSpan.FromDays(40));
            }
			else
			{
				if(file!=null)
				{
					resume.photoFile = formDataContent;
					resume.photoName = file.FileName;
				}
			
				await userService.PutUser(user);
				await service.PutResume(resume);
			}
		}
	}
}

