using System;

namespace CatalogCars.Model.Database.Entities
{
    public class ComplectationOption
    {
        public Guid Id { get; set; }

        public Guid ComplectationId { get; set; }

        public Guid OptionId { get; set; }

        public virtual Complectation Complectation { get; set; }

        public virtual Option Option { get; set; }
    }
}
