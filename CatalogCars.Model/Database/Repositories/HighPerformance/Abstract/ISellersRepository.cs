using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISellersRepository
    {
        bool Contains(Guid locationId);

        bool Save(ref Seller entity);

        Guid GetSellerId(Guid locationId);
    }
}
