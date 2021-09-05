using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetConfigurationsRepository : IConfigurationsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetConfigurationsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Configuration entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Configurations] (Id, VehicleId, BodyTypeId, DoorsCount, TrunkVolumeMin, TrunkVolumeMax) " +
                $"VALUES ('{entity.Id}', '{entity.VehicleId}', '{entity.BodyTypeId}', @DoorsCount, @TrunkVolumeMin, " +
                $"@TrunkVolumeMax)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@DoorsCount", SqlDbType = SqlDbType.Int, Value = entity.DoorsCount },
                new SqlParameter() { ParameterName = "@TrunkVolumeMin", SqlDbType = SqlDbType.Float, Value = entity.TrunkVolumeMin },
                new SqlParameter() { ParameterName = "@TrunkVolumeMax", SqlDbType = SqlDbType.Float, Value = entity.TrunkVolumeMax.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
