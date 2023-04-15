using AirportPassengers.Interfaces;
using AirportPassengers.Models;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AirportPassengers.Services
{
    public class Repository : BindableBase, IRepository
    {
        #region Private property
        private ObservableCollection<Flight> flights = new();

        #endregion
        public ObservableCollection<Flight> Flights { get => flights; set => SetProperty(ref flights, value); }

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
                if (openFileDialog.ShowDialog() == true)
                {
                    var file = File.ReadAllText(openFileDialog.FileName);
                    Flights = JsonSerializer.Deserialize<ObservableCollection<Flight>>(file);
                }
                else return;
            }
            catch (Exception)
            {
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
                if (saveFileDialog.ShowDialog() == true)
                {
                    var filePath = saveFileDialog.FileName;
                    await using FileStream createStream = File.Create(filePath);
                    await JsonSerializer.SerializeAsync(createStream, Flights);
                }
                else return;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось сохранить файл", "Airport Passengers", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
