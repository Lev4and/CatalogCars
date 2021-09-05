using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetComplectationOptionsRepository : IComplectationOptionsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetComplectationOptionsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid complectationId, Guid optionId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM ComplectationOptions " +
                $"WHERE ComplectationOptions.ComplectationId = '{complectationId}' AND ComplectationOptions.OptionId = " +
                $"'{optionId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public bool Save(ref ComplectationOption entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [ComplectationOptions] (Id, ComplectationId, OptionId) VALUES ('{entity.Id}', " +
                $"'{entity.ComplectationId}', '{entity.OptionId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
