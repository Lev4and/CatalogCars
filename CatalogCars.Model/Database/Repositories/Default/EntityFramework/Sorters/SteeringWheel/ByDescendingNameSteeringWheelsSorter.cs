using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel
{
    public class ByDescendingNameSteeringWheelsSorter : ISteeringWheelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.SteeringWheel> Sort(IQueryable<Entities.SteeringWheel> steeringWheels)
        {
            return steeringWheels.OrderByDescending(steeringWheel => steeringWheel.RuName);
        }
    }
}
