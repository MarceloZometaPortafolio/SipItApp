using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SipItApp.ViewModels
{
    public class OrderPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;
        public OrderPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new MainPage");

            Title = "Your order";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo


            //Customers = sipItService.GetCustomers();

        }
    }
}
