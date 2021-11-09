using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISellerTypesRepository
    {
        bool ContainsSellerType(string name, string ruName);

        bool SaveSellerType(SellerType sellerType);

        int GetCountSellerTypes(SellerTypesFilters filters);

        SellerType GetSellerType(Guid id);

        IQueryable<string> GetNamesSellerTypes(string searchString);

        IQueryable<SellerType> GetSellerTypes();

        IQueryable<SellerType> GetSellerTypes(SellerTypesFilters filters);

        void DeleteSellerType(Guid id);
    }
}
