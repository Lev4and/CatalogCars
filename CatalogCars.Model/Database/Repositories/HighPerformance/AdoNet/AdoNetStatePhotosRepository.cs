using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetStatePhotosRepository : IStatePhotosRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetStatePhotosRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref StatePhoto entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [StatePhotos] (Id, StateId, ClassId, Small, ThumbM, Preview, Resolution320x240, " +
                $"Resolution456x342, Resolution456x342n, Resolution1200x900, Resolution1200x900n) VALUES ('{entity.Id}', " +
                $"'{entity.StateId}', '{entity.ClassId}', @Small, @ThumbM, @Preview, @Resolution320x240, @Resolution456x342, " +
                $"@Resolution456x342n, @Resolution1200x900, @Resolution1200x900n)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Small", SqlDbType = SqlDbType.NVarChar, Value = entity.Small.GetDbValue() },
                new SqlParameter() { ParameterName = "@ThumbM", SqlDbType = SqlDbType.NVarChar, Value = entity.ThumbM.GetDbValue() },
                new SqlParameter() { ParameterName = "@Preview", SqlDbType = SqlDbType.NVarChar, Value = entity.Preview.GetDbValue() },
                new SqlParameter() { ParameterName = "@Resolution320x240", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution320x240.GetDbValue() },
                new SqlParameter() { ParameterName = "@Resolution456x342", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution456x342.GetDbValue() },
                new SqlParameter() { ParameterName = "@Resolution456x342n", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution456x342n.GetDbValue() },
                new SqlParameter() { ParameterName = "@Resolution1200x900", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution1200x900.GetDbValue() },
                new SqlParameter() { ParameterName = "@Resolution1200x900n", SqlDbType = SqlDbType.NVarChar, Value = entity.Resolution1200x900n.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
