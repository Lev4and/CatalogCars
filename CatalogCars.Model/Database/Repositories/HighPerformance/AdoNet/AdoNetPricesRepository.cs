using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetPricesRepository : IPricesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetPricesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Price entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Prices] (Id, AnnouncementId, CurrencyId, WithNds, Value) " +
                $"VALUES ('{entity.Id}', '{entity.AnnouncementId}', '{entity.CurrencyId}', @WithNds, @Value)";

            var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@WithNds", SqlDbType = SqlDbType.Bit, Value = entity.WithNds },
                    new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.Float, Value = entity.Value }
                };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
