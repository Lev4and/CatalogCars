using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Vendor
{
    public class ByAscendingNameVendorsSorter : IVendorsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Vendor> Sort(IQueryable<Entities.Vendor> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
