using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class GearTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public GearTypesFilters Filters { get; set; }

        public List<GearType> GearTypes { get; set; }
    }
}
