using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using AirportPassengers.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AirportPassengers.ViewModels
{
    public class ListDeparturesWindowViewModel : BindableBase
    {
        #region Private property
        private ObservableCollection<Flight>? flights;
        private Flight? selectedFlight;
        private readonly IRepository repository;
        #endregion

        #region Piblic property
        public string Title => "Airport Passengers";
        public ObservableCollection<Flight> Flights { get => flights!; set => SetProperty(ref flights, value); }
        public  Flight SelectedFlight { get => selectedFlight!; set => SetProperty(ref selectedFlight, value); }
        #endregion

        public ListDeparturesWindowViewModel(IRepository repository)
        {
            this.repository = repository;
            Flights = repository.Flights;
        }

        #region Commands
        /// <summary>
        /// Download command from json file
        /// </summary>
        public ICommand LoadingFromFile => new DelegateCommand(() =>
        {
            repository.LoadingFromFile();
        });

        // <summary>
        /// Save file command
        /// </summary>
        public ICommand SaveFile => new DelegateCommand(async() =>
        {
            await repository.SaveFile();
        });

        /// <summary>
        /// Open add flight window
        /// </summary>
        public ICommand OpenAddFlightWindow => new DelegateCommand(() =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var win = new AddFlightWindow();

                win.ShowDialog();
            });
        });

        /// <summary>
        /// Open add flight window
        /// </summary>
        public ICommand OpenAddPassengerWindow => new DelegateCommand(() =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var win = new AddPassengerWindow();

                win.ShowDialog();
            });
        });
        #endregion
    }
}
