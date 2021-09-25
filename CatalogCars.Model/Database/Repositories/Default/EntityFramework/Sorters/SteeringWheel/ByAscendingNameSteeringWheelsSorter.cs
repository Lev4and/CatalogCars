using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel
{
    public class ByAscendingNameSteeringWheelsSorter : ISteeringWheelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.SteeringWheel> Sort(IQueryable<Entities.SteeringWheel> steeringWheels)
        {
            return steeringWheels.OrderBy(steeringWheel => steeringWheel.RuName);
        }
    }
}
