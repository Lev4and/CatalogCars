using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByAscendingRegistrationDateSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingRegistrationDate;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderBy(item => item.RegistrationDate);
        }
    }
}
