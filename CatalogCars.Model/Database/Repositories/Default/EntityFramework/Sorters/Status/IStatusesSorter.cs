using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status
{
    public interface IStatusesSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Status> Sort(IQueryable<Entities.Status> statuses);
    }
}
