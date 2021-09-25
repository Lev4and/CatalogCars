using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISteeringWheelsRepository
    {
        int GetCountSteeringWheels(SteeringWheelsFilters filters);

        IQueryable<string> GetNamesSteeringWheels(string searchString);

        IQueryable<SteeringWheel> GetSteeringWheels(SteeringWheelsFilters filters);
    }
}
