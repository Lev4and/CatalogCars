using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class AnnouncementDescription
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual Announcement Announcement { get; set; }
    }
}
