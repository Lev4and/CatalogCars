using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVendorsRepository
    {
        bool Contains(string name);

        bool Save(ref Vendor entity);

        Guid GetVendorId(string name);
    }
}
