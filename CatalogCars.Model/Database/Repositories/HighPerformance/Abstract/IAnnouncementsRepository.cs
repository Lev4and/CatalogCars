using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IAnnouncementsRepository
    {
        bool Save(ref Announcement entity);
    }
}
