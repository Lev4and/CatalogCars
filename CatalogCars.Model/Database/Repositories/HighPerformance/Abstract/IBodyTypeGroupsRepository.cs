using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IBodyTypeGroupsRepository
    {
        bool Contains(string name);

        bool Save(ref BodyTypeGroup entity);

        Guid GetBodyTypeGroupId(string name);
    }
}
