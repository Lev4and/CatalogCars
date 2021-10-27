using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class PriceSegmentsViewModel
    {
        public Pagination Pagination { get; set; }

        public PriceSegmentsFilters Filters { get; set; }

        public List<PriceSegment> PriceSegments { get; set; }
    }
}
