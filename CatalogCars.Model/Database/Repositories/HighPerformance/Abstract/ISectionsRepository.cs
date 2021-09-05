using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ISectionsRepository
    {
        bool Contains(string name);

        bool Save(ref Section entity);

        Guid GetSectionId(string name);
    }
}
