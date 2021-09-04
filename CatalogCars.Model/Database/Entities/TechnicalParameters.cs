using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class TechnicalParameters
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public Guid GearTypeId { get; set; }

        public Guid EngineTypeId { get; set; }

        public Guid TransmissionId { get; set; }

        public int Power { get; set; }

        public int PowerKvt { get; set; }

        public int Displacement { get; set; }

        public int ClearanceMin { get; set; }

        public double? FuelRate { get; set; }

        public double Acceleration { get; set; }

        public string Name { get; set; }

        [Required]
        public string HumanName { get; set; }

        public string Nameplate { get; set; }

        public virtual GearType GearType { get; set; }

        public virtual EngineType EngineType { get; set; }

        public virtual Transmission Transmission { get; set; }

        public virtual VehicleInformation Vehicle { get; set; }
    }
}
