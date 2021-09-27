using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Seller
{
    public class ByDescendingNameSellersSorter : ISellersSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Seller> Sort(IQueryable<Entities.Seller> collection)
        {
            return collection.OrderByDescending(item => item.Name);
        }
    }
}
