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

    }
}

