using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class OrderPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private BackButtonBehavior backButton;
        
        private readonly ISipItService sipItService;
        public OrderPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new OrderPage");
            Title = "Your order";
            //Console.WriteLine(pastRoute);
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo
            backButton = new BackButtonBehavior();
            //setBackButtonBehavior();

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

        
    }
}
