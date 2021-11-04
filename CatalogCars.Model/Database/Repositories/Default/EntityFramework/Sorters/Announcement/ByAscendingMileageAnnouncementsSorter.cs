using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Announcement
{
    public class ByAscendingMileageAnnouncementsSorter : IAnnouncementsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingMileage;

        public IQueryable<Entities.Announcement> Sort(IQueryable<Entities.Announcement> collection)
        {
            return collection.OrderBy(item => item.State.Mileage);
        }
    }
}
