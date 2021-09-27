using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Color
{
    public class ByDescendingNameColorsSorter : IColorsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Color> Sort(IQueryable<Entities.Color> collection)
        {
            return collection.OrderByDescending(item => item.Value);
        }
    }
}
