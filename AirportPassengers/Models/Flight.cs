using System;
using System.Collections.Generic;

namespace AirportPassengers.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Number { get; set;}
        public DateTime DepartureTime { get; set; }
        public IEnumerable<Passenger> Passengers { get; set; }
    }
}
