using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using System.Collections.Generic;
using System;
using Prism.Services.Dialogs;
using System.Linq;

namespace AirportPassengers.ViewModels
{
    public class AddPassengerDialogViewModel : BindableBase, IDialogAware
    {
        #region Private propery
        private readonly IRepository repository;
        private Passenger? passenger = new();
        private List<int>? numberFlight = new();
        
        #endregion

        #region Public propery

        public string Title => "Ввод данных";
        public Passenger Passenger { get => passenger!; set => SetProperty(ref passenger, value); }
        public List<int> NumberFlight { get => numberFlight!; set => SetProperty(ref numberFlight, value); }
        //public int SelectIndex { get => selectIndex; set => SetProperty(ref selectIndex, value); }

        #endregion

        public AddPassengerDialogViewModel(IRepository repository)
        {
            this.repository = repository;
            foreach (var item in repository.Flights)
                NumberFlight.Add(item.FlightNumber);
        }

        #region Commands
        /// <summary>
        /// Add passandeer command
        /// </summary>
        public ICommand CreatePassenderCommand => new DelegateCommand(() =>
        {
            repository.CreatePassender(Passenger);

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
        public bool CanCloseDialog() => true;
        /// <inheritdoc/>
        public void OnDialogClosed() => RequestClose?.Invoke(new DialogResult(ButtonResult.Ignore));

        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("passenger"))
            {
                var pas = parameters.GetValue<Passenger>("passenger");

                Passenger = new Passenger
                {
                    IdPassenger = new Random().Next(1, 1000),
                    FlightNumber = pas.FlightNumber,
                    LastName = pas.LastName,
                    MiddleName = pas.MiddleName,
                    Name = pas.Name
                };
            }

        }
        #endregion
    }
}
