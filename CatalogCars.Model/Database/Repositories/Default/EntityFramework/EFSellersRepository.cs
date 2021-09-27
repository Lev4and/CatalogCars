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
    }
}
