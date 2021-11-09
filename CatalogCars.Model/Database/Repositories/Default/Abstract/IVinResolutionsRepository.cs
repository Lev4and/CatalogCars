using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IVinResolutionsRepository
    {
        bool ContainsVinResolution(string name, string ruName);

        bool SaveVinResolution(VinResolution vinResolution);

        int GetCountVinResolutions(VinResolutionsFilters filters);

        VinResolution GetVinResolution(Guid id);

        IQueryable<string> GetNamesVinResolutions(string searchString);

        IQueryable<VinResolution> GetVinResolutions(VinResolutionsFilters filters);

        void DeleteVinResolution(Guid id);
    }
}
