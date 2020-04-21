using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        PageDialogService pageDialogService;
        public LoginPageViewModel() 
        {
            Console.WriteLine("LoginPage created");
        }

        private string userLogin;
        public string UserLogin 
        {
            get { return userLogin; }
            set
            {
                userLogin = value;
            }
        }

        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
            }
        }

        //Commands
        private Command register;
        public Command Register => register ?? (register = new Command(async
            () =>
            {
                Debug.WriteLine("Register command clicked");
                await Shell.Current.GoToAsync("register", true);
            }));

        private Command login;
        public Command Login => login ?? (login = new Command(async
            () =>
            {
                if (userLogin != "marcelo" || userPassword != "zometa")
                {
                    Debug.WriteLine("Wrong! You shall not pass!");
                    var answer = await Shell.Current.DisplayAlert("Incorrect username or password",
                        "Do you want to try again", "Yes", "I forgot my password");
                    if(answer == false)
                    {
                        Debug.WriteLine("User forgot password. Execute something");
                    }
                }
                Debug.WriteLine("User access granted.");
                Shell.Current.SendBackButtonPressed();
            }));
    }
}
