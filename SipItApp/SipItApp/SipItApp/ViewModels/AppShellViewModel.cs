using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public AppShellViewModel()
        {
            Title = "Testing bind";
        }

        //Navigation images
        public ImageSource HomeImage => ImageSource.FromResource("SipItApp.Images.home.png");
        public ImageSource UserImage => ImageSource.FromResource("SipItApp.Images.user.png");
        public ImageSource MenuImage => ImageSource.FromResource("SipItApp.Images.drink.png");
        public ImageSource OrderImage => ImageSource.FromResource("SipItApp.Images.order.png");

        

    }
}
