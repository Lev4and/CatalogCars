using System;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IAnnouncementAdditionalInformationRepository
    {
        DateTime GetMinCreatedAt();

        DateTime GetMaxCreatedAt();
    }
}
