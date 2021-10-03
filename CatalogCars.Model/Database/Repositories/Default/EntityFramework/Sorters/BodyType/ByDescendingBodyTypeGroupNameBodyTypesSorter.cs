using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType
{
    public class ByDescendingBodyTypeGroupNameBodyTypesSorter : IBodyTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingBodyTypeGroupName;

        public IQueryable<Entities.BodyType> Sort(IQueryable<Entities.BodyType> collection)
        {
            return collection.OrderByDescending(item => item.BodyTypeGroup.RuName);
        }
    }
}
