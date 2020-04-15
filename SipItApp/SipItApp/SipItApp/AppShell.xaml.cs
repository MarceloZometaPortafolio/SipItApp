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
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
            Title = "Testing";
        }
        public ImageSource HomeImage => ImageSource.FromResource("SipItApp.Images.home.png");
        public ImageSource UserImage => ImageSource.FromResource("SipItApp.Images.user.png");
        public ImageSource MenuImage => ImageSource.FromResource("SipItApp.Images.drink.png");
        public ImageSource OrderImage => ImageSource.FromResource("SipItApp.Images.order.png");

        void RegisterRoutes()
        {
            routes.Add("itemdetails", typeof(ItemDetailPage));
            ///routes.Add("order", typeof(OrderPage));

            foreach(var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}