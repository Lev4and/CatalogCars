using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IGenerationsRepository
    {
        int? GetMinYearFromGeneration();

        int? GetMaxYearFromGeneration();

        int GetCountGenerations(GenerationsFilters filters);

        IQueryable<string> GetNamesGenerations(string searchString);

        IQueryable<Generation> GetGenerations(GenerationsFilters filters);
    }
}
