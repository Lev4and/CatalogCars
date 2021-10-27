using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class PtsTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public PtsTypesFilters Filters { get; set; }

        public List<PtsType> PtsTypes { get; set; }
    }
}
