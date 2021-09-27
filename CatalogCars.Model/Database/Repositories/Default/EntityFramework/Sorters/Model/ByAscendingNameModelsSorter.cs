using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public class ByAscendingNameModelsSorter : IModelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> collection)
        {
            return collection.OrderBy(item => item.Name);
        }
    }
}
