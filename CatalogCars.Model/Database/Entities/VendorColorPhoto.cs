using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class VendorColorPhoto
    {
        public Guid Id { get; set; }

        public Guid VendorColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Full { get; set; }

        public string Orig { get; set; }

        public string Small { get; set; }

        public string Image { get; set; }

        public string ThumbS { get; set; }

        public string ThumbM { get; set; }

        public string AutoMain { get; set; }

        public string ThumbS2x { get; set; }

        public string Cattouch { get; set; }

        public string Wizardv3 { get; set; }

        public string IslandOff { get; set; }

        public string Wizardv3mr { get; set; }

        public string Resolution92x69 { get; set; }

        public string Resolution120x90 { get; set; }

        public string Resolution320x240 { get; set; }

        public string Resolution456x342 { get; set; }

        public string Resolution832x624 { get; set; }

        public string Resolution1200x900 { get; set; }

        public string Resolution1200x900n { get; set; }

        public virtual VendorColor VendorColor { get; set; }
    }
}
