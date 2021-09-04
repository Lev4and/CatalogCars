using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Complectation
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        public virtual VehicleInformation Vehicle { get; set; }

        public virtual ICollection<VendorColor> VendorColors { get; set; }

        public virtual ICollection<ComplectationOption> Options { get; set; }
    }
}
