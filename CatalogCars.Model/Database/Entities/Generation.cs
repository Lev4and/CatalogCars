using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Generation
    {
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        public Guid PriceSegmentId { get; set; }

        public int YearFrom { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        public virtual Model Model { get; set; }

        public virtual PriceSegment PriceSegment { get; set; }

        public virtual ICollection<VehicleInformation> Vehicles { get; set; }
    }
}
