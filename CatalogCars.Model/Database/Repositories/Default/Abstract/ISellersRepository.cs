using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISellersRepository
    {
        bool ContainsSeller(Guid locationId);

        bool SaveSeller(Seller seller);

        int GetCountSellers(SellersFilters filters);

        Seller GetSeller(Guid id);

        IQueryable<string> GetNamesSellers(string searchString);

        IQueryable<Seller> GetSellers(SellersFilters filters);

        void DeleteSeller(Guid id);
    }
}
