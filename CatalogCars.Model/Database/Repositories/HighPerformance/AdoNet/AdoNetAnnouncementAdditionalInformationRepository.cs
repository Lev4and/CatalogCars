using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.HighPerformance.Abstract;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.AdoNet
{
    public class AdoNetAnnouncementAdditionalInformationRepository : IAnnouncementAdditionalInformationRepository
    {
        private readonly CatalogCarsDbContext _context;

        public AdoNetAnnouncementAdditionalInformationRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public bool Save(ref AnnouncementAdditionalInformation entity)
        {
            entity.Id = Guid.NewGuid();

            var query = $"INSERT INTO [AnnouncementAdditionalInformation] (Id, AnnouncementId, CreatedAt, UpdatedAt) " +
                $"VALUES ('{entity.Id}', '{entity.AnnouncementId}', '{entity.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                $"'{entity.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")}')";

            _context.ExecuteQuery(query);

            return true;
        }
    }
}
