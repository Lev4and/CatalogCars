using CatalogCars.Model.Converters.AutoRu;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CatalogCars.DesktopApplication.Converters
{
    [ValueConversion(typeof(Vehicle), typeof(string))]
    public class VehicleToTitle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vehicle = value as Vehicle;

            return $"{vehicle.Mark.Name} {vehicle.Model.Name}" +
                $"{(vehicle.Generation != null ? (!string.IsNullOrEmpty(vehicle.Generation.Name) ? " " + vehicle.Generation.Name : "") : "")}" +
                    $"{(vehicle.Generation != null ? (vehicle.Generation.YearFrom != null ? " " + vehicle.Generation.YearFrom : "") : "")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
