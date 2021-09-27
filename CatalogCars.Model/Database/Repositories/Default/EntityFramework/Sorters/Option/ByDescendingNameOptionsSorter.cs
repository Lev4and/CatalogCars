using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Option
{
    public class ByDescendingNameOptionsSorter : IOptionsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Option> Sort(IQueryable<Entities.Option> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
