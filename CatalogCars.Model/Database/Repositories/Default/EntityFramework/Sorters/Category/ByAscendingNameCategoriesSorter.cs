using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category
{
    public class ByAscendingNameCategoriesSorter : ICategoriesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Category> Sort(IQueryable<Entities.Category> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
