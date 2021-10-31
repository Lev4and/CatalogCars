using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CatalogCars.DesktopApplication.Converters
{
    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class HexNumberToSolidColorBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorcode = $"FF{System.Convert.ToString(value)}";

            var a = byte.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber);
            var r = byte.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber);
            var g = byte.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber);
            var b = byte.Parse(colorcode.Substring(6, 2), NumberStyles.HexNumber);

            return new SolidColorBrush(Color.FromArgb(a, r, g, b));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
