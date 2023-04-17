using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using AirportPassengers.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Xps.Packaging;

namespace AirportPassengers.ViewModels
{
    public class AddFlightWindowViewModel : BindableBase
    {
        #region Private property
        private Flight? flight;
        private IRepository repository;
        private int dispatchHours = 12;
        #endregion

        #region Public propert
        public string Title => "Добавить рейс";
        public Flight Flight { get => flight!; set => SetProperty(ref flight, value); }
        public int DispatchHours { get => dispatchHours; set => SetProperty(ref dispatchHours, value); }

        #endregion

        public AddFlightWindowViewModel(IRepository repository)
        {
            this.repository = repository;
            Flight = new Flight
            {
                Id = 0,
                Number = 0,
                DepartureTime = DateTime.Now
            };
        }

        #region Commands
        /// <summary>
        /// Add Flight passandeer command
        /// </summary>
        public ICommand AddFlight => new DelegateCommand<Window>((win)=>
        {
            var fl = new Flight
            {
                Number = flight.Number,
                DepartureTime = flight.DepartureTime.Date + new TimeSpan(DispatchHours, 0, 0)
            };

            if (repository.Flights.Where(x => x.Number == fl.Number).Any())
            {
                MessageBox.Show("Рейс с таким номером уже существует", "Airport Passengers", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            repository.Flights.Add(fl);
            win.Close();
        });

        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand Close => new DelegateCommand<Window>((win) =>
        {
            win.Close();
        });

        #endregion
    }
}
