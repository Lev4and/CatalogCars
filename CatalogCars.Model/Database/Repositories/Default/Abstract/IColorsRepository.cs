using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IColorsRepository
    {
        bool ContainsColor(string value);

        bool SaveColor(Color color);

        int GetCountColors(ColorsFilters filters);

        Color GetColor(Guid id);

        IQueryable<string> GetNamesColors(string searchString);

        IQueryable<Color> GetColors(ColorsFilters filters);

        void DeleteColor(Guid id);
    }
}
