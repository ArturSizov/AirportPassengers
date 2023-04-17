using AirportPassengers.Infrastructure;
using Unity;

namespace AirportPassengers.ViewModels.Locator
{
    public class ViewModelLocator
    {
        public ListDeparturesWindowViewModel ListDeparturesWindowViewModel => RootContainer.Container.Resolve<ListDeparturesWindowViewModel>();
        public AddFlightWindowViewModel AddFlightWindowViewModel => RootContainer.Container.Resolve<AddFlightWindowViewModel>();
        public AddPassengerWindowViewModel AddPassengerWindowViewModel => RootContainer.Container.Resolve<AddPassengerWindowViewModel>();
    }
}
