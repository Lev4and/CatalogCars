using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location
{
    public interface ILocationsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Location> Sort(IQueryable<Entities.Location> locations);
    }
}
