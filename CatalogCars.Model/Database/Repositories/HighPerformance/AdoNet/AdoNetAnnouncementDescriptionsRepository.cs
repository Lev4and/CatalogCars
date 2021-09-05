using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetAnnouncementDescriptionsRepository : IAnnouncementDescriptionsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetAnnouncementDescriptionsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref AnnouncementDescription entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [AnnouncementDescriptions] (Id, AnnouncementId, Value) VALUES ('{entity.Id}', " +
                $"'{entity.AnnouncementId}', @Value)";

            var parameters = new List<SqlParameter>() 
            {
                new SqlParameter() { ParameterName = "@Value", SqlDbType = SqlDbType.NVarChar, Value = entity.Value }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
