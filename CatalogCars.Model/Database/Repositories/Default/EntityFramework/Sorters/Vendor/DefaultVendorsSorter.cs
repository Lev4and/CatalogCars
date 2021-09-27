using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Vendor
{
    public class DefaultVendorsSorter : IVendorsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Vendor> Sort(IQueryable<Entities.Vendor> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
