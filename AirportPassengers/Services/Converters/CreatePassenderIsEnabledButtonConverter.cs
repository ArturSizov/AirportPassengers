using System;
using System.Globalization;
using System.Windows.Data;

namespace AirportPassengers.Services.Converters
{
    public class CreatePassenderIsEnabledButtonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                var name = values[0] as string;
                var lastName = values[1] as string;
                var selectIndex = (int)values[2];

                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(lastName) && selectIndex != 0)
                    return true;
                else return false;
            }
            else return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
