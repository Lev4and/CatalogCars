using CatalogCars.Model.Database.AuxiliaryTypes;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ILocationsRepository
    {
        bool ContainsLocation(double latitude, double longitude);

        bool SaveLocation(Entities.Location location);

        int GetCountLocations(LocationsFilters filters);

        Entities.Location GetLocation(Guid id);

        IQueryable<string> GetNamesLocations(string searchString);

        IQueryable<Entities.Location> GetLocations(LocationsFilters filters);

        void DeleteLocation(Guid id);
    }
}
