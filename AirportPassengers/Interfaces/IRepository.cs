using AirportPassengers.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AirportPassengers.Interfaces
{
    public interface IRepository 
    {
        ObservableCollection<Flight> Flights { get; set; }
        void LoadingFromFile();
        Task SaveFile();
        void CreatePassender(Passenger passenger);
        bool CreateFlight(Flight flight);
    }
}
