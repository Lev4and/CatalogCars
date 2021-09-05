using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ICurrenciesRepository
    {
        bool Contains(string name);

        bool Save(ref Currency entity);

        Guid GetCurrencyId(string name);
    }
}
