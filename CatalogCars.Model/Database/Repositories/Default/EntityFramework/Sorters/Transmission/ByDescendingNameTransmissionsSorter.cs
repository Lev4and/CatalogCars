using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission
{
    public class ByDescendingNameTransmissionsSorter : ITransmissionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Transmission> Sort(IQueryable<Entities.Transmission> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
