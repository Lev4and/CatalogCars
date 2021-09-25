using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISectionsRepository
    {
        int GetCountSections(SectionsFilters filters);

        IQueryable<string> GetNamesSections(string searchString);

        IQueryable<Section> GetSections(SectionsFilters filters);
    }
}
