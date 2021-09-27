using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency
{
    public class ByDescendingNameCurrenciesSorter : ICurrenciesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Currency> Sort(IQueryable<Entities.Currency> collection)
        {
            return collection.OrderByDescending(item => item.Name);
        }
    }
}
