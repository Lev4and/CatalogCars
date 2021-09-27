using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPtsTypesRepository
    {
        int GetCountPtsTypes(PtsTypesFilters filters);

        IQueryable<string> GetNamesPtsTypes(string searchString);

        IQueryable<PtsType> GetPtsTypes(PtsTypesFilters filters);
    }
}
