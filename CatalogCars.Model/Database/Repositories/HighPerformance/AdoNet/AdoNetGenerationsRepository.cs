using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetGenerationsRepository : IGenerationsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetGenerationsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid modelId, int? yearFrom, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Generations " +
                $"WHERE Generations.ModelId = '{modelId}' AND Generations.YearFrom {(yearFrom != null ? "= @YearFrom" : "IS NULL")} AND Generations.Name {(!string.IsNullOrEmpty(name) ? "= @Name" : "IS NULL")}";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@YearFrom", SqlDbType = SqlDbType.Int, Value = yearFrom.GetDbValue() },
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name.GetDbValue() }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetGenerationId(Guid modelId, int? yearFrom, string name)
        {
            var query = $"SELECT TOP(1) Generations.Id " +
                $"FROM Generations " +
                $"WHERE Generations.ModelId = '{modelId}' AND Generations.YearFrom {(yearFrom != null ? "= @YearFrom" : "IS NULL")} AND Generations.Name {(!string.IsNullOrEmpty(name) ? "= @Name" : "IS NULL")}";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@YearFrom", SqlDbType = SqlDbType.Int, Value = yearFrom.GetDbValue() },
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name.GetDbValue() }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Generation entity)
        {
            if (!Contains(entity.ModelId, entity.YearFrom, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Generations] (Id, ModelId, PriceSegmentId, YearFrom, Name, RuName) " +
                    $"VALUES ('{entity.Id}', '{entity.ModelId}', @PriceSegmentId, @YearFrom, @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@PriceSegmentId", SqlDbType = SqlDbType.UniqueIdentifier, Value = entity.PriceSegmentId.GetDbValue() },
                    new SqlParameter() { ParameterName = "@YearFrom", SqlDbType = SqlDbType.Int, Value = entity.YearFrom.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name.GetDbValue() },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName.GetDbValue() },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetGenerationId(entity.ModelId, entity.YearFrom, entity.Name);
            }

            return true;
        }
    }
}
