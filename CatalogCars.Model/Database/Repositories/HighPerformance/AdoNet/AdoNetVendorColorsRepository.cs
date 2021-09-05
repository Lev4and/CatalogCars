using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetVendorColorsRepository : IVendorColorsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetVendorColorsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid complectationId, string name)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM VendorColors " +
                $"WHERE VendorColors.ComplectationId = '{complectationId}' AND VendorColors.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows.Count > 0;
        }

        public Guid GetVendorColorId(Guid complectationId, string name)
        {
            var query = $"SELECT TOP(1) VendorColors.Id " +
                $"FROM VendorColors " +
                $"WHERE VendorColors.ComplectationId = '{complectationId}' AND VendorColorPhotos.Name = @Name";

            var parameters = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = name }
            };

            return _context.ExecuteQuery(query, parameters).Rows[0].Field<Guid>("Id");
        }

        public bool Save(ref VendorColor entity)
        {
            if (!Contains(entity.ComplectationId, entity.Name))
            {
                entity.Id = Guid.NewGuid();

                var query = $"INSERT INTO [VendorColors] (Id, ComplectationId, ColorTypeId, Name, RuName, HexCode, HexCodes) VALUES " +
                    $"('{entity.Id}', '{entity.ComplectationId}', '{entity.ColorTypeId}', @Name, @RuName, @HexCode, @HexCodes)";

                var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name },
                    new SqlParameter() { ParameterName = "@RuName", SqlDbType = SqlDbType.NVarChar, Value = entity.RuName },
                    new SqlParameter() { ParameterName = "@HexCode", SqlDbType = SqlDbType.NVarChar, Value = entity.HexCode },
                    new SqlParameter() { ParameterName = "@HexCodes", SqlDbType = SqlDbType.NVarChar, Value = entity.HexCodes.GetDbValue() },
                };

                _context.ExecuteQuery(query, parameters);
            }
            else
            {
                entity.Id = GetVendorColorId(entity.ComplectationId, entity.Name);
            }

            return true;
        }
    }
}
