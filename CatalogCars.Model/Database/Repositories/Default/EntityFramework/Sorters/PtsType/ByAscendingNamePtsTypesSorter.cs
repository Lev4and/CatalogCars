using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PtsType
{
    public class ByAscendingNamePtsTypesSorter : IPtsTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.PtsType> Sort(IQueryable<Entities.PtsType> collection)
        {
            return collection.OrderBy(item => item.RuName); 
        }
    }
}
