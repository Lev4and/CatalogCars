using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class ColorTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public ColorTypesFilters Filters { get; set; }

        public List<ColorType> ColorTypes { get; set; }
    }
}
