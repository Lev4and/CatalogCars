using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Model
    {
        public Guid Id { get; set; }

        public Guid MarkId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string RuName { get; set; }

        public virtual Mark Mark { get; set; }

        public virtual ICollection<Generation> Generations { get; set; }
    }
}
