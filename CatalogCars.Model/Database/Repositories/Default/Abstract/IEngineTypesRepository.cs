using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IEngineTypesRepository
    {
        bool ContainsEngineType(string name, string ruName);

        bool SaveEngineType(EngineType engineType);

        int GetCountEngineTypes(EngineTypesFilters filters);

        EngineType GetEngineType(Guid id);

        IQueryable<string> GetNamesEngineTypes(string searchString);

        IQueryable<EngineType> GetEngineTypes();

        IQueryable<EngineType> GetEngineTypes(EngineTypesFilters filters);

        void DeleteEngineType(Guid id);
    }
}
