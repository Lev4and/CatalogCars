using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class GenerationsViewModel
    {
        public Pagination Pagination { get; set; }

        public GenerationsFilters Filters { get; set; }

        public List<Mark> Marks { get; set; }
        
        public List<Generation> Generations { get; set; }

        public List<PriceSegment> PriceSegments { get; set; }
    }
}
