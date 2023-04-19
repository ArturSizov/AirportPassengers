using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using AirportPassengers.Services;
using AirportPassengers.Views;
using Microsoft.Extensions.Logging;
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
        private Flight flight = new();
        private Passenger passenger = new();
        private readonly IRepository repository;
        private readonly IDialogService dialogService;
        private readonly ILogger<Repository> logger;
        #endregion

        #region Piblic property
        public string Title => "Airport Passengers";
        public ObservableCollection<Flight> Flights { get => flights!; set => SetProperty(ref flights, value); }
        public  Flight Flight { get => flight; set => SetProperty(ref flight, value); }
        public Passenger Passenger { get => passenger; set => SetProperty(ref passenger, value); }

        #endregion

        public ListDeparturesWindowViewModel(IRepository repository, IDialogService dialogService, ILogger<Repository> logger)
        {
            this.repository = repository;
            this.dialogService = dialogService;
            this.logger = logger;
            Flights = repository.Flights;
        }

        #region Commands
        /// <summary>
        /// Download command from json file
        /// </summary>
        public ICommand LoadingFromFileCommand => new DelegateCommand(() =>
        {
            repository.LoadingFromFile();
        });

        // <summary>
        /// Save file command
        /// </summary>
        public ICommand SaveFileCommand => new DelegateCommand(async() =>
        {
            await repository.SaveFile();
        });

        /// <summary>
        /// Open add flight window
        /// </summary>
        public ICommand OpenCreateFlighDialogCommand => new DelegateCommand(() =>
        {
            dialogService.ShowDialog(nameof(AddFlightDialog)); 
        });

        /// <summary>
        /// Open add flight window
        /// </summary>
        public ICommand OpenCreatePassengerDialogCommand => new DelegateCommand(() =>
        {
            dialogService.ShowDialog(nameof(AddPassengerDialog)); 
        });

        /// <summary>
        /// Passenger removal Command
        /// </summary>
        public ICommand RemovePassengerCommand => new DelegateCommand<Passenger>((passenger) =>
        {
            if (MessageBox.Show("Вы действительно хотите удалить пассажира?", $"Удаления рейса: {passenger.Name}", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;
            Flight?.Passengers?.Remove(passenger);
            logger.LogInformation($"Passenger removed: {passenger.Name}");
        });

        /// <summary>
        /// Passenger edit command
        /// </summary>
        public ICommand EditPassengerDialogCommand => new DelegateCommand<Passenger>((passenger) =>
        {
            var parameters = new DialogParameters
            {
                { "passenger", passenger }
            };

            dialogService.ShowDialog(nameof(AddPassengerDialog), parameters, result =>
            {
                if (result.Result == ButtonResult.Cancel)
                    return;
                Flight?.Passengers?.Remove(Passenger);
            });
        });

        /// <summary>
        /// Flight edit command
        /// </summary>
        public ICommand EditFlightCommand => new DelegateCommand<Flight>((Flight flight) =>
        {
            var parameters = new DialogParameters
            {
                { "flight", Flight }
            };

            dialogService.ShowDialog(nameof(AddFlightDialog), parameters, result =>
            {
                if (result.Result == ButtonResult.Cancel)
                    return;

                repository.Flights.Remove(Flight);
            });
        });

        /// <summary>
        /// Passenger removal Command
        /// </summary>
        public ICommand RemoveFlightCommand => new DelegateCommand<Flight>((flight) =>
        {
            if (MessageBox.Show("Вы действительно хотите удалить рейс?", $"Удаления рейса: {flight.FlightNumber}", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;

            repository.Flights?.Remove(flight);
            logger.LogInformation($"Flight removed: {flight.FlightNumber}");
        });
        #endregion
    }
}
