using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVendorColorsRepository
    {
        bool Contains(Guid complectationId, string name);

        bool Save(ref VendorColor entity);

        Guid GetVendorColorId(Guid complectationId, string name);
    }
}
