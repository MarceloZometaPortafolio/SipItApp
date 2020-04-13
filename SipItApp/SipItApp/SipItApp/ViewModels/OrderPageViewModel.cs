using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class OrderPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private BackButtonBehavior backButton;
        
        private readonly ISipItService sipItService;
        public OrderPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new OrderPage");

            Title = "Your order";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo
            backButton = new BackButtonBehavior();
            //setBackButtonBehavior();

            //Customers = sipItService.GetCustomers();

        }
        public ImageSource BackButton => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        
        //public async object GoBack()
        //{
        //    Console.WriteLine("BackCommand was pressed!");
        //    await Shell.Current.GoToAsync("//home");

        //    return this;
        //}

        private Command backCommand;
        public Command BackCommand => backCommand ?? (backCommand = new Command(
            () =>
            {
                //backButton.Command.Execute(Console.WriteLine("I was called");
                
            }));

        
    }
}
