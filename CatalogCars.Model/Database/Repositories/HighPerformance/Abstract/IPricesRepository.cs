using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPricesRepository
    {
        bool Save(ref Price entity);
    }
}
