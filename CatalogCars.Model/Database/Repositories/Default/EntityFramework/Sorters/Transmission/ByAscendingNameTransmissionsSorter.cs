using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission
{
    public class ByAscendingNameTransmissionsSorter : ITransmissionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Transmission> Sort(IQueryable<Entities.Transmission> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
