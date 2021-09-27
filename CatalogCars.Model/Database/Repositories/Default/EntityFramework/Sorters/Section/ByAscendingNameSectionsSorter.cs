using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section
{
    public class ByAscendingNameSectionsSorter : ISectionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Section> Sort(IQueryable<Entities.Section> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
