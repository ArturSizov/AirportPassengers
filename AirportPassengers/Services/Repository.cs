using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AirportPassengers.Services
{
    public class Repository : BindableBase, IRepository
    {
        #region Private property
        private readonly ILogger logger;
        private ObservableCollection<Flight> flights = new();
        #endregion
        public ObservableCollection<Flight> Flights { get => flights; set => SetProperty(ref flights, value); }

        public Repository(ILogger<Repository> logger)
        {
            this.logger = logger;
        }

        #region Methods
        /// <summary>
        /// Download from json file
        /// </summary>
        public void LoadingFromFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json|*.json";

            try
            {
                if ((bool)!openFileDialog.ShowDialog()!)
                    return;

                    var file = File.ReadAllText(openFileDialog.FileName);
                    var flights = JsonSerializer.Deserialize<ObservableCollection<Flight>>(file)!;

                    foreach (var item in flights)
                    {
                        if(!Flights.Where(x => x.Id == item.Id).Any())
                            Flights.Add(item);
                    }

                    logger.LogInformation($"Loaded from file: {openFileDialog.FileName}");
            }
            catch (Exception)
            {
                logger.LogInformation($"Failed to load from file");
                MessageBox.Show("Не ужалось прочитать файл", "Airport Passengers", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Save file
        /// </summary>
        public async Task SaveFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json|.json";
            saveFileDialog.RestoreDirectory = true;

            try
            {
                if ((bool)!saveFileDialog.ShowDialog()!)
                    return;
                
                    var filePath = saveFileDialog.FileName;
                    await using FileStream createStream = File.Create(filePath);
                    await JsonSerializer.SerializeAsync(createStream, Flights);
                logger.LogInformation($"Save file: {filePath}");

            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить файл", "Airport Passengers", MessageBoxButton.OK, MessageBoxImage.Error);
                logger.LogInformation($"Failed to save file");
            }
        }

        /// <summary>
        /// Passenger Creation Method
        /// </summary>
        /// <param name="passenger"></param>
        public void CreatePassender(Passenger passenger)
        {
            var pas = new Passenger
            {
                IdPassenger = new Random().Next(1, 1000),
                LastName = passenger.LastName,
                Name = passenger.Name,
                MiddleName = passenger.MiddleName,
                FlightNumber = passenger.FlightNumber
            };

            foreach (var item in Flights)
            {
                if (item.FlightNumber == pas.FlightNumber)
                    item?.Passengers?.Add(pas);
            }

            logger.LogInformation("New passenger created");
        }
        /// <summary>
        /// Flight Creation Method
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public bool CreateFlight(Flight flight)
        {
            var fl = new Flight
            {
                Id = new Random().Next(1, 1000),
                FlightNumber = flight.FlightNumber,
                DepartureTime = flight.DepartureTime.Date + new TimeSpan(flight.DispatchHours, 0, 0),
                DispatchHours = flight.DispatchHours, 
                Passengers = flight.Passengers
            };

            if (fl.DepartureTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время не могут быть в прошедшем времени", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            Flights.Add(fl);

            logger.LogInformation("New flight created");

            return true;
        }
        #endregion
    }
}
