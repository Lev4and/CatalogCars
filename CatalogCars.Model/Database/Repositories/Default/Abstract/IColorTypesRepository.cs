using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IColorTypesRepository
    {
        bool ContainsColorType(string name, string ruName);

        bool SaveColorType(ColorType colorType);

        int GetCountColorTypes(ColorTypesFilters filters);

        ColorType GetColorType(Guid id);

        IQueryable<string> GetNamesColorTypes(string searchString);

        IQueryable<ColorType> GetColorTypes(ColorTypesFilters filters);

        void DeleteColorType(Guid id);
    }
}
