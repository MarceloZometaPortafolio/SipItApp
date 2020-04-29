﻿using SipItApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SipItApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PepsiPage : ContentPage
    {
        public PepsiPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<LocalFavoritesPageViewModel>();
        }
    }
}