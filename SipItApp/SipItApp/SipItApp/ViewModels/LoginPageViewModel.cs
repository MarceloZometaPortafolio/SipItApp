using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel() 
        {
            Console.WriteLine("LoginPage created");
        }

        //Commands
        private Command register;
        public Command Register => register ?? (register = new Command(async
            () =>
            {
                Console.WriteLine("Register command clicked");
                await Shell.Current.GoToAsync("register", true);
            }));

    }
}
