using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.VinResolution
{
    public class DefaultVinResolutionsSorter : IVinResolutionsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.VinResolution> Sort(IQueryable<Entities.VinResolution> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
