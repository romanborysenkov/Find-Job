using System;
using System.Collections.Generic;
using FindJob.Models;
using FindJob.ViewModels;
using Xamarin.Forms;
using FindJob.Services;

namespace FindJob.Views
{
    public partial class DetailsPage : ContentPage
    {
        public VacancyDetailsViewModel viewModel;
      

        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new VacancyDetailsViewModel();



        }

        protected async override void OnAppearing()
        {
            
            

            await viewModel.responded();
            if(viewModel.forButton)
            {
                reqbut.IsVisible = true;
                reqlab.IsVisible = false;
            }
            else { reqbut.IsVisible = false; reqlab.IsVisible = true; }
            base.OnAppearing();
        }


    }
}

