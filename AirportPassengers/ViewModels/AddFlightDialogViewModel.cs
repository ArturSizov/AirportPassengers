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
        #endregion

        #region Public propert
        public string Title => "Ввод данных";
        public Flight Flight { get => flight!; set => SetProperty(ref flight, value); }

        #endregion

        public AddFlightDialogViewModel(IRepository repository)
        {
            this.repository = repository;
            Flight = new Flight
            {
                FlightNumber = 1,
                DepartureTime = DateTime.Now
            };
        }

        #region Commands
        /// <summary>
        /// Add Flight passandeer command
        /// </summary>
        public ICommand CreateFlightCommand => new DelegateCommand(()=>
        {
            if(repository.CreateFlight(Flight))
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });

        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand CloseDialogCommand => new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        });
        #endregion

        #region Inheritdoc
        /// <inheritdoc/>
        public event Action<IDialogResult>? RequestClose;
        /// <inheritdoc/>
        public bool CanCloseDialog() => true;
        /// <inheritdoc/>
        public void OnDialogClosed() => RequestClose?.Invoke(new DialogResult(ButtonResult.Ignore));
        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("flight"))
            {
                var fl = parameters.GetValue<Flight>("flight");

                Flight = new Flight
                {
                    Id = fl.Id,
                    DepartureTime = fl.DepartureTime,
                    FlightNumber = fl.FlightNumber,
                    DispatchHours = fl.DispatchHours,
                    Passengers = fl.Passengers
                };
            }
        }
        #endregion
    }
}
