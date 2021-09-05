using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetTransmissionsRepository : ITransmissionsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetTransmissionsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Transmissions " +
                $"WHERE Transmissions.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetTransmissionId(string name)
        {
            var query = $"SELECT TOP(1) Transmissions.Id " +
                $"FROM Transmissions " +
                $"WHERE Transmissions.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Transmission entity)
        {
            if (!Contains(entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Transmissions] (Id, Name, RuName) VALUES ('{entity.Id}', @Name, @RuName)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetTransmissionId(entity.Name);
            }

            return true;
        }
    }
}
