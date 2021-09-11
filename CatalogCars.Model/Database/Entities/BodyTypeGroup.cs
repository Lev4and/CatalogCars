using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class BodyTypeGroup
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string RuName { get; set; }

        [MaxLength(1)]
        public string AutoClass { get; set; }

        public virtual ICollection<BodyType> BodyTypes { get; set; }
    }
}
