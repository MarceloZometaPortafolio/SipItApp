using Prism.Navigation;
using SipItApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SipItApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        //MainPageViewModel viewModel;
        //private INavigationService navigationService;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            //BindingContext = viewModel = new MainPageViewModel(navigationService);           
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string itemName = (e.CurrentSelection.FirstOrDefault() as String);
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"itemdetails?name={itemName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/monkeys/monkeydetails?name={monkeyName}");
        }

        //public ImageSource BackgroundImageSource { get; set; }
    }
}