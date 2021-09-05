using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetMarkLogosRepository : IMarkLogosRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetMarkLogosRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref MarkLogo entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [MarkLogos] (Id, MarkId, Name, RuName, Logo, BigLogo, BlackLogo) " +
                $"VALUES ('{entity.Id}', '{entity.MarkId}', @Name, @RuName, @Logo, @BigLogo, @BlackLogo)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
                new SqlParameter() { ParameterName = "@Logo", SqlDbType = SqlDbType.NVarChar, Value = entity.Logo.GetDbValue() },
                new SqlParameter() { ParameterName = "@BigLogo", SqlDbType = SqlDbType.NVarChar, Value = entity.BigLogo.GetDbValue() },
                new SqlParameter() { ParameterName = "@BlackLogo", SqlDbType = SqlDbType.NVarChar, Value = entity.BlackLogo.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
