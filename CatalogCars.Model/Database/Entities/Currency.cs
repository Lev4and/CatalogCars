using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Designation { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}
