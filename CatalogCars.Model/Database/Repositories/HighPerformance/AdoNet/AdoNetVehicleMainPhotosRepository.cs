using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVehicleMainPhotosRepository : IVehicleMainPhotosRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVehicleMainPhotosRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref VehicleMainPhoto entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [VehicleMainPhotos] (Id, ConfigurationId, Original, Cattouch, Wizardv3mr) VALUES " +
                $"('{entity.Id}', '{entity.ConfigurationId}', @Original, @Cattouch, @Wizardv3mr)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Original", SqlDbType = SqlDbType.NVarChar, Value = entity.Original.GetDbValue() },
                new SqlParameter() { ParameterName = "@Cattouch", SqlDbType = SqlDbType.NVarChar, Value = entity.Cattouch.GetDbValue() },
                new SqlParameter() { ParameterName = "@Wizardv3mr", SqlDbType = SqlDbType.NVarChar, Value = entity.Wizardv3mr.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
