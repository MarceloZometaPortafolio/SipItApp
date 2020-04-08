using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel() 
        {
            Console.WriteLine("Created new SettingsPage");
            Title = "Settings";
        }

        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");

        public string MySettingsText => "this is bound!";
    }
}
