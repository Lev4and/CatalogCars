using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation
{
    public class ByAscendingYearFromGenerationsSorter : IGenerationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingYearFrom;

        public IQueryable<Entities.Generation> Sort(IQueryable<Entities.Generation> collection)
        {
            return collection.OrderBy(item => item.YearFrom);
        }
    }
}
