using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class CoordinatesViewModel
    {
        public Pagination Pagination { get; set; }

        public CoordinatesFilters Filters { get; set; }

        public List<Coordinate> Coordinates { get; set; }
    }
}
