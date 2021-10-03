using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public class ByAscendingMarkNameModelsSorter : IModelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingMarkName;

        public IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> collection)
        {
            return collection.OrderBy(item => item.Mark.Name);
        }
    }
}
