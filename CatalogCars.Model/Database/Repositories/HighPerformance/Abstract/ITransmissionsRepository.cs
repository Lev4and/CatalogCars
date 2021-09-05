using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ITransmissionsRepository
    {
        bool Contains(string name);

        bool Save(ref Transmission entity);

        Guid GetTransmissionId(string name);
    }
}
