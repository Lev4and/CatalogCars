using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class SellerTypesViewModel
    {
        public Pagination Pagination { get; set; }

        public SellerTypesFilters Filters { get; set; }

        public List<SellerType> SellerTypes { get; set; }
    }
}
