using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType
{
    public class ByAscendingNameBodyTypesSorter : IBodyTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.BodyType> Sort(IQueryable<Entities.BodyType> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
