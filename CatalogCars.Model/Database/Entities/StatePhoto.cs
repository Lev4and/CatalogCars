using System;

namespace CatalogCars.Model.Database.Entities
{
    public class StatePhoto
    {
        public Guid Id { get; set; }

        public Guid StateId { get; set; }

        public Guid ClassId { get; set; }

        public string Small { get; set; }

        public string ThumbM { get; set; }

        public string Preview { get; set; }

        public string Resolution320x240 { get; set; }

        public string Resolution456x342 { get; set; }

        public string Resolution456x342n { get; set; }

        public string Resolution1200x900 { get; set; }

        public string Resolution1200x900n { get; set; }

        public virtual State State { get; set; }

        public virtual PhotoClass Class { get; set; }
    }
}
