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
        MainPageViewModel viewModel;
        private INavigationService navigationService;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageViewModel(navigationService);           
        }

        //public ImageSource BackgroundImageSource { get; set; }
    }
}