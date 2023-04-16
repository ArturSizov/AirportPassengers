using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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
        public ICommand AddFlight => new DelegateCommand<Window>((win)=>
        {
            var fl = new Flight
            {
                Number = flight.Number,
                DepartureTime = flight.DepartureTime.Date + new TimeSpan(DispatchHours, 0, 0)
            };

            if(repository.Flights.Count != 0)
            {
                foreach (var item in repository.Flights)
                {
                    if (item.Number != fl.Number)
                        repository.Flights.Add(fl);
                }
            }
            else repository.Flights.Add(fl);

            win.Close();
        });

        public ICommand Close => new DelegateCommand<Window>((win) =>
        {
            win.Close();
        });

        #endregion
    }
}
