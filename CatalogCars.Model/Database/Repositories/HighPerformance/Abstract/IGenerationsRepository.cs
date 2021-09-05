using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IGenerationsRepository
    {
        bool Contains(Guid modelId, int yearFrom, string name);

        bool Save(ref Generation entity);

        Guid GetGenerationId(Guid modelId, int yearFrom, string name);
    }
}
