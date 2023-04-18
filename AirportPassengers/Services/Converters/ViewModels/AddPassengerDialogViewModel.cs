using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System;
using Prism.Services.Dialogs;

namespace AirportPassengers.ViewModels
{
    public class AddPassengerDialogViewModel : BindableBase, IDialogAware
    {
        #region Private propery
        private readonly IRepository repository;
        private Passenger? passenger = new();
        private List<int>? numberFlight = new();
        private bool comboBoxIsEnabled;
        private int selectIndex;
        
        #endregion

        #region Public propery
        /// <inheritdoc/>
        public event Action<IDialogResult>? RequestClose;
        public string Title => "Добавить пассажира";
        public Passenger Passenger { get => passenger!; set => SetProperty(ref passenger, value); }
        public List<int> NumberFlight { get => numberFlight!; set => SetProperty(ref numberFlight, value); }
        public int SelectIndex { get => selectIndex; set => SetProperty(ref selectIndex, value); }
        public bool ComboBoxIsEnabled { get => comboBoxIsEnabled; set => SetProperty(ref comboBoxIsEnabled, value); }

        #endregion

        public AddPassengerDialogViewModel(IRepository repository)
        {
            this.repository = repository;
            foreach (var item in repository.Flights)
                NumberFlight.Add(item.Number);
            if (repository.Flights.Count != 0)
                ComboBoxIsEnabled = true;
        }

        #region Commands
        /// <summary>
        /// Add passandeer command
        /// </summary>
        public ICommand CreatePassenderCommand => new DelegateCommand(() =>
        {
            var pass = new Passenger
            {
                IdPassenger = new Random().Next(1, 1000),
                LastName = Passenger.LastName,
                Name = Passenger.Name,
                MiddleName = Passenger.MiddleName,
                IdFlight = 1
            };

            foreach (var item in repository.Flights)
            {
                if (item.Number == selectIndex)
                {
                    item?.Passengers?.Add(pass);
                }
            }
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });

        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand CloseWindowCommand => new DelegateCommand<Window>((win) =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        });

        public bool CanCloseDialog() => true;
        /// <inheritdoc/>
        public void OnDialogClosed() => RequestClose?.Invoke(new DialogResult(ButtonResult.Ignore));

        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters) 
        {
            if(parameters.ContainsKey("passenger"))
            {
                var pas = parameters.GetValue<Passenger>("passenger");
                Passenger = new Passenger
                {
                    IdPassenger = new Random().Next(1, 1000),
                    IdFlight = SelectIndex,
                    LastName = pas.LastName,
                    MiddleName = pas.MiddleName,
                    Name = pas.Name
                };
            }

        }
        #endregion

    }
}
