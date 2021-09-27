using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag
{
    public class DefaultTagsSorter : ITagsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Tag> Sort(IQueryable<Entities.Tag> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
