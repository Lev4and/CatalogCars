using System;

namespace CatalogCars.Model.Database.Entities
{
    public class VehicleInformation
    {
        public Guid Id { get; set; }

        public Guid SteeringWheelId { get; set; }

        public Guid AnnouncementId { get; set; }

        public Guid GenerationId { get; set; }

        public Guid VendorId { get; set; }

        public virtual TechnicalParameters TechnicalParameters { get; set; }

        public virtual SteeringWheel SteeringWheel { get; set; }

        public virtual Configuration Configuration { get; set; }

        public virtual Complectation Complectation { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual Generation Generation { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
