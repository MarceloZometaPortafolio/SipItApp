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
using System.Diagnostics;

namespace SipItApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly ISipItService sipItService;
        private readonly ILoginService loginService;
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
        public IList<Customer> RecommendedItems;    //Temporarily holds customers
        public ObservableCollection<CarouselItem> mainCarousel { get; private set; }
        public ObservableCollection<Customer> recommendedList { get; private set; } //Temporarily holds customers

        public ImageSource UserImage => ImageSource.FromResource("SipItApp.Images.user.png");

        public MainPageViewModel(ISipItService sipItService, ILoginService loginService)
        {
            Console.WriteLine("Created new MainPage");

            Title = "Sip It";
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            this.loginService = loginService;
            CarouselList = new List<CarouselItem>();
            RecommendedItems = new List<Customer>();

            CreateCarousel();
            CreateRecommendedList();
            //Customers = sipItService.GetCustomers();                      
        }

        //Images
        public ImageSource HomeImage => ImageSource.FromResource("SipItApp.Images.happyeaster.jpg");
        public ImageSource HomeImage2 => ImageSource.FromResource("SipItApp.Images.easterfun.jpg");
        public ImageSource HomeImage3 => ImageSource.FromResource("SipItApp.Images.carona.jpg");
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        //Populate CarouselView
        private void CreateCarousel()
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

        //Populate Recommended Items box
        private void CreateRecommendedList()
        {
            RecommendedItems.Add( new Customer 
            {
                FirstName = "Dirty Dr. Pepper"
            });
            RecommendedItems.Add(new Customer
            {
                FirstName = "Ironport"
            });
            RecommendedItems.Add(new Customer
            {
                FirstName = "Tiger's Blood"
            });
            recommendedList = new ObservableCollection<Customer>(RecommendedItems);
        }

        //public MainPageViewModel()
        //{
        //    defineTitle();
        //    BackgroundLogo = ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        //}

        //public IEnumerable<Customer> Customers { get; private set; }

        //public string Title { get; set; }

        public string MyText => "Hello World!";              
        public event PropertyChangedEventHandler PropertyChanged;

        public String LoginText => "Login";
        //public String LoginText {
        //    set
        //    {
        //        if(loginService.getCurrentCustomer() == null)
        //        {
        //            loginText = "Login";

        //            RaisePropertyChanged("LoginText");
        //        }
        //        else
        //        {
        //            loginText = $"Hi, {loginService.getCurrentCustomer().FirstName}";
        //        }
        //    }
        //    get
        //    {
        //        return loginText;
        //    }
        //}

        private Customer _ItemSelected;
        public Customer objItemSelected
        {
            get
            {
                return _ItemSelected;
            }
            set
            {
                if(_ItemSelected != value)
                {
                    _ItemSelected = value;
                    Console.WriteLine(value.FirstName + " was tapped");

                    RecommendedSelected(value);
                }
            }
        }

        //Commands
        private Command getUsual;
        public Command GetUsual => getUsual ?? (getUsual = new Command(
            () =>
            {
                //navigationService.NavigateAsync(nameof(SettingsPage));
                Debug.WriteLine("GetUsual command triggered");
                Debug.WriteLine(loginService.getCurrentCustomer().FirstName);
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

        //private Command recommendedSelected;
        //public Command RecommendedSelected => recommendedSelected ?? (recommendedSelected = new Command(async
        //    () =>
        //    {
        //        Console.WriteLine("RecommendedSelected command triggered");
        //        await Shell.Current.GoToAsync("//menu");
        //    }));

        public async void RecommendedSelected(Customer value)
        {
            Debug.WriteLine("RecommendedSelected command triggered");
            await Shell.Current.GoToAsync("//menu",true);
        }

        public event EventHandler<ItemTappedEventArgs> ItemTapped;
        void MyItemTapped(object sender, EventArgs args)
        {
            Console.WriteLine("Item was tapped");
        }

        private Command loginCommand;
        public Command LoginCommand => loginCommand ?? (loginCommand = new Command(async
            () =>
            {
                Console.WriteLine("LoginCommand was clicked");
                
                if(loginService.getCurrentCustomer() == null)
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
