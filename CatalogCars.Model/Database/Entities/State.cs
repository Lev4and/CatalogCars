using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.Entities
{
    public class State
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        public bool IsBeaten { get; set; }

        public int Mileage { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual ExternalPanorama ExternalPanorama { get; set; }

        public virtual ICollection<StatePhoto> Photos { get; set; }
    }
}
