using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class VinResolutionsViewModel
    {
        public Pagination Pagination { get; set; }

        public VinResolutionsFilters Filters { get; set; }

        public List<VinResolution> VinResolutions { get; set; }
    }
}
