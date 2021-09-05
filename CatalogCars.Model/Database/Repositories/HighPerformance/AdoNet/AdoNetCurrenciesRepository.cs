using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetCurrenciesRepository : ICurrenciesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetCurrenciesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Currencies " +
                $"WHERE Currencies.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetCurrencyId(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Currencies " +
                $"WHERE Currencies.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Currency entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Currencies] (Id, Name, Designation) VALUES ('{entity.Id}', @Name, @Designation)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@Designation", SqlDbType = SqlDbType.NVarChar, Value = entity.Designation.GetDbValue() },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetCurrencyId(entity.Name);
            }

            return true;
        }
    }
}
