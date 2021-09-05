using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetConfigurationTagsRepository : IConfigurationTagsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetConfigurationTagsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid configurationId, Guid tagId)
        {
            var query = $"SELECT TOP(1) * " +
                $"FROM ConfigurationTags " +
                $"WHERE ConfigurationTags.ConfigurationId = '{configurationId}' AND ConfigurationTags.TagId = " +
                $"'{tagId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public bool Save(ref ConfigurationTag entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [ConfigurationTags] (Id, ConfigurationId, TagId) VALUES ('{entity.Id}', " +
                $"'{entity.ConfigurationId}', '{entity.TagId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
