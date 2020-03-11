using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sip It";
        }
    }
}
