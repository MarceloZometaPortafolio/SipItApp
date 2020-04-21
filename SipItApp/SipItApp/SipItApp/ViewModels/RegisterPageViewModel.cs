using Prism.Navigation;
using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private Customer customer;
        public RegisterPageViewModel()
        {
            customer = new Customer();
        }

        //DebuggerDisplayAttribute

        private String userFirstName;
        public String UserFirstName {get; set;}

        private String userLastName;
        public String UserLastName { get; set; }

        private String username;
        public String Username { get; set; }

        private String userEmail;
        public String UserEmail { get; set; }

        private String password;
        public String Password { get; set; }

        private Command createAccount;
        public Command CreateAccount => createAccount ?? (createAccount = new Command(async
            () =>
            {
                Debug.WriteLine("CreateAccount command");             

                Debug.WriteLine(UserFirstName);
                customer.FirstName = UserFirstName;

                Debug.WriteLine(UserLastName);
                customer.LastName = UserLastName;

                Debug.WriteLine(UserEmail);
                customer.Email = UserEmail;

                Shell.Current.SendBackButtonPressed();
                Shell.Current.SendBackButtonPressed();
            }));

        private Command goToLoginPage;
        public Command GoToLoginPage => goToLoginPage ?? (goToLoginPage = new Command(async 
            () =>
            {
                Debug.WriteLine("GoToLoginPage command was triggered");
                //await Shell.Current.GoToAsync("login", true);
                Shell.Current.SendBackButtonPressed();

            }));        
    }
}
