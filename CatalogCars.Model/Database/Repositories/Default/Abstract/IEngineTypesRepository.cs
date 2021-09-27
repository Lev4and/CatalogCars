using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IEngineTypesRepository
    {
        int GetCountEngineTypes(EngineTypesFilters filters);

        IQueryable<string> GetNamesEngineTypes(string searchString);

        IQueryable<EngineType> GetEngineTypes(EngineTypesFilters filters);
    }
}
