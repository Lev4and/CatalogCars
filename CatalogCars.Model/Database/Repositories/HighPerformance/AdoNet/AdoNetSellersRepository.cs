using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetSellersRepository : ISellersRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetSellersRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid locationId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Sellers " +
                $"WHERE Sellers.LocationId = '{locationId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public Guid GetSellerId(Guid locationId)
        {
            var query = $"SELECT TOP(1) Sellers.Id " +
                $"FROM Sellers " +
                $"WHERE Sellers.LocationId = '{locationId}'";

            return _context.ExecuteQuery(query).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Seller entity)
        {
            if (!Contains(entity.LocationId))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Sellers] (Id, LocationId) VALUES ('{entity.Id}', '{entity.LocationId}')";

                _context.ExecuteQuery(query);
            }
            else
            {
                entity.Id = GetSellerId(entity.LocationId);
            }

            return true;
        }
    }
}
