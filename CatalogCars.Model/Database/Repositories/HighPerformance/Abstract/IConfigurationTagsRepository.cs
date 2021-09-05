using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IConfigurationTagsRepository
    {
        bool Contains(Guid configurationId, Guid tagId);

        bool Save(ref ConfigurationTag entity);
    }
}
