using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IGearTypesRepository
    {
        bool ContainsGearType(string name, string ruName);

        bool SaveGearType(GearType gearType);

        int GetCountGearTypes(GearTypesFilters filters);

        GearType GetGearType(Guid id);

        IQueryable<string> GetNamesGearTypes(string searchString);

        IQueryable<GearType> GetGearTypes();

        IQueryable<GearType> GetGearTypes(GearTypesFilters filters);

        void DeleteGearType(Guid id);
    }
}
