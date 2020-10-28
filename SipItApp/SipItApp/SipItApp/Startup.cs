using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Xamarin.Essentials;
using Refit;
using SipItApp.Services;
using SipItApp.ViewModels;
using Prism.Services;
using SipItApp.Data;

namespace SipItApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }


        public static void Init()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //asse
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SipItApp.appsettings.json"))
            {
                var host = new HostBuilder()
                    .ConfigureHostConfiguration(c =>
                    {
                        // Tell the host configuration where to file the file (this is required for Xamarin apps)
                        c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                        //read in the configuration file!
                        c.AddJsonStream(stream);
                    })
                    .ConfigureServices((c, x) =>
                    {
                        // Configure our local services and access the host configuration
                        ConfigureServices(c, x);
                    })
                    .ConfigureLogging(l => l.AddConsole(o =>
                    {
                        //setup a console logger and disable colors since they don't have any colors in VS
                        o.DisableColors = true;
                    }))
                    .Build();

                //Save our service provider so we can use it later.
                ServiceProvider = host.Services;
            }
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            // The HostingEnvironment comes from the appsetting.json and could be optionally used to configure the mock service
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                // add as a singleton so only one ever will be created.
                //services.AddSingleton<IDataService, MockDataService>();
                //PageDialogService pageDialogService;
                //_ = services.AddSingleton<IPageDialogService>(pageDialogService);
            }
            else
            {
                //services.AddSingleton<IDataService, MyDataService>();
            }

            // add the ViewModel, but as a Transient, which means it will create a new one each time.
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<OrderPageViewModel>();
            services.AddTransient<MenuPageViewModel>();
            services.AddTransient<AccountDetailPageViewModel>();
            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<RegisterPageViewModel>();

            //Another thing we can do is access variables from that json file
            var world = ctx.Configuration["Hello"];
        }       
    }
}