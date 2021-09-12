using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark
{
    public interface IMarksSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Mark> Sort(IQueryable<Entities.Mark> marks);
    }
}
