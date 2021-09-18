using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetBodyTypeGroupsRepository : IBodyTypeGroupsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetBodyTypeGroupsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM BodyTypeGroups " +
                $"WHERE BodyTypeGroups.Name {(!string.IsNullOrEmpty(name) ? "= @Name" : "IS NULL")}";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name.GetDbValue() }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetBodyTypeGroupId(string name)
        {
            var query = $"SELECT TOP(1) BodyTypeGroups.Id " +
                $"FROM BodyTypeGroups " +
                $"WHERE BodyTypeGroups.Name {(!string.IsNullOrEmpty(name) ? "= @Name" : "IS NULL")}";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name.GetDbValue() }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref BodyTypeGroup entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [BodyTypeGroups] (Id, Name, RuName, AutoClass) VALUES ('{entity.Id}', @Name, @RuName, " +
                    $"@AutoClass)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name.GetDbValue() },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName.GetDbValue() },
                    new SqlParameter() { ParameterName = "@AutoClass", SqlDbType = SqlDbType.NVarChar, Value = entity.AutoClass.GetDbValue() }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetBodyTypeGroupId(entity.Name);
            }

            return true;
        }
    }
}
