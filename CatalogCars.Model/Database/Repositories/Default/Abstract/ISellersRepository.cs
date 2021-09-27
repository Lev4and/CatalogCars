using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISellersRepository
    {
        int GetCountSellers(SellersFilters filters);

        IQueryable<string> GetNamesSellers(string searchString);

        IQueryable<Seller> GetSellers(SellersFilters filters);
    }
}
