using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISellerTypesRepository
    {
        bool Contains(string name);

        bool Save(ref SellerType entity);

        Guid GetSellerTypeId(string name);
    }
}
