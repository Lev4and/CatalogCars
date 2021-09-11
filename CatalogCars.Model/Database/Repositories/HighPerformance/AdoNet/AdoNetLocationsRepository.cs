using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetLocationsRepository : ILocationsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetLocationsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(double latitude, double longitude)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Locations INNER JOIN " +
                $"  Coordinates ON Coordinates.LocationId = Locations.Id " +
                $"WHERE Coordinates.Latitude = @Latitude AND Coordinates.Longitude = @Longitude";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Latitude", SqlDbType = SqlDbType.Float, Value = latitude },
                new SqlParameter() { ParameterName = "@Longitude", SqlDbType = SqlDbType.Float, Value = longitude },
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetLocationId(double latitude, double longitude)
        {
            var query = $"SELECT TOP(1) Locations.Id " +
                $"FROM Locations INNER JOIN " +
                $"  Coordinates ON Coordinates.LocationId = Locations.Id " +
                $"WHERE Coordinates.Latitude = @Latitude AND Coordinates.Longitude = @Longitude";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Latitude", SqlDbType = SqlDbType.Float, Value = latitude },
                new SqlParameter() { ParameterName = "@Longitude", SqlDbType = SqlDbType.Float, Value = longitude },
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Location entity)
        {
            if (!Contains(entity.Coordinate.Latitude, entity.Coordinate.Longitude))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Locations] (Id, RegionId, Address, GeobaseId) " +
                    $"VALUES ('{entity.Id}', @RegionId, @Address, @GeobaseId)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@RegionId", SqlDbType = SqlDbType.UniqueIdentifier, Value = entity.RegionId.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Address", SqlDbType = SqlDbType.NVarChar, Value = entity.Address.GetDbValue() },
                    new SqlParameter() { ParameterName = "@GeobaseId", SqlDbType = SqlDbType.NVarChar, Value = entity.GeobaseId },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetLocationId(entity.Coordinate.Latitude, entity.Coordinate.Longitude);
            }

            return true;
        }
    }
}
