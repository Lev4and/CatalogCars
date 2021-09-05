using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISalonsRepository
    {
        bool Contains(Guid locationId, string name);

        bool Save(ref Salon entity);

        Guid GetSalonId(Guid locationId, string name);
    }
}
