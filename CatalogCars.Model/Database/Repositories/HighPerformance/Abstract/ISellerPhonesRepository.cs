using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISellerPhonesRepository
    {
        bool Contains(Guid sellerId, Guid phoneId);

        bool Save(ref SellerPhone entity);
    }
}
