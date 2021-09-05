using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVehicleInformationRepository : IVehicleInformationRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVehicleInformationRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref VehicleInformation entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [VehicleInformation] (Id, SteeringWheelId, AnnouncementId, GenerationId, VendorId) VALUES " +
                $"('{entity.Id}', '{entity.SteeringWheelId}', '{entity.AnnouncementId}', '{entity.GenerationId}', '{entity.VendorId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
