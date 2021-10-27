using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class TagsViewModel
    {
        public Pagination Pagination { get; set; }

        public TagsFilters Filters { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
