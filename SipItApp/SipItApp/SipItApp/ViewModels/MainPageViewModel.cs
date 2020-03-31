using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SipItApp.Views;

namespace SipItApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Console.WriteLine("Created new MainPage");

            Title = "Sip It";
            this.navigationService = navigationService;
        }

        public string MyText => "Hello World!";

        //public ImageSource BackgroundImage => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");                

        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        private Command getUsual;

        public Command GetUsual => getUsual ?? (getUsual = new Command(
            () =>
            {
                //navigationService.NavigateAsync(nameof(SettingsPage));
                Console.WriteLine("GetUsual command triggered");
            }));
    }
}
