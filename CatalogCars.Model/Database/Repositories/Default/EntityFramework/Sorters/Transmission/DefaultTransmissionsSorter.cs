using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission
{
    public class DefaultTransmissionsSorter : ITransmissionsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Transmission> Sort(IQueryable<Entities.Transmission> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
