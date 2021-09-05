using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetColorsRepository : IColorsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetColorsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string value)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Colors " +
                $"WHERE Colors.Value = @Value";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.NVarChar, Value = value }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetColorId(string value)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Colors " +
                $"WHERE Colors.Value = @Value";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.NVarChar, Value = value }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Color entity)
        {
            if (!Contains(entity.Value))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Colors] (Id, Value) VALUES ('{entity.Id}', @Value)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.NVarChar, Value = entity.Value }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetColorId(entity.Value);
            }

            return true;
        }
    }
}
