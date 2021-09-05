using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IAnnouncementAdditionalInformationRepository
    {
        bool Save(ref AnnouncementAdditionalInformation entity);
    }
}
