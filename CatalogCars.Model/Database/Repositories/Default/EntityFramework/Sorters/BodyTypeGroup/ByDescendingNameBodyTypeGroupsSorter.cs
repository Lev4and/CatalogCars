using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyTypeGroup
{
    public class ByDescendingNameBodyTypeGroupsSorter : IBodyTypeGroupsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.BodyTypeGroup> Sort(IQueryable<Entities.BodyTypeGroup> collection)
        {
            return collection.OrderByDescending(item => item.AutoClass);
        }
    }
}
