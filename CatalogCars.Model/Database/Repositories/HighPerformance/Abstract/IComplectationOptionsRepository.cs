using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IComplectationOptionsRepository
    {
        bool Contains(Guid complectationId, Guid optionId);

        bool Save(ref ComplectationOption entity);
    }
}
