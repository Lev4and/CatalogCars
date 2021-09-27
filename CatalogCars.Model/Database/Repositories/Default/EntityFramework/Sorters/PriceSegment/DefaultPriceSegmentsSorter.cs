using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PriceSegment
{
    public class DefaultPriceSegmentsSorter : IPriceSegmentsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.PriceSegment> Sort(IQueryable<Entities.PriceSegment> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
