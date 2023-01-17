using System;
using System.Collections.Generic;
using FindJob.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using FindJob.Services;
using FindJob.Models;

namespace FindJob.Views
{
   
    public partial class VacanciesPage : ContentPage
    {
        public VacanciesViewModel _viewModel;
      
        public VacanciesPage()
        {
             InitializeComponent();

            BindingContext = _viewModel = new VacanciesViewModel();
           
        }
    }
}

