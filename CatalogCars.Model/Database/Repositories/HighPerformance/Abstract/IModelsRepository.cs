using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IModelsRepository
    {
        bool Contains(Guid markId, string name);

        bool Save(ref Entities.Model entity);

        Guid GetMarkId(Guid markId, string name);
    }
}
