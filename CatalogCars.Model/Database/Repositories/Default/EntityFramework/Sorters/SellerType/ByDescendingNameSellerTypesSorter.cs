using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType
{
    public class ByDescendingNameSellerTypesSorter : ISellerTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.SellerType> Sort(IQueryable<Entities.SellerType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
