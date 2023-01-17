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
        ResumeViewModel _viewModel;
        public ResumePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ResumeViewModel(this);
        }

      
    }
}

