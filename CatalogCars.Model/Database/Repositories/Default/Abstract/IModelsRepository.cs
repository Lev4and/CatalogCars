using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IModelsRepository
    {
        bool ContainsModel(Guid markId, string name);

        bool SaveModel(Entities.Model model);

        int GetCountModels(ModelsFilters filters);

        int GetCountModelsOfMarks(ModelsFilters filters);

        Entities.Model GetModel(Guid id);

        IQueryable<string> GetNamesModels(string searchString);

        IQueryable<Entities.Model> GetModels(ModelsFilters filters);

        IQueryable<Entities.Model> GetModelsOfMarks(List<Guid> marksIds);

        IQueryable<Entities.Model> GetModelsOfMarks(ModelsFilters filters);

        IQueryable<PopularityModels> GetPopularityModelsOfMark(Guid markId);

        void DeleteModel(Guid id);
    }
}
