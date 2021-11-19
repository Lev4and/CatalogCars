using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SellerType;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool ContainsSellerType(string name, string ruName)
        {
            return _context.SellerTypes.FirstOrDefault(sellerType => sellerType.Name == name ||
                sellerType.RuName == ruName) != null;
        }

        public void DeleteSellerType(Guid id)
        {
            _context.SellerTypes.Remove(GetSellerType(id));
            _context.SaveChanges();
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

        public SellerType GetSellerType(Guid id)
        {
            return _context.SellerTypes
                .AsNoTracking()
                .FirstOrDefault(sellerType => sellerType.Id == id);
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

        public bool SaveSellerType(SellerType sellerType)
        {
            if(sellerType.Id == default)
            {
                if (!ContainsSellerType(sellerType.Name, sellerType.RuName))
                {
                    _context.Entry(sellerType).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetSellerType(sellerType.Id);

                if (currentVersion.Name != sellerType.Name)
                {
                    if (!ContainsSellerType(sellerType.Name, sellerType.RuName))
                    {
                        _context.Entry(sellerType).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(sellerType).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
