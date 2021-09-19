using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region
{
    public class ByAscendingNameRegionsSorter : IRegionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<RegionInformation> Sort(IQueryable<RegionInformation> regions)
        {
            return regions.OrderBy(region => region.Name);
        }
    }
}
