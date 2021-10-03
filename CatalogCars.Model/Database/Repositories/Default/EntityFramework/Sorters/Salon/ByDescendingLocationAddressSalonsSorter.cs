using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByDescendingLocationAddressSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingLocationAddress;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderByDescending(item => item.Location.Address);
        }
    }
}
