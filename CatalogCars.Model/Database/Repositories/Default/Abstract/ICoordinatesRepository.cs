using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICoordinatesRepository
    {
        int GetCountCoordinates(CoordinatesFilters filters);

        IQueryable<string> GetNamesCoordinates(string searchString);

        IQueryable<Coordinate> GetCoordinates(CoordinatesFilters filters);
    }
}
