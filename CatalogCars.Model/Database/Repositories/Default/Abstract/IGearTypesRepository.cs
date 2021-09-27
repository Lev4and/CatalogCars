using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IGearTypesRepository
    {
        int GetCountGearTypes(GearTypesFilters filters);

        IQueryable<string> GetNamesGearTypes(string searchString);

        IQueryable<GearType> GetGearTypes(GearTypesFilters filters);
    }
}
