using SipItApp.Model;
using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class LocalFavoritesPageViewModel : ViewModelBase
    {
        private readonly ISipItService sipItService;
        private readonly ILoginService loginService;

        public LocalFavoritesPageViewModel(ISipItService sipItService, ILoginService loginService)
        {
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            Title = "Local Favorites";
            loadDrinksAsync(sipItService);
        }

        private async Task loadDrinksAsync(ISipItService sipItService)
        {
            AllDrinks = await sipItService.GetDrinksAsync();

            MtnDewDrinks = from drink in AllDrinks
                           where drink.Base == "Mtn Dew"
                           select drink;

            DrPepperDrinks = from drink in AllDrinks
                             where drink.Base == "Dr. Pepper"
                             select drink;

            SpriteDrinks = from drink in AllDrinks
                           where drink.Base == "Sprite"
                           select drink;

            CokeDrinks = from drink in AllDrinks
                         where drink.Base == "Coca-Cola"
                         select drink;

            PepsiDrinks = from drink in AllDrinks
                          where drink.Base == "Pepsi"
                          select drink;

            MonsterDrinks = from drink in AllDrinks
                            where drink.Base == "Monster Energy"
                            select drink;


            RaisePropertyChanged(nameof(AllDrinks));
            RaisePropertyChanged(nameof(MtnDewDrinks));
            RaisePropertyChanged(nameof(DrPepperDrinks));
            RaisePropertyChanged(nameof(SpriteDrinks));
            RaisePropertyChanged(nameof(PepsiDrinks));
            RaisePropertyChanged(nameof(CokeDrinks));
            RaisePropertyChanged(nameof(MonsterDrinks));
        }

        public IEnumerable<Drink> AllDrinks { get; set; }
        public IEnumerable<Drink> MtnDewDrinks { get; set; }
        public IEnumerable<Drink> DrPepperDrinks { get; set; }
        public IEnumerable<Drink> SpriteDrinks { get; set; }
        public IEnumerable<Drink> PepsiDrinks { get; set; }
        public IEnumerable<Drink> CokeDrinks { get; set; }
        public IEnumerable<Drink> MonsterDrinks { get; set; }

        private Command loginCommand;
        public Command LoginCommand => loginCommand ?? (loginCommand = new Command(async
            () =>
        {
            Console.WriteLine("LoginCommand was clicked");

            if (loginService.getCurrentCustomer() == null)
            {
                Debug.WriteLine("User is empty. Login");
                await Shell.Current.GoToAsync("login", true);
            }
            else
            {
                Debug.WriteLine("User is not empty. Account details");
                await Shell.Current.GoToAsync("account_details", true);
            }
        }));

        private Command addToOrder;
        public Command AddToOrder => addToOrder ?? (addToOrder = new Command(
            () =>
            {
                Debug.WriteLine("AddToOrder command triggered");

            }));
    }
}
