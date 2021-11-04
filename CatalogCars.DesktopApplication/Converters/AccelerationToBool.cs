using System;
using System.Globalization;
using System.Windows.Data;

namespace CatalogCars.DesktopApplication.Converters
{
    [ValueConversion(typeof(double), typeof(bool))]
    public class AccelerationToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
