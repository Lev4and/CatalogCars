using System;

namespace CatalogCars.Model.Database.Entities
{
    public class AnnouncementAdditionalInformation
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Announcement Announcement { get; set; }
    }
}
