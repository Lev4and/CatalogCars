using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.EngineType
{
    public class DefaultEngineTypesSorter : IEngineTypesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.EngineType> Sort(IQueryable<Entities.EngineType> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
