using System;

namespace CatalogCars.Model.Database.Entities
{
    public class Pts
    {
        public Guid Id { get; set; }

        public Guid DocumentsId { get; set; }

        public Guid? PtsTypeId { get; set; }

        public bool IsOriginal { get; set; }

        public bool? CustomCleared { get; set; }

        public bool? NotRegisteredInRussia { get; set; }

        public int? Year { get; set; }

        public int? OwnersNumber { get; set; }

        public virtual Documents Documents { get; set; }

        public virtual PtsType PtsType { get; set; }

        public virtual Vin Vin { get; set; }
    }
}
