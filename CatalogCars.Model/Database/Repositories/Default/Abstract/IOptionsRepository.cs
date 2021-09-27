using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IOptionsRepository
    {
        int GetCountOptions(OptionsFilters filters);

        IQueryable<string> GetNamesOptions(string searchString);

        IQueryable<Option> GetOptions(OptionsFilters filters);
    }
}
