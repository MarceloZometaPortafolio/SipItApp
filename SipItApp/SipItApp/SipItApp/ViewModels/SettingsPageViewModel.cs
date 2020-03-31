﻿using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Console.WriteLine("Created new SettingsPage");
        }

        public ImageSource Images => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        public string MySettingsText => "this is bound!";
    }
}
