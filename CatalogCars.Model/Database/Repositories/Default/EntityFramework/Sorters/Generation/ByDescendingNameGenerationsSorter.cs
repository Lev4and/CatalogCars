using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation
{
    public class ByDescendingNameGenerationsSorter : IGenerationsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Generation> Sort(IQueryable<Entities.Generation> generations)
        {
            return generations.OrderByDescending(generation => generation.Name);
        }
    }
}
