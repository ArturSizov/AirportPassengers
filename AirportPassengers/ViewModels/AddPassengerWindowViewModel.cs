using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using System.Windows;

namespace AirportPassengers.ViewModels
{
    public class AddPassengerWindowViewModel : BindableBase
    {
        #region Private propery
        private readonly IRepository repository;
        private Passenger? passenger;

        #endregion
        #region Public propery
        public string Title => "Добавить пассажира";
        public Passenger Passenger { get => passenger!; set => SetProperty(ref passenger, value); }

        #endregion
        public AddPassengerWindowViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        #region Commands
        /// <summary>
        /// Add passandeer command
        /// </summary>
        public ICommand AddPassndeer => new DelegateCommand<Window>((win) =>
        {
            var pass = new Passenger
            {
                
            };

            //if (repository.Flights.Count != 0)
            //{
            //    foreach (var item in repository.Flights)
            //    {
            //        if (item.Number != fl.Number)
            //            repository.Flights.Add(fl);
            //    }
            //}
            //else repository.Flights.Add(fl);

            win.Close();
        });

        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand Close => new DelegateCommand<Window>((win) =>
        {
            win.Close();
        });

        #endregion

    }
}
