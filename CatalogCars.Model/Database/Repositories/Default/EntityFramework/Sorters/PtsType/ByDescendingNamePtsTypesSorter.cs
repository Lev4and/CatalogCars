using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PtsType
{
    public class ByDescendingNamePtsTypesSorter : IPtsTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.PtsType> Sort(IQueryable<Entities.PtsType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
