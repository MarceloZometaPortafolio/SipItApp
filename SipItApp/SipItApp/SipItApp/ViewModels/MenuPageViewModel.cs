using Prism.DryIoc;
using Prism.Ioc;
using Refit;
using SipItApp.Data;
using SipItApp.Model;
using SipItApp.Services;
using SipItApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("PastRoute", "route")]
    public class MenuPageViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private readonly IAPIService service;
        public IEnumerable<Sanpetefavorites> MenuItems { get; set; }

        public MenuPageViewModel()
        {
            Console.WriteLine("Created new MenuPage");

            try
            {
                Title = "Menu";
                service = RestService.For<IAPIService>("https://sipitapi.herokuapp.com");
                //GetData.Execute(GetData);

            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }

        //Images
        public ImageSource BackgroundLogo => ImageSource.FromResource("SipItApp.Images.SipItLogo.png");
        public ImageSource BackButton => ImageSource.FromResource("SipItApp.Images.back.png");
        
        
        //Property creation
        private String pastRoute;
        public String PastRoute
        {
            get
            {
                return pastRoute;
            }
            set
            {
                SetProperty(ref pastRoute, Uri.UnescapeDataString(value));
            }
        }

        //Commands
        private Command backCommand;

        public Command BackCommand => backCommand ?? (backCommand = new Command(async
            () =>
        {
            //backButton.Command.Execute(Console.WriteLine("I was called");
            await Shell.Current.GoToAsync($"//{pastRoute}/");
        }));

        private Command getData;

        public Command GetData=> getData ?? (getData = new Command(async
            () =>
        {
            //backButton.Command.Execute(Console.WriteLine("I was called");
            MenuItems = await service.GetSanpeteFavorites();
        }));
    }
}
