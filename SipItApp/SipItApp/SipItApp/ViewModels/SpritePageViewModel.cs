using SipItApp.Model;
using SipItApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class SpritePageViewModel : ViewModelBase
    {
        private readonly ISipItService sipItService;
        private readonly ILoginService loginService;

        public SpritePageViewModel(ISipItService sipItService, ILoginService loginService)
        {
            Title = "Local Favorites!";

            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));
            this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));

            //getDrinksFromAPI();
            getDrinksFromSeed();
        }
       
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        //public IEnumerable<Drink> DrinksList { get; set; }
        public ObservableCollection<Drink> DrinksList { get; set; }

        private async Task getDrinksFromAPI()
        { 

            try
            {
                //DrinksList = await sipItService.GetDrinksAsync();
                //RaisePropertyChanged(nameof(DrinksList));
            }
            catch (Exception e)
            {

            }
        }

        public void getDrinksFromSeed()
        {
            DrinksList = new ObservableCollection<Drink>();

            Drink drink1 = new Drink()
            {
                Id = 1,
                Base = "Dr. Pepper",
                Additions = { "Coconut", "cream" },
                Name = "Dirty Dr.Pepper"
            };
            Drink drink2 = new Drink()
            {
                Id = 2,
                Base = "Sprite",
                Additions = { "Blue Coconut" },
                Name = "Cougar Juice"
            };

            Drink drink3 = new Drink()
            {
                Id = 3,
                Base = "Mt.Dew",
                Additions = { "Coconut", "Peach" },
                Name = "Maui Breeze"
            };

            Drink drink4 = new Drink()
            {
                Id = 4,
                Base = "Root Beer",
                Additions = { "Vanilla", "cream" },
                Name = "Vanilla Brew"
            };

            DrinksList.Add(drink1);
            DrinksList.Add(drink2);
            DrinksList.Add(drink3);
            DrinksList.Add(drink4);
        }
    }
}
