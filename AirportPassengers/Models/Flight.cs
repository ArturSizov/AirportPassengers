using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace AirportPassengers.Models
{
    public class Flight : BindableBase
    {
        private int id;
        private int flightNumber;
        private DateTime departureTime;
        private ObservableCollection<Passenger>? passengers = new();
        private int dispatchHours;

        public int Id { get => id; set => SetProperty(ref id, value); }
        public int FlightNumber { get => flightNumber; set => SetProperty(ref flightNumber, value); }
        public DateTime DepartureTime { get => departureTime; set => SetProperty(ref departureTime, value); }
        public int DispatchHours { get => dispatchHours; set => SetProperty(ref dispatchHours, value); }
        public ObservableCollection<Passenger>? Passengers{ get => passengers!; set => SetProperty(ref passengers, value); }
    }
}
