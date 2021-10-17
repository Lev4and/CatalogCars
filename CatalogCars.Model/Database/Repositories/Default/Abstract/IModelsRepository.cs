using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IModelsRepository
    {
        int GetCountModels(ModelsFilters filters);

        int GetCountModelsOfMarks(ModelsFilters filters);

        IQueryable<string> GetNamesModels(string searchString);

        IQueryable<Entities.Model> GetModels(ModelsFilters filters);

        IQueryable<Entities.Model> GetModelsOfMarks(ModelsFilters filters);

        IQueryable<PopularityModels> GetPopularityModelsOfMark(Guid markId);
    }
}
