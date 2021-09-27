using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.ColorType
{
    public class ByAscendingNameColorTypesSorter : IColorTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.ColorType> Sort(IQueryable<Entities.ColorType> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
