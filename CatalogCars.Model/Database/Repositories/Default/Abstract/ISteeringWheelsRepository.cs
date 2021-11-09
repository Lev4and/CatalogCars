using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISteeringWheelsRepository
    {
        bool ContainsSteeringWheel(string name, string ruName);

        bool SaveSteeringWheel(SteeringWheel steeringWheel);

        int GetCountSteeringWheels(SteeringWheelsFilters filters);

        SteeringWheel GetSteeringWheel(Guid id);

        IQueryable<string> GetNamesSteeringWheels(string searchString);

        IQueryable<SteeringWheel> GetSteeringWheels();

        IQueryable<SteeringWheel> GetSteeringWheels(SteeringWheelsFilters filters);

        void DeleteSteeringWheel(Guid id);
    }
}
