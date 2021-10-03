using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public class ByAscendingRegionNameLocationsSorter : ILocationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingRegionName;

        public IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> collection)
        {
            return collection.OrderBy(item => item.Region.Name);
        }
    }
}
