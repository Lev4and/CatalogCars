using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation
{
    public class DefaultGenerationsSorter : IGenerationsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Generation> Sort(IQueryable<Entities.Generation> generations)
        {
            return generations.OrderBy(generation => generation.Id);
        }
    }
}
