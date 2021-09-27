using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag
{
    public class ByAscendingNameTagsSorter : ITagsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Tag> Sort(IQueryable<Entities.Tag> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
