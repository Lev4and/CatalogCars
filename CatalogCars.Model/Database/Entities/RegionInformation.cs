using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.Entities
{
    public class RegionInformation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Dative { get; set; }

        public string Genitive { get; set; }

        public string StringId { get; set; }

        public string Accusative { get; set; }

        public string ParentIds { get; set; }

        public string Preposition { get; set; }

        public string Prepositional { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
