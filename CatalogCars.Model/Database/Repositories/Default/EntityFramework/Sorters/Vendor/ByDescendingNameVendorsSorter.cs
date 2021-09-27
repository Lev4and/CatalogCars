using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Vendor
{
    public class ByDescendingNameVendorsSorter : IVendorsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Vendor> Sort(IQueryable<Entities.Vendor> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
