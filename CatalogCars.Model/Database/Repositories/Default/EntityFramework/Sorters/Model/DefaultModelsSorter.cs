using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public class DefaultModelsSorter : IModelsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
