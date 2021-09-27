using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Availability
{
    public class DefaultAvailabilitiesSorter : IAvailabilitiesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Availability> Sort(IQueryable<Entities.Availability> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
