using System;
using System.Globalization;
using System.Windows.Data;

namespace CatalogCars.DesktopApplication.Converters
{
    [ValueConversion(typeof(int), typeof(bool))]
    public class ClearanceMinToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
