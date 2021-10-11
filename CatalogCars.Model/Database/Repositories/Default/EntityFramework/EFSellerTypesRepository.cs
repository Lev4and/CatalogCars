using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFSellerTypesRepository : ISellerTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ISellerTypesSorter> _sorters;

        public EFSellerTypesRepository(CatalogCarsDbContext context, IEnumerable<ISellerTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountSellerTypes(SellerTypesFilters filters)
        {
            return _context.SellerTypes
                .Where(sellerType => EF.Functions.Like(sellerType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesSellerTypes(string searchString)
        {
            return _context.SellerTypes
                .Where(sellerType => EF.Functions.Like(sellerType.RuName, $"%{searchString}%"))
                .OrderBy(sellerType => sellerType.RuName)
                .Select(sellerType => sellerType.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<SellerType> GetSellerTypes(SellerTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<SellerType> sellerTypes = _context.SellerTypes
                .Where(sellerType => EF.Functions.Like(sellerType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                sellerTypes = sorter.Sort(sellerTypes);
            }

            return sellerTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<SellerType> GetSellerTypes()
        {
            return _context.SellerTypes
                .AsNoTracking();
        }
    }
}
