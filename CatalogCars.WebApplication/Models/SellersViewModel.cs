using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class SellersViewModel
    {
        public Pagination Pagination { get; set; }

        public SellersFilters Filters { get; set; }

        public List<Seller> Sellers { get; set; }
    }
}
