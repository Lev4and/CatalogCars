using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPhonesRepository
    {
        bool Contains(string value);

        bool Save(ref Phone entity);

        Guid GetPhoneId(string value);
    }
}
