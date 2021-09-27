using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.EngineType
{
    public class ByDescendingNameEngineTypesSorter : IEngineTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.EngineType> Sort(IQueryable<Entities.EngineType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
