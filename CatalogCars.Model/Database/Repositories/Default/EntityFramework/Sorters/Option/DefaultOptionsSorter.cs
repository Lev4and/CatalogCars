using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Option
{
    public class DefaultOptionsSorter : IOptionsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Option> Sort(IQueryable<Entities.Option> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
