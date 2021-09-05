using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IComplectationsRepository
    {
        bool Save(ref Complectation entity);
    }
}
