using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.Entities
{
    public class Location
    {
        public Guid Id { get; set; }

        public Guid? RegionId { get; set; }

        public string Address { get; set; }

        public string GeobaseId { get; set; }

        public virtual Coordinate Coordinate { get; set; }

        public virtual RegionInformation Region { get; set; }

        public virtual ICollection<Salon> Salons { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
