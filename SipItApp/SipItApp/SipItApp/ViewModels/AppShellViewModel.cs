﻿using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public AppShellViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sip It";
        }
    }
}
