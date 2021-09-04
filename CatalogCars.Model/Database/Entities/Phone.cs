using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Phone
    {
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual ICollection<SellerPhone> Sellers { get; set; }

        public virtual ICollection<SalonPhone> Salons { get; set; }
    }
}
