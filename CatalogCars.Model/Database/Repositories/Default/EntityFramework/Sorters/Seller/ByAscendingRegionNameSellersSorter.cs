using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Seller
{
    public class ByAscendingRegionNameSellersSorter : ISellersSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingRegionName;

        public IQueryable<Entities.Seller> Sort(IQueryable<Entities.Seller> collection)
        {
            return collection.OrderBy(item => item.Location.Region.Name);
        }
    }
}
