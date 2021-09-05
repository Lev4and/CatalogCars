using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetExternalPanoramasRepository : IExternalPanoramasRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetExternalPanoramasRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref ExternalPanorama entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [ExternalPanoramas] (Id, StateId, Preview, QualityR4x3, QualityR16x9) " +
                $"VALUES ('{entity.Id}', '{entity.StateId}', @Preview, @QualityR4x3, @QualityR16x9)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Preview", SqlDbType = SqlDbType.NVarChar, Value = entity.Preview.GetDbValue() },
                new SqlParameter() { ParameterName = "@QualityR4x3", SqlDbType = SqlDbType.Float, Value = entity.QualityR4x3 },
                new SqlParameter() { ParameterName = "@QualityR16x9", SqlDbType = SqlDbType.Float, Value = entity.QualityR16x9 }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
