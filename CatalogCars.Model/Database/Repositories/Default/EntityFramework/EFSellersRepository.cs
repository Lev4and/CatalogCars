using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Seller;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFSellersRepository : ISellersRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ISellersSorter> _sorters;

        public EFSellersRepository(CatalogCarsDbContext context, IEnumerable<ISellersSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsSeller(Guid locationId)
        {
            return _context.Sellers.FirstOrDefault(seller => 
                seller.LocationId == locationId) != null;
        }

        public void DeleteSeller(Guid id)
        {
            _context.Sellers.Remove(GetSeller(id));
            _context.SaveChanges();
        }

        public int GetCountSellers(SellersFilters filters)
        {
            return _context.Sellers
                .Include(seller => seller.Location)
                    .ThenInclude(location => location.Region)
                .Where(seller => EF.Functions.Like(seller.Name, $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)seller.Location.RegionId) : true))
                .Count();
        }

        public IQueryable<string> GetNamesSellers(string searchString)
        {
            return _context.Sellers
                .Where(seller => EF.Functions.Like(seller.Name, $"%{searchString}%"))
                .OrderBy(seller => seller.Name)
                .Select(seller => seller.Name)
                .Take(5)
                .AsNoTracking();
        }

        public Seller GetSeller(Guid id)
        {
            return _context.Sellers
                .Include(seller => seller.Phones)
                    .ThenInclude(phone => phone.Phone)
                .Include(seller => seller.Location)
                    .ThenInclude(location => location.Region)
                .AsNoTracking()
                .FirstOrDefault(seller => seller.Id == id);
        }

        public IQueryable<Seller> GetSellers(SellersFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Seller> sellers = _context.Sellers
                .Include(seller => seller.Location)
                    .ThenInclude(location => location.Region)
                .Where(seller => EF.Functions.Like(seller.Name, $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)seller.Location.RegionId) : true));

            if(sorter != null)
            {
                sellers = sorter.Sort(sellers);
            }

            return sellers
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public bool SaveSeller(Seller seller)
        {
            if (seller.Id == default)
            {
                if (!ContainsSeller(seller.LocationId))
                {
                    _context.Entry(seller).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetSeller(seller.Id);

                if (currentVersion.LocationId != seller.LocationId)
                {
                    if (!ContainsSeller(seller.LocationId))
                    {
                        _context.Entry(seller).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(seller).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
