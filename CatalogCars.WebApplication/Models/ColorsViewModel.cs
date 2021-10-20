using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class ColorsViewModel
    {
        public Pagination Pagination { get; set; }

        public ColorsFilters Filters { get; set; }

        public List<Color> Colors { get; set; }
    }
}
