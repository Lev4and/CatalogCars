using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PriceSegment
{
    public class ByAscendingNamePriceSegmentsSorter : IPriceSegmentsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.PriceSegment> Sort(IQueryable<Entities.PriceSegment> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
