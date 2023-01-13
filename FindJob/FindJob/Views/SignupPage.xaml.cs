using System;
using System.Collections.Generic;
using FindJob.ViewModels;
using Xamarin.Forms;

namespace FindJob.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            BindingContext = new SignupViewModel();
        }
    }
}

