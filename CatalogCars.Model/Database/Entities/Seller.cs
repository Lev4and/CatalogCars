using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.Entities
{
    public class Seller
    {
        public Guid Id { get; set; }

        public Guid LocationId { get; set; }

        public string Name { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<SellerPhone> Phones { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
