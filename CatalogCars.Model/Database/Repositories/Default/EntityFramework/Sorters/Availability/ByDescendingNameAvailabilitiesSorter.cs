using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Availability
{
    public class ByDescendingNameAvailabilitiesSorter : IAvailabilitiesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Availability> Sort(IQueryable<Entities.Availability> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
