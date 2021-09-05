using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVehicleInformationRepository
    {
        bool Save(ref VehicleInformation entity);
    }
}
