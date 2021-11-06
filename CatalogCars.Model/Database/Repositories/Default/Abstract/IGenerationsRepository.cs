using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IGenerationsRepository
    {
        bool ContainsGeneration(Guid modelId, int? yearFrom, string name);

        bool SaveGeneration(Generation generation);

        int? GetMinYearFromGeneration();

        int? GetMaxYearFromGeneration();

        int GetCountGenerations(GenerationsFilters filters);

        int GetCountGenerationsOfModels(GenerationsFilters filters);

        Generation GetGeneration(Guid id);

        IQueryable<string> GetNamesGenerations(string searchString);

        IQueryable<Generation> GetGenerations(GenerationsFilters filters);

        IQueryable<Generation> GetGenerationsOfModels(GenerationsFilters filters);

        void DeleteGeneration(Guid id);
    }
}
