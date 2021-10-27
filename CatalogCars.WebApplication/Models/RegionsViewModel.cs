using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class RegionsViewModel
    {
        public Pagination Pagination { get; set; }

        public RegionsFilters Filters { get; set; }

        public List<RegionInformation> Regions { get; set; }
    }
}
