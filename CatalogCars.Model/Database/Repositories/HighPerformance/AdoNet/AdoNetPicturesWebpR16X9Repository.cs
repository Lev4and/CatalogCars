using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetPicturesWebpR16X9Repository : IPicturesWebpR16X9Repository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetPicturesWebpR16X9Repository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref PictureWebpR16x9 entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [PicturesWebpR16X9] (Id, ExternalPanoramaId, FullFirstFrame, HighResFirstFrame, " +
                $"PreviewFirstFrame) VALUES ('{entity.Id}', '{entity.ExternalPanoramaId}', @FullFirstFrame, " +
                $"@HighResFirstFrame, @PreviewFirstFrame)";

            var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@FullFirstFrame", SqlDbType = SqlDbType.NVarChar, Value = entity.FullFirstFrame.GetDbValue() },
                    new SqlParameter() { ParameterName = "@HighResFirstFrame", SqlDbType = SqlDbType.NVarChar, Value = entity.HighResFirstFrame.GetDbValue() },
                    new SqlParameter() { ParameterName = "@PreviewFirstFrame", SqlDbType = SqlDbType.NVarChar, Value = entity.PreviewFirstFrame.GetDbValue() }
                };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
