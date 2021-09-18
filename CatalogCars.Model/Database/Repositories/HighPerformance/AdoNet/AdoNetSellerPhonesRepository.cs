using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetSellerPhonesRepository : ISellerPhonesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetSellerPhonesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid sellerId, Guid phoneId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM SellerPhones " +
                $"WHERE SellerPhones.SellerId = '{sellerId}' AND SellerPhones.PhoneId = " +
                $"'{phoneId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public bool Save(ref SellerPhone entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [SellerPhones] (Id, SellerId, PhoneId) VALUES ('{entity.Id}', " +
                $"'{entity.SellerId}', '{entity.PhoneId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
