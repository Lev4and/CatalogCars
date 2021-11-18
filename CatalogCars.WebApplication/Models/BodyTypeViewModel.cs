using CatalogCars.Model.Database.Entities;
using System.Collections.Generic;

namespace CatalogCars.WebApplication.Models
{
    public class BodyTypeViewModel
    {
        public BodyType BodyType { get; set; }

        public List<BodyTypeGroup> BodyTypeGroups { get; set; }
    }
}
