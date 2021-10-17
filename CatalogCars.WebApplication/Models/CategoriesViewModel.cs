using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class CategoriesViewModel
    {
        public Pagination Pagination { get; set; }

        public CategoriesFilters Filters { get; set; }

        public List<Category> Categories { get; set; }
    }
}
