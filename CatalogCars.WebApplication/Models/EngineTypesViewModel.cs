using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class EngineTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public EngineTypesFilters Filters { get; set; }

        public List<EngineType> EngineTypes { get; set; }
    }
}
