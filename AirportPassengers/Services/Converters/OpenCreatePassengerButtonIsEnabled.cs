using System;
using System.Globalization;
using System.Windows.Data;

namespace AirportPassengers.Services.Converters
{
    public class OpenCreatePassengerButtonIsEnabled : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            if (count != 0)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
