using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IBodyTypesRepository
    {
        bool ContainsBodyType(Guid bodyTypeGroupId, string name, string ruName);

        bool SaveBodyType(BodyType bodyType);

        int GetCountBodyTypes(BodyTypesFilters filters);

        int GetCountBodyTypesOfBodyTypeGroups(BodyTypesFilters filters);

        IQueryable<string> GetNamesBodyTypes(string searchString);

        BodyType GetBodyType(Guid id);

        IQueryable<BodyType> GetBodyTypes(BodyTypesFilters filters);

        IQueryable<BodyType> GetBodyTypesOfBodyTypeGroups(BodyTypesFilters filters);

        void DeleteBodyType(Guid id);
    }
}
