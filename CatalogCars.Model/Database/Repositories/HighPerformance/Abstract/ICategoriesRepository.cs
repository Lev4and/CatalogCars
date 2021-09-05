using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface ICategoriesRepository
    {
        bool Contains(string name);

        bool Save(ref Category entity);

        Guid GetCategoryId(string name);
    }
}
