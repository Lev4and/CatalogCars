using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel
{
    public interface ISteeringWheelsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.SteeringWheel> Sort(IQueryable<Entities.SteeringWheel> steeringWheels);
    }
}
