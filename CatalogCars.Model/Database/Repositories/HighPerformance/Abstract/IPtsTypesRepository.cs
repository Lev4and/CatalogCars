using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPtsTypesRepository
    {
        bool Contains(string name);

        bool Save(ref PtsType entity);

        Guid GetPtsTypeId(string name);
    }
}
