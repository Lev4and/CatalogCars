using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class LocationsViewModel
    {
        public Pagination Pagination { get; set; }

        public LocationsFilters Filters { get; set; }

        public List<Location> Locations { get; set; }
    }
}
