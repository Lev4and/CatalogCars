using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IAnnouncementTagsRepository
    {
        bool Contains(Guid announcementId, Guid tagId);

        bool Save(ref AnnouncementTag entity);
    }
}
