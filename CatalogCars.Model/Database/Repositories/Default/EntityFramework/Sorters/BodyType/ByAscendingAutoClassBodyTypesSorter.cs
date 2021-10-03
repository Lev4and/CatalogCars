using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType
{
    public class ByAscendingAutoClassBodyTypesSorter : IBodyTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingAutoClass;

        public IQueryable<Entities.BodyType> Sort(IQueryable<Entities.BodyType> collection)
        {
            return collection.OrderBy(item => item.BodyTypeGroup.AutoClass);
        }
    }
}
