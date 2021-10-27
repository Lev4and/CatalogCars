using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class SectionsViewModel
    {
        public Pagination Pagination { get; set; }

        public SectionsFilters Filters { get; set; }

        public List<Section> Sections { get; set; }
    }
}
