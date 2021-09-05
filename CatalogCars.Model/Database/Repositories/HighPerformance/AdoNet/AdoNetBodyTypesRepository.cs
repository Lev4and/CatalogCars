using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetBodyTypesRepository : IBodyTypesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetBodyTypesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid bodyTypeGroupId, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM BodyTypes " +
                $"WHERE BodyTypes.BodyTypeGroupId = '{bodyTypeGroupId}' AND BodyTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetBodyTypeId(Guid bodyTypeGroupId, string name)
        {
            var query = $"SELECT TOP(1) BodyTypes.Id " +
                $"FROM BodyTypes " +
                $"WHERE BodyTypes.BodyTypeGroupId = '{bodyTypeGroupId}' AND BodyTypes.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref BodyType entity)
        {
            if (!Contains(entity.BodyTypeGroupId, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [BodyTypes] (Id, BodyTypeGroupId, Name, RuName) VALUES ('{entity.Id}', " +
                    $"'{entity.BodyTypeGroupId}', @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetBodyTypeId(entity.BodyTypeGroupId, entity.Name);
            }

            return true;
        }
    }
}
