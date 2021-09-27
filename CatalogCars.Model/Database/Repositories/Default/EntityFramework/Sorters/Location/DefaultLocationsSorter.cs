using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public class DefaultLocationsSorter : ILocationsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
