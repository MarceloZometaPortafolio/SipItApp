﻿using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sip It";
        }
    }
}
