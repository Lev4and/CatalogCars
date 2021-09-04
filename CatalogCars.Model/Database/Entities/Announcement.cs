using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Announcement
    {
        public Guid Id { get; set; }

        public Guid ColorId { get; set; }

        public Guid SalonId { get; set; }

        public Guid SellerId { get; set; }

        public Guid StatusId { get; set; }

        public Guid SectionId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SellerTypeId { get; set; }

        public Guid AvailabilityId { get; set; }

        [Required]
        public string SaleId { get; set; }

        [Required]
        public string Summary { get; set; }

        public virtual State State { get; set; }

        public virtual Color Color { get; set; }

        public virtual Salon Salon { get; set; }

        public virtual Price Price { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual Status Status { get; set; }

        public virtual Section Section { get; set; }

        public virtual Category Category { get; set; }

        public virtual Documents Documents { get; set; }

        public virtual SellerType SellerType { get; set; }

        public virtual Availability Availability { get; set; }

        public virtual VehicleInformation Vehicle { get; set; }

        public virtual AnnouncementDescription Description { get; set; }

        public virtual AnnouncementAdditionalInformation AdditionalInformation { get; set; }

        public virtual ICollection<AnnouncementTag> Tags { get; set; }
    }
}
