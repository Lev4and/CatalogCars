using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByDescendingNameSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderByDescending(item => item.Name);
        }
    }
}
