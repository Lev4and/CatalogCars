using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IAvailabilitiesRepository
    {
        bool Contains(string name);

        bool Save(ref Availability entity);

        Guid GetAvailabilityId(string name);
    }
}
