using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Announcement
{
    public class DefaultAnnouncementsSorter : IAnnouncementsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Announcement> Sort(IQueryable<Entities.Announcement> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
