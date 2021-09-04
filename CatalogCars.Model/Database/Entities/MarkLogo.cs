using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class MarkLogo
    {
        public Guid Id { get; set; }

        public Guid MarkId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RuName { get; set; }

        public string Logo { get; set; }

        public string BigLogo { get; set; }

        public string BlackLogo { get; set; }

        public virtual Mark Mark { get; set; }
    }
}
