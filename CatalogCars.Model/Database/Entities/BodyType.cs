using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class BodyType
    {
        public Guid Id { get; set; }

        public Guid BodyTypeGroupId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        public virtual BodyTypeGroup BodyTypeGroup { get; set; }

        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}
