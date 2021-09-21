using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ILocationsRepository
    {
        int GetCountLocations(LocationsFilters filters);

        IQueryable<string> GetNamesLocations(string searchString);

        IQueryable<Entities.Location> GetLocations(LocationsFilters filters);
    }
}
