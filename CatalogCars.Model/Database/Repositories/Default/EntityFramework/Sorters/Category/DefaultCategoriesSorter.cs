using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category
{
    public class DefaultCategoriesSorter : ICategoriesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Category> Sort(IQueryable<Entities.Category> categories)
        {
            return categories.OrderBy(category => category.Id);
        }
    }
}
