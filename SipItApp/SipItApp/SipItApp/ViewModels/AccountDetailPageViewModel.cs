using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SipItApp.ViewModels
{
    public class AccountDetailPageViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;

        public AccountDetailPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new MainPage");

            Title = "Your account";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo


            //Customers = sipItService.GetCustomers();

        }
    }
}
