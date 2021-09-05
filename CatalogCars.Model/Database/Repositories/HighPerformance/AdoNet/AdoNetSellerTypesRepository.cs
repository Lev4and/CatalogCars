using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetSellerTypesRepository : ISellerTypesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetSellerTypesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM SellerTypes " +
                $"WHERE SellerTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetSellerTypeId(string name)
        {
            var query = $"SELECT TOP(1) SellerTypes.Id " +
                $"FROM SellerTypes " +
                $"WHERE SellerTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref SellerType entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [SellerTypes] (Id, Name, RuName) VALUES ('{entity.Id}', @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetSellerTypeId(entity.Name);
            }

            return true;
        }
    }
}
