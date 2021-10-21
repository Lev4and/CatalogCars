using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.WebApplication.Models
{
    public class ModelsViewModel
    {
        public Pagination Pagination { get; set; }

        public ModelsFilters Filters { get; set; }

        public List<Mark> Marks { get; set; }

        public List<Entities.Model> Models { get; set; }
    }
}
