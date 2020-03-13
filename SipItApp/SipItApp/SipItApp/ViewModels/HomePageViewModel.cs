using Prism.Navigation;
using SipItApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sip It";
            this.navigationService = navigationService;
        }

        public ImageSource BackgroundImage => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        public string MyText => "Hello World!";

        private Command navigateToSettings;
        private readonly INavigationService navigationService;

        public Command NavigateToSettings => navigateToSettings ?? (navigateToSettings = new Command(
            () => navigationService.NavigateAsync("HomePage/NavigationPage/"+nameof(SettingsPage))
            ));
    }
}
