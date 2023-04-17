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
        private int selectIndex;


        #endregion
        #region Public propery
        /// <inheritdoc/>
        public event Action<IDialogResult>? RequestClose;
        public string Title => "Добавить пассажира";
        public Passenger Passenger { get => passenger!; set => SetProperty(ref passenger, value); }
        public List<int> NumberFlight { get => numberFlight!; set => SetProperty(ref numberFlight, value); }
        public int SelectIndex { get => selectIndex; set => SetProperty(ref selectIndex, value); }
        #endregion

        public AddPassengerDialogViewModel(IRepository repository)
        {
            this.repository = repository;
            foreach (var item in repository.Flights)
                NumberFlight.Add(item.Number);
        }

        #region Commands
        /// <summary>
        /// Add passandeer command
        /// </summary>
        public ICommand CreatePassenderCommand => new DelegateCommand<Window>((win) =>
        {
            var pass = new Passenger
            {
                IdPassenger = new Random().Next(1, 1000),
                LastName = Passenger.LastName,
                Name = Passenger.Name,
                MiddleName = Passenger.MiddleName,
                IdFlight = selectIndex
            };

            foreach (var item in repository.Flights)
            {
                if(item.Number == selectIndex)
                {
                    item.Passengers.Add(pass);
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
        public void OnDialogOpened(IDialogParameters parameters) { }
       
        #endregion

    }
}
