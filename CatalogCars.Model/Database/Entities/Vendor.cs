﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Vendor
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        public virtual ICollection<VehicleInformation> Vehicles { get; set; }
    }
}
