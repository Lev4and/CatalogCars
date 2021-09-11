using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVinsRepository : IVinsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVinsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Vin entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Vins] (Id, PtsId, ResolutionId, Value) VALUES ('{entity.Id}', '{entity.PtsId}', " +
                $"@ResolutionId, @Value)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@ResolutionId", SqlDbType = SqlDbType.UniqueIdentifier, Value = entity.ResolutionId.GetDbValue() },
                new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.NVarChar, Value = entity.Value.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
