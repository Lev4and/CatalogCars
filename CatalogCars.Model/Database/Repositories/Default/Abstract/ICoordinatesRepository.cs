using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICoordinatesRepository
    {
        bool ContainsCoordinate(Guid locationId, double latitude, double longitude);

        bool SaveCoordinate(Coordinate coordinate);

        int GetCountCoordinates(CoordinatesFilters filters);

        Coordinate GetCoordinate(Guid id);

        IQueryable<string> GetNamesCoordinates(string searchString);

        IQueryable<Coordinate> GetCoordinates(CoordinatesFilters filters);

        void DeleteCoordinate(Guid id);
    }
}
