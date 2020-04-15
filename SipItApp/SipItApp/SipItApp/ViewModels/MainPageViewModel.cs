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

        //private IList<ImageSource> carouselList;
        //public IList<ImageSource> CarouselList 
        //{
        //    get { return carouselList; }
        //    set
        //    {
        //        SetProperty(ref carouselList, CreateCollection() );
        //    }
        //};
        public IList<CarouselItem> CarouselList;
        public ObservableCollection<CarouselItem> mainCarousel { get; private set; }

        public MainPageViewModel(ISipItService sipItService) 
        {
            Console.WriteLine("Created new MainPage");

            Title = "Sip It";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            CarouselList = new List<CarouselItem>();
            CreateCollection();
            //Customers = sipItService.GetCustomers();
           
        }
        public ImageSource HomeImage => ImageSource.FromResource("SipItApp.Images.home.png");
        public ImageSource HomeImage2 => ImageSource.FromResource("SipItApp.Images.user.png");
        public ImageSource HomeImage3 => ImageSource.FromResource("SipItApp.Images.drink.png");

        private void CreateCollection()
        {
            CarouselList.Add(new CarouselItem
            {
                ImageUrl = HomeImage
                
            });
            CarouselList.Add(new CarouselItem
            {
                ImageUrl = HomeImage2

            });
            CarouselList.Add(new CarouselItem
            {
                ImageUrl = HomeImage3

            });

            mainCarousel = new ObservableCollection<CarouselItem>(CarouselList);
        }

        //public MainPageViewModel()
        //{
        //    defineTitle();
        //    BackgroundLogo = ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        //}

        //public IEnumerable<Customer> Customers { get; private set; }

        //public string Title { get; set; }

        public string MyText => "Hello World!";              

        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        public event PropertyChangedEventHandler PropertyChanged;

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
                String thisRoute = "home";
                await Shell.Current.GoToAsync($"//order?route={thisRoute}");
                
                
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
