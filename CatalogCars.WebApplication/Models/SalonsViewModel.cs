using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class SalonsViewModel
    {
        public Pagination Pagination { get; set; }

        public SalonsFilters Filters { get; set; }

        public List<Salon> Salons { get; set; }
    }
}
