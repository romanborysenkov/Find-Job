using System;
using System.Collections.Generic;
using FindJob.ViewModels;
using Xamarin.Forms;
using FindJob.Models;
using FindJob.Services;
using Xamarin.Essentials;
using System.Net.Http;
using System.IO;

namespace FindJob.Views
{
    public partial class ResumePage : ContentPage
    {
       public Resume resume = new Resume();
        ResumeViewModel _viewModel = new ResumeViewModel();
        ResumeService service = new ResumeService();
        public ResumePage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }

      async  protected override  void OnAppearing()
        {
            IsBusy = true;
            try
            {
                await _viewModel.ExecuteLoadCommand();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error!", ex.Message, "Ok");
                _viewModel.resume = new Resume();
                _viewModel.user = new User();
            }

            IsBusy = false;
            if(!IsBusy)
            {
                base.OnAppearing();
            }
        }

      
        MultipartFormDataContent ff = new MultipartFormDataContent();
        FileResult file;


        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            
                file = await MediaPicker.PickPhotoAsync();

            if (file==null)
            {
                await Shell.Current.GoToAsync($"///{nameof(ResumePage)}");
              
            }
            else
            {

                ff.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);

                var stream = await file.OpenReadAsync();

                image.Source = ImageSource.FromStream(() => stream);
            }

        }

          void Button_Clicked(System.Object sender, System.EventArgs e)
        {
           
            if (file != null)
            {
                _viewModel.resume.photoFile = ff;
                _viewModel.resume.photoName = file.FileName;
            }

            _viewModel.SaveResume();
        }

    }
}

