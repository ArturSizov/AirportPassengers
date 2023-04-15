using AirportPassengers.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace AirportPassengers.ViewModels.Locator
{
    public class ViewModelLocator
    {
        public ListDeparturesWindowViewModel ListDeparturesWindowViewModel => RootContainer.Container.Resolve<ListDeparturesWindowViewModel>();
        public AddFlightWindowViewModel AddFlightWindowViewModel => RootContainer.Container.Resolve<AddFlightWindowViewModel>();
    }
}
