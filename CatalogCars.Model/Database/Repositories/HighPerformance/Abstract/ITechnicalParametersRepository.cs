using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ITechnicalParametersRepository
    {
        bool Save(ref TechnicalParameters entity);
    }
}
