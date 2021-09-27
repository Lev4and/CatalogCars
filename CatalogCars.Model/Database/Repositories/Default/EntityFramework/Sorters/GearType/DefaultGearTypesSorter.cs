using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.GearType
{
    public class DefaultGearTypesSorter : IGearTypesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.GearType> Sort(IQueryable<Entities.GearType> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
