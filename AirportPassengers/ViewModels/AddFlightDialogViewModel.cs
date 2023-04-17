using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AirportPassengers.ViewModels
{
    public class AddFlightDialogViewModel : BindableBase, IDialogAware
    {
        #region Private property
        private Flight? flight;
        private IRepository repository;
        private int dispatchHours;
        #endregion

        #region Public propert
        /// <inheritdoc/>
        public event Action<IDialogResult>? RequestClose;
        public string Title => "Добавить рейс";
        public Flight Flight { get => flight!; set => SetProperty(ref flight, value); }
        public int DispatchHours { get => dispatchHours; set => SetProperty(ref dispatchHours, value); }

        #endregion

        public AddFlightDialogViewModel(IRepository repository)
        {
            this.repository = repository;
            Flight = new Flight
            {
                Number = 1,
                DepartureTime = DateTime.Now
            };
        }

        #region Commands
        /// <summary>
        /// Add Flight passandeer command
        /// </summary>
        public ICommand CreateFlightCommand => new DelegateCommand<Window>((win)=>
        {
            var fl = new Flight
            {
                Id = new Random().Next(1, 1000),
                Number = Flight.Number,
                DepartureTime = Flight.DepartureTime.Date + new TimeSpan(DispatchHours, 0, 0)
            };

            if (repository.Flights.Where(x => x.Number == fl.Number).Any())
            {
                MessageBox.Show("Рейс с таким номером уже существует", "Airport Passengers", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            repository.Flights.Add(fl);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });

        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand CloseWindowCommand => new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });

        /// <inheritdoc/>
        public bool CanCloseDialog() => true;
        /// <inheritdoc/>
        public void OnDialogClosed() => RequestClose?.Invoke(new DialogResult(ButtonResult.Ignore));
        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters) { }
        #endregion
    }
}
