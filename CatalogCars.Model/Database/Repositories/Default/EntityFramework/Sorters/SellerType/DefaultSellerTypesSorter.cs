using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType
{
    public class DefaultSellerTypesSorter : ISellerTypesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.SellerType> Sort(IQueryable<Entities.SellerType> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
