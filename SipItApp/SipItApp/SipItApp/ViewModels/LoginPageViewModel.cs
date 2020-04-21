using Prism.Navigation;
using Prism.Services;
using SipItApp.Model;
using SipItApp.Services;
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
        public LoginPageViewModel(ILoginService loginService) 
        {
            Console.WriteLine("LoginPage created");
            this.loginService = loginService;
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
        private readonly ILoginService loginService;

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

                //This is just to emulate the function to set a customer to be used throughout 
                //the app
                loginService.setCurrentCustomer(new Customer()
                {
                    FirstName = userLogin                    
                }); 

                Shell.Current.SendBackButtonPressed();
            }));
    }
}
