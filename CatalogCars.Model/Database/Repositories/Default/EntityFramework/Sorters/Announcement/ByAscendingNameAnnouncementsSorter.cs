using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Announcement
{
    public class ByAscendingNameAnnouncementsSorter : IAnnouncementsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Announcement> Sort(IQueryable<Entities.Announcement> collection)
        {
            return collection
                .OrderBy(item => item.Vehicle.Generation.Model.Mark.Name)
                    .ThenBy(item => item.Vehicle.Generation.Model.Name)
                        .ThenBy(item => item.Vehicle.Generation.Name);
        }
    }
}
