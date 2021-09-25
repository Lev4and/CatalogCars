using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel
{
    public class DefaultSteeringWheelsSorter : ISteeringWheelsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.SteeringWheel> Sort(IQueryable<Entities.SteeringWheel> steeringWheels)
        {
            return steeringWheels.OrderBy(steeringWheel => steeringWheel.Id);
        }
    }
}
