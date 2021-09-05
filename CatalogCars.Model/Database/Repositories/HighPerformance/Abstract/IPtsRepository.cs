using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPtsRepository
    {
        bool Save(ref Pts entity);
    }
}
