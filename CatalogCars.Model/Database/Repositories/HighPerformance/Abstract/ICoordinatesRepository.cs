using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ICoordinatesRepository
    {
        bool Save(ref Coordinate entity);
    }
}
