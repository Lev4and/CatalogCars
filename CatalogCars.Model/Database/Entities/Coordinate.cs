using System;

namespace CatalogCars.Model.Database.Entities
{
    public class Coordinate
    {
        public Guid Id { get; set; }

        public Guid LocationId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual Location Location { get; set; }
    }
}
