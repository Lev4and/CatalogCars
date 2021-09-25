using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category
{
    public interface ICategoriesSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Category> Sort(IQueryable<Entities.Category> categories);
    }
}
