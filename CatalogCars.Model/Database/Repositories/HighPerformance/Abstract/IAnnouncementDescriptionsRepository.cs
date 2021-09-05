using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IAnnouncementDescriptionsRepository
    {
        bool Save(ref AnnouncementDescription entity);
    }
}
