using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IOptionsRepository
    {
        bool Contains(string name);

        bool Save(ref Option entity);

        Guid GetOptionId(string name);
    }
}
