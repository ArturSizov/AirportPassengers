using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace AirportPassengers.Models
{
    public class Flight : BindableBase
    {
        private int id;
        private int number;
        private DateTime departureTime;
        private ObservableCollection<Passenger>? passengers = new();

        public int Id { get => id; set => SetProperty(ref id, value); }
        public int Number { get => number; set => SetProperty(ref number, value); }
        public DateTime DepartureTime { get => departureTime; set => SetProperty(ref departureTime, value); }
        public ObservableCollection<Passenger>? Passengers{ get => passengers!; set => SetProperty(ref passengers, value); }
    }
}
