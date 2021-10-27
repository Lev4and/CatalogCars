using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class VendorsViewModel
    {
        public Pagination Pagination { get; set; }

        public VendorsFilters Filters { get; set; }

        public List<Vendor> Vendors { get; set; }
    }
}
