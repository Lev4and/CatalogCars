using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status
{
    public class ByDescendingNameStatusesSorter : IStatusesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Status> Sort(IQueryable<Entities.Status> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
