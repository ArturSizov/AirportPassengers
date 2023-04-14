namespace AirportPassengers.Models
{
    public class Passenger
    {
        public int IdFlight { get; set; }       
        public int IdPassenger { get; set; }
        public string Name { get; set; }    
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
