using AirportPassengers.Interfaces;
using AirportPassengers.ViewModels;
using AirportPassengers.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AirportPassengers
{
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IListDeparturesWindowViewModel ,ListDeparturesWindowViewModel>();
                    services.AddSingleton<ListDeparturesWindow>();

                }).Build();

            using(var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var mWindow = services.GetRequiredService<ListDeparturesWindow>();
                    mWindow.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
            }
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = host.Services.GetService<ListDeparturesWindow>();
            mainWindow.Show();
        }

 
        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
