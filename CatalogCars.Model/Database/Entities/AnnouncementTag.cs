using System;

namespace CatalogCars.Model.Database.Entities
{
    public class AnnouncementTag
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        public Guid TagId { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
