using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetSalonPhonesRepository : ISalonPhonesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetSalonPhonesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid salonId, Guid phoneId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM SalonPhones " +
                $"WHERE SalonPhones.SalonId = '{salonId}' AND SalonPhones.PhoneId = " +
                $"'{phoneId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public bool Save(ref SalonPhone entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [SalonPhones] (Id, SalonId, PhoneId) VALUES ('{entity.Id}', " +
                $"'{entity.SalonId}', '{entity.PhoneId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
