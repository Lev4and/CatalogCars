using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public class ByAscendingNameLocationsSorter : ILocationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> locations)
        {
            return locations.OrderBy(location => location.Address);
        }
    }
}
