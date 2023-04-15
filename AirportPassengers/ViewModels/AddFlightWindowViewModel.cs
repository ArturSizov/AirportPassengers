using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace AirportPassengers.ViewModels
{
    public class AddFlightWindowViewModel : BindableBase
    {
        #region Private property
        private Flight flight = new();
        private IRepository repository;
        #endregion

        public AddFlightWindowViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        #region Public propert
        public string Title => "Добавить рейс";
        public Flight Flight { get => flight!; set => SetProperty(ref flight, value); }

        #endregion

        #region Commands
        public ICommand AddFlight => new DelegateCommand<Window>((win)=>
        {
            var fl = new Flight
            {
                Number = flight.Number,
                DepartureTime = flight.DepartureTime
            };
            repository.Flights.Add(fl);
            win.Close();
        });

        public ICommand Close => new DelegateCommand<Window>((win) =>
        {
            win.Close();
        });

        #endregion
    }
}
