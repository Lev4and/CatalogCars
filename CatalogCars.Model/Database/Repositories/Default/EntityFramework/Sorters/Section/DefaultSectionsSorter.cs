using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section
{
    public class DefaultSectionsSorter : ISectionsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Section> Sort(IQueryable<Entities.Section> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
