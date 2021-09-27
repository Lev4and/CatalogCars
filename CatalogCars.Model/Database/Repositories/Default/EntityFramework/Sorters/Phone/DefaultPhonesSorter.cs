using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Phone
{
    public class DefaultPhonesSorter : IPhonesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.Phone> Sort(IQueryable<Entities.Phone> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
