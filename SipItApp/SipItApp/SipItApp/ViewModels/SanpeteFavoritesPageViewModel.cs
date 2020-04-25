using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class SanpeteFavoritesPageViewModel : ViewModelBase
    {
        private readonly ISipItService sipItService;
        private readonly ILoginService loginService;

        public SanpeteFavoritesPageViewModel(ISipItService sipItService, ILoginService loginService)
        {
            Debug.WriteLine("SanpeteFavorites page created");
            Title = "Menu";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService)); 
            this.loginService = loginService;
        }
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        private Command loginCommand;
        public Command LoginCommand => loginCommand ?? (loginCommand = new Command(async
            () =>
        {
            Console.WriteLine("LoginCommand was clicked");

            if (loginService.getCurrentCustomer() == null)
            {
                Debug.WriteLine("User is empty. Login");
                await Shell.Current.GoToAsync("login", true);
            }
            else
            {
                Debug.WriteLine("User is not empty. Account details");
                await Shell.Current.GoToAsync("//account_details", true);
            }
        }));

    }
}
