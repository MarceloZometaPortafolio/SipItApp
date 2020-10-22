using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SipItApp.ViewModels
{
    public class AccountDetailPageViewModel: ViewModelBase, INotifyPropertyChanged
    {

        public AccountDetailPageViewModel()
        {
            Console.WriteLine("Created new MainPage");

            Title = "Your account";
            //BackgroundLogo


            //Customers = sipItService.GetCustomers();

        }
    }
}
