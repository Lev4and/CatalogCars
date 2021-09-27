using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.VinResolution
{
    public class ByDescendingNameVinResolutionsSorter : IVinResolutionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.VinResolution> Sort(IQueryable<Entities.VinResolution> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
