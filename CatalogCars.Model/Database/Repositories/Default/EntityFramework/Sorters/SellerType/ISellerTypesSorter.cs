using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType
{
    public interface ISellerTypesSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.SellerType> Sort(IQueryable<Entities.SellerType> sellerTypes);
    }
}
