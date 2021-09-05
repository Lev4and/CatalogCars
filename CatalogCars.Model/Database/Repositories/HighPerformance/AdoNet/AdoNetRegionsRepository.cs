using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetRegionsRepository : IRegionsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetRegionsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string stringId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Regions " +
                $"WHERE Regions.StringId = @StringId";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@StringId", SqlDbType = SqlDbType.NVarChar, Value = stringId }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetRegionId(string stringId)
        {
            var query = $"SELECT TOP(1) Regions.Id " +
                $"FROM Regions " +
                $"WHERE Regions.StringId = @StringId";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@StringId", SqlDbType = SqlDbType.NVarChar, Value = stringId }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref RegionInformation entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Regions] (Id, Name, Dative, Genitive, StringId, Accusative, ParentIds, Preposition, " +
                    $"Prepositional, Latitude, Longitude) VALUES ('{entity.Id}', @Name, @Dative, @Genitive, @StringId, " +
                    $"@Accusative, @ParentIds, @Preposition, @Prepositional, @Latitude, @Longitude)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Dative", SqlDbType = SqlDbType.NVarChar, Value = entity.Dative.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Genitive", SqlDbType = SqlDbType.NVarChar, Value = entity.Genitive.GetDbValue() },
                    new SqlParameter() { ParameterName = "@StringId", SqlDbType = SqlDbType.NVarChar, Value = entity.StringId.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Accusative", SqlDbType = SqlDbType.NVarChar, Value = entity.Accusative.GetDbValue() },
                    new SqlParameter() { ParameterName = "@ParentIds", SqlDbType = SqlDbType.NVarChar, Value = entity.ParentIds.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Preposition", SqlDbType = SqlDbType.NVarChar, Value = entity.Preposition.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Prepositional", SqlDbType = SqlDbType.NVarChar, Value = entity.Prepositional.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Latitude", SqlDbType = SqlDbType.Float, Value = entity.Latitude },
                    new SqlParameter() { ParameterName = "@Longitude", SqlDbType = SqlDbType.Float, Value = entity.Longitude },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetRegionId(entity.StringId);
            }

            return true;
        }
    }
}
