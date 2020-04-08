using Prism.Commands;
using Prism.Navigation;
using SipItApp.Model;
using SipItApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            Title = "Sip It";
        }

        //public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");        

        public string MyText => "Hello World!";

        private Command navigateToSettings;
        private readonly INavigationService navigationService;

        public Command NavigateToSettings => navigateToSettings ?? (navigateToSettings = new Command(
            () => navigationService.NavigateAsync("HomePage/NavigationPage/"+nameof(SettingsPage))
            ));

        private DelegateCommand<HamburgerNavigationItem> navigateToPage;

        public DelegateCommand<HamburgerNavigationItem> NavigateToPage =>
            navigateToPage ?? (navigateToPage = new DelegateCommand<HamburgerNavigationItem>(ExecuteCommand));

        private void ExecuteCommand(HamburgerNavigationItem page)
        {
            
            switch (page.Name)
            {
                case "Home":
                    navigationService.NavigateAsync("HomePage/NavigationPage/" + nameof(MainPage));
                    break;
                case "Account":
                    //NavigationParameters parameters = new NavigationParameters();
                    //parameters.Add()
                    navigationService.NavigateAsync("HomePage/NavigationPage/" + nameof(AccountPage));
                    break;
                default:
                    Console.WriteLine("Something went wrong. This is your " + page);
                    break;
            }
        }



        //public void Testing(Object sender, EventArgs e)
        //{
        //    navigationService.NavigateAsync("HomePage/NavigationPage/" + nameof(SettingsPage));
        //}
    }
}
