using CatalogCars.Model.Database.Entities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CatalogCars.DesktopApplication.Converters
{
    [ValueConversion(typeof(Generation), typeof(string))]
    public class GenerationToTitle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var generation = value as Generation;

            return $"{generation.Model.Mark.Name} {generation.Model.Name}" +
                $"{(!string.IsNullOrEmpty(generation.Name) ? " " + generation.Name : "")}" +
                    $"{(generation.YearFrom != null ? " " + generation.YearFrom : "")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
