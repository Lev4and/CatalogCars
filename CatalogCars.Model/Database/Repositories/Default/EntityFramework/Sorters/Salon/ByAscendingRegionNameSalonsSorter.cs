using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByAscendingRegionNameSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingRegionName;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderBy(item => item.Location.Region.Name);
        }
    }
}
