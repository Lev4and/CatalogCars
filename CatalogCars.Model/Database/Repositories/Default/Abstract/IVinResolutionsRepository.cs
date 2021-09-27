using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IVinResolutionsRepository
    {
        int GetCountVinResolutions(VinResolutionsFilters filters);

        IQueryable<string> GetNamesVinResolutions(string searchString);

        IQueryable<VinResolution> GetVinResolutions(VinResolutionsFilters filters);
    }
}
