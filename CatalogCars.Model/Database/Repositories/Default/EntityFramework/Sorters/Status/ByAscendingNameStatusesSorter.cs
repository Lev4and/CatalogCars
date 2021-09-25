using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status
{
    public class ByAscendingNameStatusesSorter : IStatusesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Status> Sort(IQueryable<Entities.Status> statuses)
        {
            return statuses.OrderBy(status => status.RuName);
        }
    }
}
