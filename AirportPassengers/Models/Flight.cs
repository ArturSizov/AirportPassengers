using System;
using System.Collections.ObjectModel;

namespace AirportPassengers.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Number { get; set;}
        public DateTime DepartureTime { get; set; }
        public ObservableCollection<Passenger> Passengers { get; set; }
    }
}
