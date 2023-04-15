using AirportPassengers.Interfaces;
using AirportPassengers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirportPassengers.Views
{
    /// <summary>
    /// Логика взаимодействия для AddFlightWindow.xaml
    /// </summary>
    public partial class AddFlightWindow : Window
    {
        public AddFlightWindow(IRepository repository)
        {
            InitializeComponent();
            DataContext = new AddFlightWindowViewModel(repository);
        }
    }
}
