using SipItApp.Model;
using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class MenuPageViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;
        private List<String> mylist;

        public MenuPageViewModel(ISipItService sipItService)
        {
            Console.WriteLine("Created new MenuPage");

            Title = "Menu";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));

            //Customers = sipItService.GetCustomers();
        }

        //Images
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");


        //Property creation
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

        //Commands
        private Command backCommand;
        public Command BackCommand => backCommand ?? (backCommand = new Command(async
            () =>
        {
            //backButton.Command.Execute(Console.WriteLine("I was called");
            await Shell.Current.GoToAsync($"//{pastRoute}/");
        }));
        public ImageSource BackButton => ImageSource.FromResource("SipItApp.Images.back.png");
    }
}
