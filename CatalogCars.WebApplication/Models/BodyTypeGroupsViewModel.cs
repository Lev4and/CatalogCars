using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class BodyTypeGroupsViewModel
    {
        public Pagination Pagination { get; set; }

        public BodyTypeGroupsFilters Filters { get; set; }

        public List<BodyTypeGroup> BodyTypeGroups { get; set; }
    }
}
