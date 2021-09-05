using CatalogCars.Model.Database.Entities;
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

        public bool Contains(Guid modelId, int yearFrom, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Generations " +
                $"WHERE Generations.ModelId = '{modelId}' AND Generations.YearFrom = {yearFrom} AND Generations.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetGenerationId(Guid modelId, int yearFrom, string name)
        {
            var query = $"SELECT TOP(1) Generations.Id " +
                $"FROM Generations " +
                $"WHERE Generations.ModelId = '{modelId}' AND Generations.YearFrom = {yearFrom} AND Generations.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Generation entity)
        {
            if (!Contains(entity.ModelId, entity.YearFrom, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Generations] (Id, ModelId, PriceSegmentId, YearFrom, Name, RuName) " +
                    $"VALUES ('{entity.Id}', '{entity.ModelId}', '{entity.PriceSegmentId}', {entity.YearFrom}, @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
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
