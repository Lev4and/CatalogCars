using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IColorsRepository
    {
        int GetCountColors(ColorsFilters filters);

        IQueryable<string> GetNamesColors(string searchString);

        IQueryable<Color> GetColors(ColorsFilters filters);
    }
}
