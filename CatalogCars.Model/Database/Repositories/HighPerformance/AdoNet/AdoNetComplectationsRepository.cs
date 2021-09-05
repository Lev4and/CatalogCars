using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetComplectationsRepository : IComplectationsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetComplectationsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Complectation entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Complectations] (Id, VehicleId, Name, RuName) VALUES ('{entity.Id}', " +
                $"'{entity.VehicleId}', @Name, @RuName)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
