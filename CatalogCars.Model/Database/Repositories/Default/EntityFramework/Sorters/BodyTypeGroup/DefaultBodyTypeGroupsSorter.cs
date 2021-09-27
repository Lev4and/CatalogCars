using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyTypeGroup
{
    public class DefaultBodyTypeGroupsSorter : IBodyTypeGroupsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.BodyTypeGroup> Sort(IQueryable<Entities.BodyTypeGroup> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
