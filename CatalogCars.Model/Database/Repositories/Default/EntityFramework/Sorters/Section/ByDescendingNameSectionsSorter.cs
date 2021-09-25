using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section
{
    public class ByDescendingNameSectionsSorter : ISectionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Section> Sort(IQueryable<Entities.Section> sections)
        {
            return sections.OrderByDescending(sorter => sorter.RuName);
        }
    }
}
