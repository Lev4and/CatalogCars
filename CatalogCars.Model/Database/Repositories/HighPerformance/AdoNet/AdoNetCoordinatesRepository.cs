using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetCoordinatesRepository : ICoordinatesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetCoordinatesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Coordinate entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Coordinates] (Id, LocationId, Latitude, Longitude) " +
                $"VALUES ('{entity.Id}', '{entity.LocationId}', @Latitude, @Longitude)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Latitude", SqlDbType = SqlDbType.Float, Value = entity.Latitude },
                new SqlParameter() { ParameterName = "@Longitude", SqlDbType = SqlDbType.Float, Value = entity.Longitude }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
