using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Color
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(6)]
        public string Value { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
