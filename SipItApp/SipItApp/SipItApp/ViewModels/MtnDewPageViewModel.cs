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
    public class MtnDewPageViewModel : ViewModelBase
    {
        private readonly ISipItService sipItService;

        public MtnDewPageViewModel(ISipItService sipItService)
        {
            this.sipItService = sipItService ?? throw new ArgumentNullException(nameof(sipItService));

            loadDrinksAsync(sipItService);

            //MtnDewDrinks = from drinks in AllDrinks
            //               where drinks.Base == "Mtn Dew"
            //               select drinks;

            //RaisePropertyChanged(nameof(MtnDewDrinks));
        }

        private async Task loadDrinksAsync(ISipItService sipItService)
        {
            try
            {
                AllDrinks = await sipItService.GetDrinksAsync();
                MtnDewDrinks = from drink in AllDrinks
                               where drink.Base == "Mtn Dew"
                               select drink;

                RaisePropertyChanged(nameof(AllDrinks));
                RaisePropertyChanged(nameof(MtnDewDrinks));
            }
            catch (Exception e)
            {

            }
        }

        

        public IEnumerable<Drink> AllDrinks { get; set; }
        public IEnumerable<Drink> MtnDewDrinks { get; set; }
    }
}
