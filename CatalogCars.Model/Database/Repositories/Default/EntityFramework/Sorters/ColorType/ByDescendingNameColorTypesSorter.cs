using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.ColorType
{
    public class ByDescendingNameColorTypesSorter : IColorTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.ColorType> Sort(IQueryable<Entities.ColorType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
