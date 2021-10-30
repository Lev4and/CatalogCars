using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICurrenciesRepository
    {
        bool ContainsCurrency(string name);

        bool SaveCurrency(Currency currency);

        int GetCountCurrencies(CurrenciesFilters filters);

        Currency GetCurrency(Guid id);

        IQueryable<string> GetNamesCurrencies(string searchString);

        IQueryable<Currency> GetCurrencies();

        IQueryable<Currency> GetCurrencies(CurrenciesFilters filters);

        void DeleteCurrency(Guid id);
    }
}
