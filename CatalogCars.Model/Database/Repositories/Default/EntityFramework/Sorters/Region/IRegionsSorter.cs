using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region
{
    public interface IRegionsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.RegionInformation> Sort(IQueryable<Entities.RegionInformation> regions);
    }
}
