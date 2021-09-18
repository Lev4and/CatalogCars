using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation
{
    public interface IGenerationsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Generation> Sort(IQueryable<Entities.Generation> generations);
    }
}
