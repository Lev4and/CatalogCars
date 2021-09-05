using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Extensions;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetTechnicaParametersRepository : ITechnicalParametersRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetTechnicaParametersRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref TechnicalParameters entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [TechnicalParameters] (Id, VehicleId, GearTypeId, EngineTypeId, TransmissionId, Power, " +
                $"PowerKvt, Displacement, ClearanceMin, FuelRate, Acceleration, Name, HumanName, Nameplate) VALUES ('{entity.Id}', " +
                $"'{entity.VehicleId}', '{entity.GearTypeId}', '{entity.EngineTypeId}', '{entity.TransmissionId}', @Power, " +
                $"@PowerKvt, @Displacement, @ClearanceMin, @FuelRate, @Acceleration, @Name, @HumanName, @Nameplate)";

            var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@Power", SqlDbType = SqlDbType.Int, Value = entity.Power },
                    new SqlParameter() { ParameterName = "@PowerKvt", SqlDbType = SqlDbType.Int, Value = entity.PowerKvt },
                    new SqlParameter() { ParameterName = "@Displacement", SqlDbType = SqlDbType.Int, Value = entity.Displacement },
                    new SqlParameter() { ParameterName = "@ClearanceMin", SqlDbType = SqlDbType.Int, Value = entity.ClearanceMin },
                    new SqlParameter() { ParameterName = "@FuelRate", SqlDbType = SqlDbType.Float, Value = entity.FuelRate.GetDbValue() },
                    new SqlParameter() { ParameterName = "@Acceleration", SqlDbType = SqlDbType.Float, Value = entity.Acceleration },
                    new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = entity.Name.GetDbValue() },
                    new SqlParameter() { ParameterName = "@HumanName", SqlDbType = SqlDbType.NVarChar, Value = entity.HumanName },
                    new SqlParameter() { ParameterName = "@Nameplate", SqlDbType = SqlDbType.NVarChar, Value = entity.Nameplate.GetDbValue() }
                };

            _context.ExecuteQuery(query, parameters);

            return true;
        }
    }
}
