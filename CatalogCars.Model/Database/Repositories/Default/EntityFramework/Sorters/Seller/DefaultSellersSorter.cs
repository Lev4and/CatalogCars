using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Seller
{
    public class DefaultSellersSorter : ISellersSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Seller> Sort(IQueryable<Entities.Seller> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
