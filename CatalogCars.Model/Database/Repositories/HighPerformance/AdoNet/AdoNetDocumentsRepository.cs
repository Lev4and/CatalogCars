using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetDocumentsRepository : IDocumentsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetDocumentsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref Documents entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [Documents] (Id, AnnouncementId, Warranty, LicensePlate, PurchaseDate, WarrantyExpire) " +
                $"VALUES ('{entity.Id}', '{entity.AnnouncementId}', @Warranty, @LicensePlate, @PurchaseDate, @WarrantyExpire)";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Warranty", SqlDbType = SqlDbType.Bit, Value = entity.Warranty.GetDbValue() },
                new SqlParameter() { ParameterName = "@LicensePlate", SqlDbType = SqlDbType.NVarChar, Value = entity.LicensePlate.GetDbValue() },
                new SqlParameter() { ParameterName = "@PurchaseDate", SqlDbType = SqlDbType.DateTime2, Value = entity.PurchaseDate.GetDbValue() },
                new SqlParameter() { ParameterName = "@WarrantyExpire", SqlDbType = SqlDbType.DateTime2, Value = entity.WarrantyExpire.GetDbValue() }
            };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
