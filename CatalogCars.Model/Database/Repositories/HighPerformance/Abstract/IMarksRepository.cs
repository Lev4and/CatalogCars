using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IMarksRepository
    {
        bool Contains(string name);

        bool Save(ref Mark entity);

        Guid GetMarkId(string name);
    }
}
