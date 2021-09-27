using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark
{
    public class ByDescendingNameMarksSorter : IMarksSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Mark> Sort(IQueryable<Entities.Mark> collection)
        {
            return collection.OrderByDescending(item => item.Name);
        }
    }
}
