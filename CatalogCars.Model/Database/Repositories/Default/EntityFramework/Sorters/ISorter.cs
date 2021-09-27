using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters
{
    public interface ISorter<T> where T : class
    {
        SortingOption SortingOption { get; }

        IQueryable<T> Sort(IQueryable<T> collection);
    }
}
