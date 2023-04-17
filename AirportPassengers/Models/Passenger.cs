using Prism.Mvvm;

namespace AirportPassengers.Models
{
    public class Passenger : BindableBase
    {
        private string? middleName;
        private string? lastName;
        private string? name;
        private int idPassenger;
        private int idFlight;

        public int IdFlight { get => idFlight; set => SetProperty(ref idFlight, value); }
        public int IdPassenger { get => idPassenger; set => SetProperty(ref idPassenger, value);}
        public string? Name { get => name; set => SetProperty(ref name, value); }
        public string? LastName { get => lastName; set => SetProperty(ref lastName, value); }
        public string? MiddleName { get => middleName; set => SetProperty(ref middleName, value); }
    }
}
