using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IColorTypesRepository
    {
        int GetCountColorTypes(ColorTypesFilters filters);

        IQueryable<string> GetNamesColorTypes(string searchString);

        IQueryable<ColorType> GetColorTypes(ColorTypesFilters filters);
    }
}
