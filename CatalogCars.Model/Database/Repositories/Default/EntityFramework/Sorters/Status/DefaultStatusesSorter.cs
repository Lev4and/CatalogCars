using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status
{
    public class DefaultStatusesSorter : IStatusesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Status> Sort(IQueryable<Entities.Status> statuses)
        {
            return statuses.OrderBy(status => status.Id);
        }
    }
}
