using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Currency
{
    public interface ICurrenciesSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Currency> Sort(IQueryable<Entities.Currency> currencies);
    }
}
