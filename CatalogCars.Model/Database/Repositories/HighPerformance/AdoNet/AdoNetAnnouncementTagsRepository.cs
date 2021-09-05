using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetAnnouncementTagsRepository : IAnnouncementTagsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetAnnouncementTagsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Contains(Guid announcementId, Guid tagId)
        {
            var query = $"SELECT TOP (1) * " +
                $"FROM AnnouncementTags " +
                $"WHERE AnnouncementTags.AnnouncementId = '{announcementId}' AND AnnouncementTags.TagId = '{tagId}'";

            return _context.ExecuteQuery(query).Rows.Count > 0;
        }

        public bool Save(ref AnnouncementTag entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [AnnouncementTags] (Id, AnnouncementId, TagId) VALUES ('{entity.Id}', " +
                $"'{entity.AnnouncementId}', '{entity.TagId}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
