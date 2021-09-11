using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Vin
    {
        public Guid Id { get; set; }

        public Guid PtsId { get; set; }

        public Guid? ResolutionId { get; set; }

        public string Value { get; set; }

        public virtual Pts Pts { get; set; }

        public virtual VinResolution Resolution { get; set; }
    }
}
