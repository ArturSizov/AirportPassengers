using Prism.Ioc;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AirportPassengers.Views;
using AirportPassengers.Interfaces;
using AirportPassengers.Services;

namespace AirportPassengers
{
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<ListDeparturesWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices(services =>
            {
                services.AddLogging(logging => logging.AddConsole());
            });
            containerRegistry.RegisterDialog<AddPassengerDialog>();
            containerRegistry.RegisterDialog<AddFlightDialog>();
            containerRegistry.RegisterScoped<IRepository, Repository>();
        }
    }
}
