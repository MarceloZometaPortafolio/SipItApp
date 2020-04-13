using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SipItApp.Views;
using System.ComponentModel;
using SipItApp.Services;
using SipItApp.Model;
using System.Collections.ObjectModel;
using Prism.Navigation.Xaml;

namespace SipItApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;
        private NavigationPage navigationPage = new NavigationPage();

        public MainPageViewModel(ISipItService sipItService) 
        {
            Console.WriteLine("Created new MainPage");

            Title = "Sip It";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            //BackgroundLogo


            //Customers = sipItService.GetCustomers();

        }
        //public MainPageViewModel()
        //{
        //    defineTitle();
        //    BackgroundLogo = ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        //}

        //public IEnumerable<Customer> Customers { get; private set; }

        //public string Title { get; set; }

        public string MyText => "Hello World!";

        //public ImageSource BackgroundImage => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");                

        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");


        public event PropertyChangedEventHandler PropertyChanged;

        //private void defineBackgroundImage()
        //{
        //    BackgroundLogo = ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        //}

        private void defineTitle()
        {
            Title = "Sip It!";
        }

        private Command getUsual;
        public Command GetUsual => getUsual ?? (getUsual = new Command(
            () =>
            {
                //navigationService.NavigateAsync(nameof(SettingsPage));
                Console.WriteLine("GetUsual command triggered");
            }));

        private Command orderItem;
        public Command OrderItem => orderItem ?? (orderItem = new Command(async
            () =>
            {
                Console.WriteLine("OrderItem command triggered");
                await Shell.Current.GoToAsync("//order");
                
                
                //await navigationPage.PushAsync(new OrderPage());
            }));

        private Command seeMenu;
        public Command SeeMenu => seeMenu ?? (seeMenu = new Command(async
            () =>
            {
                Console.WriteLine("SeeMenu command triggered");
                await Shell.Current.GoToAsync("//menu");
            }));
    }
}
