using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public interface IModelsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> models);
    }
}
