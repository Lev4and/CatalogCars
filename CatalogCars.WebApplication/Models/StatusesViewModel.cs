using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class StatusesViewModel
    {
        public Pagination Pagination { get; set; }

        public StatusesFilters Filters { get; set; }

        public List<Status> Statuses { get; set; }
    }
}
