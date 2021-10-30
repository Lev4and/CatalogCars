using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IBodyTypeGroupsRepository
    {
        bool ContainsBodyTypeGroup(string autoClass, string ruName);

        bool SaveBodyTypeGroup(BodyTypeGroup bodyTypeGroup);

        int GetCountBodyTypeGroups(BodyTypeGroupsFilters filters);

        BodyTypeGroup GetBodyTypeGroup(Guid id);

        IQueryable<string> GetNamesBodyTypeGroups(string searchString);

        IQueryable<BodyTypeGroup> GetBodyTypeGroups();

        IQueryable<BodyTypeGroup> GetBodyTypeGroups(BodyTypeGroupsFilters filters);

        void DeleteBodyTypeGroup(Guid id);
    }
}
