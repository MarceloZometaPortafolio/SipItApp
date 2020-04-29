using SipItApp.Model;
using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class LocalFavoritesPageViewModel : ViewModelBase
    {
        private readonly ISipItService sipItService;

        public LocalFavoritesPageViewModel(ISipItService sipItService)
        {
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));

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

    }
}
