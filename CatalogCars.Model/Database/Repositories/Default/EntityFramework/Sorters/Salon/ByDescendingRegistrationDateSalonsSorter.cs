using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon
{
    public class ByDescendingRegistrationDateSalonsSorter : ISalonsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingRegistrationDate;

        public IQueryable<Entities.Salon> Sort(IQueryable<Entities.Salon> collection)
        {
            return collection.OrderByDescending(item => item.RegistrationDate);
        }
    }
}
