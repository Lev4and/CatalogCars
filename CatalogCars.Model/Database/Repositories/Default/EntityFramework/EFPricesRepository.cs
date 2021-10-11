using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPricesRepository : IPricesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFPricesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public double GetMaxPrice(Guid currencyId)
        {
            return _context.Prices
                .Where(price => price.CurrencyId == currencyId)
                .Max(price => price.Value);
        }

        public double GetMinPrice(Guid currencyId)
        {
            return _context.Prices
                .Where(price => price.CurrencyId == currencyId)
                .Min(price => price.Value);
        }
    }
}
