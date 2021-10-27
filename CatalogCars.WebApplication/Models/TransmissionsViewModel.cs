using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class TransmissionsViewModel
    {
        public Pagination Pagination { get; set; }

        public TransmissionsFilters Filters { get; set; }

        public List<Transmission> Transmissions { get; set; }
    }
}
