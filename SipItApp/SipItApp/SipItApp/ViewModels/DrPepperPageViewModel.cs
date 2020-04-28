using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class DrPepperPageViewModel : ViewModelBase
    {
        public DrPepperPageViewModel()
        {
            Title = "Local Favorites!";
        }
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

    }
}
