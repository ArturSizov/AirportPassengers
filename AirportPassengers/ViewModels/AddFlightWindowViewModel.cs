using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using AirportPassengers.Services;
using AirportPassengers.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace AirportPassengers.ViewModels
{
    public class AddFlightWindowViewModel : BindableBase
    {
        #region Private property
        private Flight flight;
        private IRepository repository;
        #endregion

        public AddFlightWindowViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        #region Public propert
        public string Title => "Добавить рейс";
        public Flight Flight { get => flight; set => SetProperty(ref flight, value); }

        #endregion

        #region Commands
        public ICommand AddFlight => new DelegateCommand(async()=>
        {
            repository.Flights.Add(flight);
            repository.Flights.Add(Flight);
        });

        #endregion
    }
}
