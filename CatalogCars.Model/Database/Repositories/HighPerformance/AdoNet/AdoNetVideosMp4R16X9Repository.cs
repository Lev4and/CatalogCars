﻿using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVideosMp4R16X9Repository : IVideosMp4R16X9Repository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVideosMp4R16X9Repository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref VideoMp4R16x9 entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [VideosMp4R16X9] (Id, ExternalPanoramaId, FullUrl, LowResUrl, " +
                $"HighResUrl, PreviewUrl) VALUES ('{entity.Id}', '{entity.ExternalPanoramaId}', @FullUrl, " +
                $"@LowResUrl, @HighResUrl, @PreviewUrl)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@FullUrl", SqlDbType = SqlDbType.NVarChar, Value = entity.FullUrl.GetDbValue() },
                new SqlParameter() { ParameterName = "@LowResUrl", SqlDbType = SqlDbType.NVarChar, Value = entity.LowResUrl.GetDbValue() },
                new SqlParameter() { ParameterName = "@HighResUrl", SqlDbType = SqlDbType.NVarChar, Value = entity.HighResUrl.GetDbValue() },
                new SqlParameter() { ParameterName = "@PreviewUrl", SqlDbType = SqlDbType.NVarChar, Value = entity.PreviewUrl.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
