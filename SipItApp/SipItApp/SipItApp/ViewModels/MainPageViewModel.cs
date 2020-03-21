using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sip It";            
        }
        public ImageSource BackgroundImage => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");                

        //public ImageSource Images => ImageSource.FromResource("SipItApp.Images.chirs.jpg");
    }
}
