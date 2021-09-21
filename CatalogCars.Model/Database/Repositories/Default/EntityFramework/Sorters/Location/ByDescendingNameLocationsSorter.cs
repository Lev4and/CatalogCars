using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public class ByDescendingNameLocationsSorter : ILocationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> locations)
        {
            return locations.OrderByDescending(location => location.Address);
        }
    }
}
