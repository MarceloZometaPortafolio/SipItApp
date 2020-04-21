using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class OrderPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private BackButtonBehavior backButton;
        
        private readonly ISipItService sipItService;
        private readonly ILoginService loginService;

        public OrderPageViewModel(ISipItService sipItService, ILoginService loginService)
        {
            Console.WriteLine("Created new OrderPage");
            Title = "Your order";           
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            this.loginService = loginService;
            backButton = new BackButtonBehavior();            

            //Customers = sipItService.GetCustomers();

        }

        private String pastRoute;
        public String PastRoute
        {
            get
            {
                return pastRoute;
            }
            set
            {
                SetProperty(ref pastRoute, Uri.UnescapeDataString(value));
            }
        }
        public ImageSource BackButton => ImageSource.FromResource("SipItApp.Images.back.png");
        
        //public async object GoBack()
        //{
        //    Console.WriteLine("BackCommand was pressed!");
        //    await Shell.Current.GoToAsync("//home");

        //    return this;
        //}

        private Command backCommand;
        public Command BackCommand => backCommand ?? (backCommand = new Command(async
            () =>
            {
                //backButton.Command.Execute(Console.WriteLine("I was called");
                await Shell.Current.GoToAsync($"//{pastRoute}/");
            }));

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
