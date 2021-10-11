using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Announcement
{
    public class ByDescendingNameAnnouncementsSorter : IAnnouncementsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Announcement> Sort(IQueryable<Entities.Announcement> collection)
        {
            return collection.OrderByDescending(item => item.Vehicle.Generation.Name);
        }
    }
}
