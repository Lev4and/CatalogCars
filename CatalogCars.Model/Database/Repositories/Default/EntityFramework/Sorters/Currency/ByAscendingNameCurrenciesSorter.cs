using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency
{
    public class ByAscendingNameCurrenciesSorter : ICurrenciesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Currency> Sort(IQueryable<Entities.Currency> currencies)
        {
            return currencies.OrderBy(currency => currency.Name);
        }
    }
}
