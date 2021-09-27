using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag
{
    public class ByDescendingNameTagsSorter : ITagsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Tag> Sort(IQueryable<Entities.Tag> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
