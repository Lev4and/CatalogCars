using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Salon
    {
        public Guid Id { get; set; }

        public Guid LocationId { get; set; }

        public bool? IsOfficial { get; set; }

        public bool? ActualStock { get; set; }

        public bool? LoyaltyProgram { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<SalonPhone> Phones { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
