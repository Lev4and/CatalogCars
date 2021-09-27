using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region
{
    public class DefaultRegionsSorter : IRegionsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<RegionInformation> Sort(IQueryable<RegionInformation> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
