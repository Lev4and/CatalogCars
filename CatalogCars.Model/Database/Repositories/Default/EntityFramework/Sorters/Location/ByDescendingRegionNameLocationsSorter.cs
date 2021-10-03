using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public class ByDescendingRegionNameLocationsSorter : ILocationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingRegionName;

        public IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> collection)
        {
            return collection.OrderByDescending(item => item.Region.Name);
        }
    }
}
