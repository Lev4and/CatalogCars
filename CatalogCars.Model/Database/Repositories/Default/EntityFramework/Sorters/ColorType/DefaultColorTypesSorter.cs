using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.ColorType
{
    public class DefaultColorTypesSorter : IColorTypesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.ColorType> Sort(IQueryable<Entities.ColorType> collection)
        {
            return collection.OrderBy(item => item.RuName);
        }
    }
}
