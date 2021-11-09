using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IRegionsRepository
    {
        bool ContainsRegion(string stringId);

        bool SaveRegion(RegionInformation region);

        int GetCountRegions(RegionsFilters filters);

        RegionInformation GetRegion(Guid id);

        IQueryable<string> GetNamesRegions(string searchString);

        IQueryable<RegionInformation> GetRegions(RegionsFilters filters);

        void DeleteRegion(Guid id);
    }
}
