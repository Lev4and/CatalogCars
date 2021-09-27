using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PriceSegment
{
    public class ByDescendingNamePriceSegmentsSorter : IPriceSegmentsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.PriceSegment> Sort(IQueryable<Entities.PriceSegment> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
