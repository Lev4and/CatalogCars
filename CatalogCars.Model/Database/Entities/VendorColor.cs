using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class VendorColor
    {
        public Guid Id { get; set; }

        public Guid ComplectationId { get; set; }

        public Guid ColorTypeId { get; set; }

        public bool IsMainColor { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        [Required]
        [MaxLength(6)]
        public string HexCode { get; set; }

        public string HexCodes { get; set; }

        public virtual Complectation Complectation { get; set; }

        public virtual ColorType ColorType { get; set; } 

        public virtual ICollection<VendorColorPhoto> Photos { get; set; }
    }
}
