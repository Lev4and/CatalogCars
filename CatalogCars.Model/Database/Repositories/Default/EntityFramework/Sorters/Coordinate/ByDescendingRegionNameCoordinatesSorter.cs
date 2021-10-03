using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Coordinate
{
    public class ByDescendingRegionNameCoordinatesSorter : ICoordinatesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingRegionName;

        public IQueryable<Entities.Coordinate> Sort(IQueryable<Entities.Coordinate> collection)
        {
            return collection.OrderByDescending(item => item.Location.Region.Name);
        }
    }
}
