using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByDescendingRegionNameSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingRegionName;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderByDescending(item => item.Location.Region.Name);
        }
    }
}
