using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section
{
    public interface ISectionsSorter
    {
        SortingOption SortingOption { get; }

        IQueryable<Entities.Section> Sort(IQueryable<Entities.Section> sections);
    }
}
