using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.Entities
{
    public class Configuration
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public Guid BodyTypeId { get; set; }

        public int DoorsCount { get; set; }

        public double? TrunkVolumeMin { get; set; }

        public double? TrunkVolumeMax { get; set; }

        public virtual VehicleInformation Vehicle { get; set; }

        public virtual VehicleMainPhoto MainPhoto { get; set; }

        public virtual BodyType BodyType { get; set; }

        public virtual ICollection<ConfigurationTag> Tags { get; set; }
    }
}
