using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency;
using Microsoft.EntityFrameworkCore;
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

        public int GetCountCurrencies(CurrenciesFilters filters)
        {
            return _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + " (" + currency.Designation + ")",
                    $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<Currency> GetCurrencies(CurrenciesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Currency> currencies = _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + " (" + currency.Designation + ")",
                    $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                currencies = sorter.Sort(currencies);
            }

            return currencies
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesCurrencies(string searchString)
        {
            return _context.Currencies
                .Where(currency => EF.Functions.Like(currency.Name + " (" + currency.Designation + ")",
                    $"%{searchString}%"))
                .OrderBy(currency => currency.Name)
                .Select(currency => currency.Name + " (" + currency.Designation + ")")
                .Take(5)
                .AsNoTracking();
        }
    }
}
