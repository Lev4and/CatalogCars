using System;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPricesRepository
    {
        double GetMinPrice(Guid currencyId);

        double GetMaxPrice(Guid currencyId);
    }
}
