using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Phone
{
    public class ByDescendingNamePhonesSorter : IPhonesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Phone> Sort(IQueryable<Entities.Phone> collection)
        {
            return collection.OrderByDescending(item => item.Value);
        }
    }
}
