using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVinResolutionsRepository
    {
        bool Contains(string name);

        bool Save(ref VinResolution entity);

        Guid GetVinResolutionId(string name);
    }
}
