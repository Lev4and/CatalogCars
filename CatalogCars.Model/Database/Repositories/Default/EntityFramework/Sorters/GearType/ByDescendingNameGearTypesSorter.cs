using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.GearType
{
    public class ByDescendingNameGearTypesSorter : IGearTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.GearType> Sort(IQueryable<Entities.GearType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
