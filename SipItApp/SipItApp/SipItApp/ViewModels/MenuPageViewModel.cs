using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SipItApp.ViewModels
{
    public class MenuPageViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;
        private List<String> mylist;

        public MenuPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new MenuPage");

            Title = "Menu";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo

            //Customers = sipItService.GetCustomers();
        }
    }
}
