using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IColorTypesRepository
    {
        bool Contains(string name);

        bool Save(ref ColorType entity);

        Guid GetColorTypeId(string name);
    }
}
