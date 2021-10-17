using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class BodyTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public BodyTypesFilters Filters { get; set; }

        public List<BodyType> BodyTypes { get; set; }

        public List<BodyTypeGroup> BodyTypeGroups { get; set; }
    }
}
