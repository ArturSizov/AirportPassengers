using AirportPassengers.Interfaces;
using Prism.Mvvm;

namespace AirportPassengers.ViewModels
{
    public class ListDeparturesWindowViewModel : BindableBase, IListDeparturesWindowViewModel
    {
        #region Piblic property
        public string Title => "Airport Passengers";

        #endregion
    }
}
