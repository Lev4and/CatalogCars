using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.GearType
{
    public class ByAscendingNameGearTypesSorter : IGearTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.GearType> Sort(IQueryable<Entities.GearType> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
