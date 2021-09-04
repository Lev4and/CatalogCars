using System;

namespace CatalogCars.Model.Database.Entities
{
    public class SellerPhone
    {
        public Guid Id { get; set; }

        public Guid SellerId { get; set; }

        public Guid PhoneId { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual Phone Phone { get; set; }
    }
}
