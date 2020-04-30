using Prism.Navigation;
using Prism.Services;
using SipItApp.Model;
using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        PageDialogService pageDialogService;
        public IEnumerable<Customer> Customers { get; set; }

        public LoginPageViewModel(ISipItService sipItService, ILoginService loginService) 
        {
            Console.WriteLine("LoginPage created");
            this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            loadCustomersAsync(sipItService);
        }

        private async Task loadCustomersAsync(ISipItService sipItService)
        {
            try
            {
                Customers = await sipItService.GetCustomersAsync();
                RaisePropertyChanged(nameof(Customers));
            }
            catch (Exception e)
            {

            }
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
                foreach (Customer customer in Customers)
                {
                    if (userLogin == customer.Username)
                    {
                        if (userPassword != customer.Password)
                        {
                            Debug.WriteLine("Wrong password! You shall not pass!");
                            var answer = await Shell.Current.DisplayAlert("Incorrect password",
                                "Do you want to try again", "Yes", "I forgot my password");
                            if (answer == false)
                            {
                                Debug.WriteLine("User forgot password. Execute something");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("User access granted.");
                            loginService.setCurrentCustomer(customer);

                            Shell.Current.SendBackButtonPressed();
                        }
                    }
                }
                //if (userLogin != "marcelo" || userPassword != "zometa")
                //{
                //    Debug.WriteLine("Wrong! You shall not pass!");
                //    var answer = await Shell.Current.DisplayAlert("Incorrect username or password",
                //        "Do you want to try again", "Yes", "I forgot my password");
                //    if(answer == false)
                //    {
                //        Debug.WriteLine("User forgot password. Execute something");
                //    }
                //}
                //Debug.WriteLine("User access granted.");

                ////This is just to emulate the function to set a customer to be used throughout 
                ////the app
                //loginService.setCurrentCustomer(new Customer()
                //{
                //    FirstName = userLogin                    
                //}); 

                //Shell.Current.SendBackButtonPressed();
            }));
    }
}
