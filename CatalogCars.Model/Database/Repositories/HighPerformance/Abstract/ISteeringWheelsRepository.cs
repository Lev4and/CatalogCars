using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISteeringWheelsRepository
    {
        bool Contains(string name);

        bool Save(ref SteeringWheel entity);

        Guid GetSteeringWheelId(string name);
    }
}
