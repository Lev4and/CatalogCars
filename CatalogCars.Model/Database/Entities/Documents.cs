using System;

namespace CatalogCars.Model.Database.Entities
{
    public class Documents
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        public bool? Warranty { get; set; }

        public string LicensePlate { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public DateTime? WarrantyExpire { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual Pts Pts { get; set; }
    }
}
