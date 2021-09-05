using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetModelsRepository : IModelsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetModelsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid markId, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Models " +
                $"WHERE Models.MarkId = '{markId}' AND Models.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetMarkId(Guid markId, string name)
        {
            var query = $"SELECT TOP(1) Models.Id " +
                $"FROM Models " +
                $"WHERE Models.MarkId = '{markId}' AND Models.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Entities.Model entity)
        {
            if (!Contains(entity.MarkId, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Models] (Id, MarkId, Code, Name, RuName) VALUES ('{entity.Id}', '{entity.MarkId}', " +
                    $"@Code, @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Code", SqlDbType = SqlDbType.NVarChar, Value = entity.Code },
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetMarkId(entity.MarkId, entity.Name);
            }

            return true;
        }
    }
}
