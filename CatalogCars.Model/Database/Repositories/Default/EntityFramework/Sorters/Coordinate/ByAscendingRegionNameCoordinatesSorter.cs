using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Coordinate
{
    public class ByAscendingRegionNameCoordinatesSorter : ICoordinatesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingRegionName;

        public IQueryable<Entities.Coordinate> Sort(IQueryable<Entities.Coordinate> collection)
        {
            return collection.OrderBy(item => item.Location.Region.Name);
        }
    }
}
