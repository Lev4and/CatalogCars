using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IBodyTypesRepository
    {
        bool Contains(Guid bodyTypeGroupId, string name);

        bool Save(ref BodyType entity);

        Guid GetBodyTypeId(Guid bodyTypeGroupId, string name);
    }
}
