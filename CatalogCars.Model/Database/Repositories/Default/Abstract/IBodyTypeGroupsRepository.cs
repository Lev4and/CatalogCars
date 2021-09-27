using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IBodyTypeGroupsRepository
    {
        int GetCountBodyTypeGroups(BodyTypeGroupsFilters filters);

        IQueryable<string> GetNamesBodyTypeGroups(string searchString);

        IQueryable<BodyTypeGroup> GetBodyTypeGroups(BodyTypeGroupsFilters filters);
    }
}
