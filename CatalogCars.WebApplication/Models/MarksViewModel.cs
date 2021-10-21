using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class MarksViewModel
    {
        public Pagination Pagination { get; set; }

        public MarksFilters Filters { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
