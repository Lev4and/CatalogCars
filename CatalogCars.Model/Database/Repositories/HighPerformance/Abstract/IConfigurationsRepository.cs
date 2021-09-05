using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IConfigurationsRepository
    {
        bool Save(ref Configuration entity);
    }
}
