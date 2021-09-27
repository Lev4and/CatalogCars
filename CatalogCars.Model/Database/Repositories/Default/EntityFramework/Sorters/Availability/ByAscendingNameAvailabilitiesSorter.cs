using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Availability
{
    public class ByAscendingNameAvailabilitiesSorter : IAvailabilitiesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Availability> Sort(IQueryable<Entities.Availability> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
