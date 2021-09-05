using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ILocationsRepository
    {
        bool Contains(double latitude, double longitude);

        bool Save(ref Location entity);

        Guid GetLocationId(double latitude, double longitude);
    }
}
