using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISellerTypesRepository
    {
        int GetCountSellerTypes(SellerTypesFilters filters);

        IQueryable<string> GetNamesSellerTypes(string searchString);

        IQueryable<SellerType> GetSellerTypes(SellerTypesFilters filters);
    }
}
