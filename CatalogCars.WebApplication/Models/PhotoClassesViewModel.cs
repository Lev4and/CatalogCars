using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class PhotoClassesViewModel
    {
        public Pagination Pagination { get; set; }

        public PhotoClassesFilters Filters { get; set; }

        public List<PhotoClass> PhotoClasses { get; set; }
    }
}
