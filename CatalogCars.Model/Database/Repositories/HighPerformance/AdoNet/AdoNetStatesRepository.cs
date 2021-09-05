using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetStatesRepository : IStatesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetStatesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref State entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [States] (Id, AnnouncementId, IsBeaten, Mileage) VALUES ('{entity.Id}', " +
                $"'{entity.AnnouncementId}', @IsBeaten, @Mileage)";

            var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@IsBeaten", SqlDbType = SqlDbType.Bit, Value = entity.IsBeaten },
                    new SqlParameter() { ParameterName = "@Mileage", SqlDbType = SqlDbType.Int, Value = entity.Mileage },
                };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
