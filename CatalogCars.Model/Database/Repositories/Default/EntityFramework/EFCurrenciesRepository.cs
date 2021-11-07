using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFCurrenciesRepository : ICurrenciesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ICurrenciesSorter> _sorters;

        public EFCurrenciesRepository(CatalogCarsDbContext context, IEnumerable<ICurrenciesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsCurrency(string name)
        {
            return _context.Currencies.FirstOrDefault(currency => currency.Name == name) != null;
        }

        public void DeleteCurrency(Guid id)
        {
            _context.Currencies.Remove(GetCurrency(id));
            _context.SaveChanges();
        }

        public int GetCountCurrencies(CurrenciesFilters filters)
        {
            return _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + (currency.Designation != null ? 
                    " (" + currency.Designation + ")" : ""),
                    $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<Currency> GetCurrencies(CurrenciesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Currency> currencies = _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + (currency.Designation != null ?
                    " (" + currency.Designation + ")" : ""), $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                currencies = sorter.Sort(currencies);
            }

            return currencies
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Currency> GetCurrencies()
        {
            return _context.Currencies
                .AsNoTracking();
        }

        public Currency GetCurrency(Guid id)
        {
            return _context.Currencies.FirstOrDefault(currency => currency.Id == id);
        }

        public IQueryable<string> GetNamesCurrencies(string searchString)
        {
            return _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + (currency.Designation != null ?
                    " (" + currency.Designation + ")" : ""), $"%{searchString}%"))
                .OrderBy(currency => currency.Name)
                .Select(currency => currency.Name + " (" + currency.Designation + ")")
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveCurrency(Currency currency)
        {
            if(currency.Id == default)
            {
                if (!ContainsCurrency(currency.Name))
                {
                    _context.Entry(currency).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetCurrency(currency.Id);

                if(currentVersion.Name != currency.Name)
                {
                    if (!ContainsCurrency(currency.Name))
                    {
                        _context.Entry(currency).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(currency).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
