using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class CurrenciesViewModel
    {
        public Pagination Pagination { get; set; }

        public CurrenciesFilters Filters { get; set; }

        public List<Currency> Currencies { get; set; }
    }
}
