using AirportPassengers.Infrastructure;
using AirportPassengers.Interfaces;
using AirportPassengers.Services;
using AirportPassengers.ViewModels;
using AirportPassengers.ViewModels.Locator;
using AirportPassengers.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prism.Services.Dialogs;
using System;
using System.Windows;
using Unity;

namespace AirportPassengers
{
    public partial class App : Application
    {
        public App()
        {
            ConfigureIOC();
        }

        private void ConfigureIOC()
        {
            RootContainer.Container.RegisterSingleton<ListDeparturesWindow>();
            RootContainer.Container.RegisterSingleton<AddFlightWindow>();
            RootContainer.Container.RegisterSingleton<AddPassengerWindowViewModel>();
            RootContainer.Container.RegisterSingleton<IRepository, Repository>();

        }
    }
}
