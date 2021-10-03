using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetSalonsRepository : ISalonsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetSalonsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid locationId, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM Salons " +
                $"WHERE Salons.LocationId = '{locationId}' AND Salons.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetSalonId(Guid locationId, string name)
        {
            var query = $"SELECT TOP(1) Salons.Id " +
                $"FROM Salons " +
                $"WHERE Salons.LocationId = '{locationId}' AND Salons.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref Salon entity)
        {
            if (!Contains(entity.LocationId, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [Salons] (Id, LocationId, IsOfficial, ActualStock, LoyaltyProgram, Code, Name, " +
                    $"RegistrationDate) VALUES ('{entity.Id}', '{entity.LocationId}', @IsOfficial, @ActualStock, @LoyaltyProgram, " +
                    $"@Code, @Name, @RegistrationDate)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@IsOfficial", SqlDbType = SqlDbType.Bit, Value = entity.IsOfficial.GetDbValue() },
                    new SqlParameter() { ParameterName = "@ActualStock", SqlDbType = SqlDbType.Bit, Value = entity.ActualStock.GetDbValue() },
                    new SqlParameter() { ParameterName = "@LoyaltyProgram", SqlDbType = SqlDbType.Bit, Value = entity.LoyaltyProgram.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Code", SqlDbType = SqlDbType.NVarChar, Value = entity.Code.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RegistrationDate", SqlDbType = SqlDbType.DateTime2, Value = entity.RegistrationDate }
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetSalonId(entity.LocationId, entity.Name);

                return false;
            }

            return true;
        }
    }
}
