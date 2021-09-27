using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Color
{
    public class DefaultColorsSorter : IColorsSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Color> Sort(IQueryable<Entities.Color> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
