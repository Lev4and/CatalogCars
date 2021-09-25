using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category
{
    public class ByDescendingNameCategoriesSorter : ICategoriesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Category> Sort(IQueryable<Entities.Category> categories)
        {
            return categories.OrderByDescending(category => category.RuName);
        }
    }
}
