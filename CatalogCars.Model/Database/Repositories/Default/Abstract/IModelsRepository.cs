using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IModelsRepository
    {
        int GetCountModels(ModelsFilters filters);

        IQueryable<string> GetNamesModels(string searchString);

        IQueryable<Entities.Model> GetModels(ModelsFilters filters);
    }
}
