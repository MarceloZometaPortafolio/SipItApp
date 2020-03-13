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
            MyText = "Hi Mom!";
            Images = new List<string>() {
                "SipItApp/Images/chirs.jpg"
            };
        }
        private String myText;

        public String MyText
        {
            get => myText;
            set { SetProperty(ref myText, value);  }
        }


        private List<string> images;
        public List<string> Images
        {
            get => images;
            set { SetProperty(ref images, value); }
        }

        //public ImageSource Images => ImageSource.FromResource("SipItApp.Images.chirs.jpg");
    }
}
