using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetPtsRepository : IPtsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetPtsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Pts entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Pts] (Id, DocumentsId, PtsTypeId, IsOriginal, CustomCleared, NotRegisteredInRussia, " +
                $"Year, OwnersNumber) VALUES ('{entity.Id}', '{entity.DocumentsId}', @PtsTypeId, @IsOriginal, @CustomCleared, " +
                $"@NotRegisteredInRussia, @Year, @OwnersNumber)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@PtsTypeId", SqlDbType = SqlDbType.UniqueIdentifier, Value = entity.PtsTypeId.GetDbValue() },
                new SqlParameter() { ParameterName = "@IsOriginal", SqlDbType = SqlDbType.Bit, Value = entity.IsOriginal },
                new SqlParameter() { ParameterName = "@CustomCleared", SqlDbType = SqlDbType.Bit, Value = entity.CustomCleared.GetDbValue() },
                new SqlParameter() { ParameterName = "@NotRegisteredInRussia", SqlDbType = SqlDbType.Bit, Value = entity.NotRegisteredInRussia.GetDbValue() },
                new SqlParameter() { ParameterName = "@Year", SqlDbType = SqlDbType.Int, Value = entity.Year.GetDbValue() },
                new SqlParameter() { ParameterName = "@OwnersNumber", SqlDbType = SqlDbType.Int, Value = entity.OwnersNumber.GetDbValue() },
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
