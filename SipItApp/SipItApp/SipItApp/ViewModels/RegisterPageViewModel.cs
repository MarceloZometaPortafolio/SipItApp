using Prism.Navigation;
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
    public class RegisterPageViewModel : ViewModelBase
    {
        private Customer customer;
        private IEnumerable<Customer> Customers { get; set; }
        public RegisterPageViewModel(ISipItService sipItService)
        {
            customer = new Customer();
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));

            loadCustomersAsync(sipItService);
        }


        private async Task loadCustomersAsync(ISipItService sipItService)
        {
            Customers = await sipItService.GetCustomersAsync();
            RaisePropertyChanged(nameof(Customers));
        }

        //DebuggerDisplayAttribute

        private string userFirstName;
        public string UserFirstName
        {
            get { return userFirstName; }
            set { SetProperty(ref userFirstName, value); }
        }

        private string userLastName;
        public string UserLastName
        {
            get { return userLastName; }
            set { SetProperty(ref userLastName, value); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string userEmail;
        public string UserEmail
        {
            get { return userEmail; }
            set { SetProperty(ref userEmail, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }       

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
        private readonly ISipItService sipItService;

        public Command GoToLoginPage => goToLoginPage ?? (goToLoginPage = new Command(async 
            () =>
            {
                Debug.WriteLine("GoToLoginPage command was triggered");
                //await Shell.Current.GoToAsync("login", true);
                Shell.Current.SendBackButtonPressed();

            }));        
    }
}
