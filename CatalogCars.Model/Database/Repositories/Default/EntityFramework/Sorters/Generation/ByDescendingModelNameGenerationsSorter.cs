using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation
{
    public class ByDescendingModelNameGenerationsSorter : IGenerationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingModelName;

        public IQueryable<Entities.Generation> Sort(IQueryable<Entities.Generation> collection)
        {
            return collection.OrderByDescending(item => item.Model.Name);
        }
    }
}
