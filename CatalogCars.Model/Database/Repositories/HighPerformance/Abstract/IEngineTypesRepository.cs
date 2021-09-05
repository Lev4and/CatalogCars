using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IEngineTypesRepository
    {
        bool Contains(string name);

        bool Save(ref EngineType entity);

        Guid GetEngineTypeId(string name);
    }
}
