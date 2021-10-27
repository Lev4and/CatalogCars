using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class SteeringWheelsViewModel
    {
        public Pagination Pagination { get; set; }

        public SteeringWheelsFilters Filters { get; set; }

        public List<SteeringWheel> SteeringWheels { get; set; }
    }
}
