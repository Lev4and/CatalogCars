using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class OptionsViewModel
    {
        public Pagination Pagination { get; set; }

        public OptionsFilters Filters { get; set; }

        public List<Option> Options { get; set; }
    }
}
