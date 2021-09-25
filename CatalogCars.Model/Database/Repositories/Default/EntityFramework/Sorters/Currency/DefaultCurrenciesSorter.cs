using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency
{
    public class DefaultCurrenciesSorter : ICurrenciesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Currency> Sort(IQueryable<Entities.Currency> currencies)
        {
            return currencies.OrderBy(currency => currency.Id);
        }
    }
}
