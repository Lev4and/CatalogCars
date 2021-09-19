using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IRegionsRepository
    {
        int GetCountRegions(RegionsFilters filters);

        IQueryable<string> GetNamesRegions(string searchString);

        IQueryable<RegionInformation> GetRegions(RegionsFilters filters);
    }
}
