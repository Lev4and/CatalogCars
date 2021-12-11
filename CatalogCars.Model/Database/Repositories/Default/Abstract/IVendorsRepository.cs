using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IVendorsRepository
    {
        bool ContainsVendor(string name, string ruName);

        bool SaveVendor(Vendor vendor);

        int GetCountVendors(VendorsFilters filters);

        Vendor GetVendor(Guid id);

        IQueryable<string> GetNamesVendors(string searchString);

        IQueryable<Vendor> GetVendors();

        IQueryable<Vendor> GetVendors(VendorsFilters filters);

        void DeleteVendor(Guid id);
    }
}
