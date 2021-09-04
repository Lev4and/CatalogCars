using System;

namespace CatalogCars.Model.Database.Entities
{
    public class SalonPhone
    {
        public Guid Id { get; set; }

        public Guid SalonId { get; set; }

        public Guid PhoneId { get; set; }

        public virtual Salon Salon { get; set; }

        public virtual Phone Phone { get; set; }
    }
}
