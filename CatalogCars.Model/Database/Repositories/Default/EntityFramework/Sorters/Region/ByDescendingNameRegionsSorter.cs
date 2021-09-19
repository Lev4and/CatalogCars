using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region
{
    public class ByDescendingNameRegionsSorter : IRegionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<RegionInformation> Sort(IQueryable<RegionInformation> regions)
        {
            return regions.OrderByDescending(region => region.Name);
        }
    }
}
