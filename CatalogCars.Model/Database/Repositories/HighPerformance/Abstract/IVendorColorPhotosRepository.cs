using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVendorColorPhotosRepository
    {
        bool Contains(Guid vendorColorId, string name);

        bool Save(ref VendorColorPhoto entity);

        Guid GetVendorColorPhotoId(Guid vendorColorId, string name);
    }
}
