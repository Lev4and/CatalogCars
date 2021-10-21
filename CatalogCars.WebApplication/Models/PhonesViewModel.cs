using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class PhonesViewModel
    {
        public Pagination Pagination { get; set; }

        public PhonesFilters Filters { get; set; }

        public List<Phone> Phones { get; set; }
    }
}
