using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVehicleMainPhotosRepository
    {
        bool Save(ref VehicleMainPhoto entity);
    }
}
