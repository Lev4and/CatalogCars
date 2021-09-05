using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ITagsRepository
    {
        bool Contains(string name);

        bool Save(ref Tag entity);

        Guid GetTagId(string name);
    }
}
