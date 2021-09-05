using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IStatusesRepository
    {
        bool Contains(string name);

        bool Save(ref Status entity);

        Guid GetStatusId(string name);
    }
}
