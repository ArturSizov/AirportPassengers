using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace AirportPassengers.ViewModels
{
    public class ListDeparturesWindowViewModel : BindableBase, IListDeparturesWindowViewModel
    {
        #region Private property
        private ObservableCollection<Flight> flights = new();
        private Flight selectedFlight;

        #endregion

        #region Piblic property
        public string Title => "Airport Passengers";
        public ObservableCollection<Flight> Flights { get => flights; set => SetProperty(ref flights, value); }
        public  Flight SelectedFlight { get => selectedFlight; set => SetProperty(ref selectedFlight, value); }

        #endregion

        public ListDeparturesWindowViewModel()
        {
            var fl = new Flight
            {
                DepartureTime = DateTime.Now,
                Id = 1,
                Number = 1,
                Passengers = new ObservableCollection<Passenger>
                {
                    new Passenger
                    {
                        IdFlight = 1,
                        IdPassenger = 1,
                        LastName = "Sizov",
                        MiddleName = "Gennadevich",
                        Name = "Artur"
                    },
                    new Passenger
                    {
                        IdFlight = 2,
                        IdPassenger = 2,
                        LastName = "Sizov",
                        MiddleName = "Arturovich",
                        Name = "Amir"
                    },
                    new Passenger
                    {
                        IdFlight = 2,
                        IdPassenger = 2,
                        LastName = "Sizov",
                        MiddleName = "Arturovich",
                        Name = "Adel"
                    }
                }
            };
            var fl2 = new Flight
            {
                DepartureTime = DateTime.Now,
                Id = 2,
                Number = 21,
                Passengers = new ObservableCollection<Passenger>
                {
                    new Passenger
                    {
                        IdFlight = 2,
                        IdPassenger = 2,
                        LastName = "Sizov",
                        MiddleName = "Arturovich",
                        Name = "Amir"
                    }
                }
            };

            Flights.Add(fl);
            Flights.Add(fl2);
        }
    }
}
