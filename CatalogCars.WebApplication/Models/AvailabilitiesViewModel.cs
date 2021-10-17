using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class AvailabilitiesViewModel
    {
        public Pagination Pagination { get; set; }

        public AvailabilitiesFilters Filters { get; set; }

        public List<Availability> Availabilities { get; set; }
    }
}
