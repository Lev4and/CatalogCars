using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Coordinate
{
    public class DefaultCoordinatesSorter : ICoordinatesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Coordinate> Sort(IQueryable<Entities.Coordinate> collection)
        {
            return collection.OrderBy(item => item.Location.Region.Id);
        }
    }
}
