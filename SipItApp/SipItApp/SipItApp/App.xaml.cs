using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Refit;
using SipItApp.Services;
using SipItApp.ViewModels;
using SipItApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SipItApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) 
        {
            //var menuPage = new HamburgerMenu();
            //NavigationPage navigation = new NavigationPage(new MainPage());
            //var masterPage = new HomePage();
            //masterPage.Master = menuPage;
            //masterPage.Detail = navigation;

            //var settingsPage = new SettingsPage();

            //MainPage = masterPage;

            //Here, according to Xaminals it needs to go Startup.Init();
            Startup.Init();
            MainPage = new AppShell();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/OrderPage");

            //var navigationService = this.Container.Resolve<INavigationService>();
            //((NavigationPage)MainPage).RootPage.BindingContext = new MainPageViewModel(navigationService);            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            //containerRegistry.RegisterForNavigation<ItemDetailPage, ItemDetailViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();            
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<AppShell, AppShellViewModel>();
            containerRegistry.RegisterForNavigation<OrderPage, OrderPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountDetailPage, AccountDetailPageViewModel>();

           // var sipItService = RestService.For<ISipItService>("https:/localhost:32770");
           // containerRegistry.RegisterInstance(sipItService);

        }
    }
}
