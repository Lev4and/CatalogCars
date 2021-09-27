using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IBodyTypesRepository
    {
        int GetCountBodyTypes(BodyTypesFilters filters);

        IQueryable<string> GetNamesBodyTypes(string searchString);

        IQueryable<BodyType> GetBodyTypes(BodyTypesFilters filters);
    }
}
