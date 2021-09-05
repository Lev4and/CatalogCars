using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetColorTypesRepository : IColorTypesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetColorTypesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM ColorTypes " +
                $"WHERE ColorTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetColorTypeId(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM ColorTypes " +
                $"WHERE ColorTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref ColorType entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [ColorTypes] (Id, Name, RuName) VALUES ('{entity.Id}', @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetColorTypeId(entity.Name);
            }

            return true;
        }
    }
}
