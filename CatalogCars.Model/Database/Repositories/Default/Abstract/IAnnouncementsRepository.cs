using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IAnnouncementsRepository
    {
        int GetCountAnnouncements(AnnouncementsFilters filters);

        IQueryable<string> GetNamesAnnouncements(string searchString);

        IQueryable<Announcement> GetAnnouncements(AnnouncementsFilters filters);
    }
}
