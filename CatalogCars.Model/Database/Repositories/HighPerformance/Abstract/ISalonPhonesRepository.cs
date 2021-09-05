using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISalonPhonesRepository
    {
        bool Contains(Guid salonId, Guid phoneId);

        bool Save(ref SalonPhone entity);
    }
}
