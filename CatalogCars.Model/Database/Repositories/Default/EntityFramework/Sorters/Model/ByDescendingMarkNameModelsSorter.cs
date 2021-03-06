using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public class ByDescendingMarkNameModelsSorter : IModelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingMarkName;

        public IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> collection)
        {
            return collection.OrderByDescending(item => item.Mark.Name);
        }
    }
}
