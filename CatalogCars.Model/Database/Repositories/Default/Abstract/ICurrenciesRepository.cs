using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICurrenciesRepository
    {
        int GetCountCurrencies(CurrenciesFilters filters);

        IQueryable<string> GetNamesCurrencies(string searchString);

        IQueryable<Currency> GetCurrencies(CurrenciesFilters filters);
    }
}
