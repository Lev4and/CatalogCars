using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Vendor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFVendorsRepository : IVendorsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IVendorsSorter> _sorters;

        public EFVendorsRepository(CatalogCarsDbContext context, IEnumerable<IVendorsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsVendor(string name, string ruName)
        {
            return _context.Vendors.FirstOrDefault(vendor => vendor.Name == name ||
                vendor.RuName == ruName) != null;
        }

        public void DeleteVendor(Guid id)
        {
            _context.Vendors.Remove(GetVendor(id));
            _context.SaveChanges();
        }

        public int GetCountVendors(VendorsFilters filters)
        {
            return _context.Vendors
                .Where(vendor => EF.Functions.Like(vendor.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesVendors(string searchString)
        {
            return _context.Vendors
                .Where(vendor => EF.Functions.Like(vendor.RuName, $"%{searchString}%"))
                .OrderBy(vendor => vendor.RuName)
                .Select(vendor => vendor.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public Vendor GetVendor(Guid id)
        {
            return _context.Vendors
                .AsNoTracking()
                .FirstOrDefault(vendor => vendor.Id == id);
        }

        public IQueryable<Vendor> GetVendors(VendorsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Vendor> vendors = _context.Vendors
                .Where(vendor => EF.Functions.Like(vendor.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                vendors = sorter.Sort(vendors);
            }

            return vendors
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Vendor> GetVendors()
        {
            return _context.Vendors
                .OrderBy(vendor => vendor.RuName)
                .AsNoTracking();
        }

        public bool SaveVendor(Vendor vendor)
        {
            if (vendor.Id == default)
            {
                if (!ContainsVendor(vendor.Name, vendor.RuName))
                {
                    _context.Entry(vendor).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetVendor(vendor.Id);

                if (currentVersion.Name != vendor.Name)
                {
                    if (!ContainsVendor(vendor.Name, vendor.RuName))
                    {
                        _context.Entry(vendor).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(vendor).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
