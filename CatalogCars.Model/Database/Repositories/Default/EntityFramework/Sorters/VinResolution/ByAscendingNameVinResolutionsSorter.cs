using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.VinResolution
{
    public class ByAscendingNameVinResolutionsSorter : IVinResolutionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.VinResolution> Sort(IQueryable<Entities.VinResolution> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
