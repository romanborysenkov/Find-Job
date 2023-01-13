using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FindJob.ViewModels;

namespace FindJob.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
        }
    }
}

