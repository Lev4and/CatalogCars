using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IVendorsRepository
    {
        int GetCountVendors(VendorsFilters filters);

        IQueryable<string> GetNamesVendors(string searchString);

        IQueryable<Vendor> GetVendors(VendorsFilters filters);
    }
}
