using System;

namespace CatalogCars.Model.Database.Entities
{
    public class ConfigurationTag
    {
        public Guid Id { get; set; }

        public Guid ConfigurationId { get; set; }

        public Guid TagId { get; set; }

        public virtual Configuration Configuration { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
