using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IColorsRepository
    {
        bool Contains(string value);

        bool Save(ref Color entity);

        Guid GetColorId(string value);
    }
}
