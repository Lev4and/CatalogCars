using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetAnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetAnnouncementsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Announcement entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Announcements] (Id, ColorId, SalonId, SellerId, StatusId, SectionId, CategoryId, " +
                $"SellerTypeId, AvailabilityId, SaleId, Summary) VALUES ('{entity.Id}', '{entity.ColorId}', '{entity.SalonId}', " +
                $"'{entity.SellerId}', '{entity.StatusId}', '{entity.SectionId}', '{entity.CategoryId}', '{entity.SellerTypeId}', " +
                $"'{entity.AvailabilityId}', @SaleId, @Summary)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@SaleId", SqlDbType = SqlDbType.NVarChar, Value = entity.SaleId },
                new SqlParameter() { ParameterName = "@Summary", SqlDbType = SqlDbType.NVarChar, Value = entity.Summary },
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
