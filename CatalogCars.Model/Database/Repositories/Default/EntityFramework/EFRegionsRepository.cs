using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Region;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFRegionsRepository : IRegionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IRegionsSorter> _sorters; 

        public EFRegionsRepository(CatalogCarsDbContext context, IEnumerable<IRegionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsRegion(string stringId)
        {
            return _context.Regions.FirstOrDefault(region => region.StringId == stringId) != null;
        }

        public void DeleteRegion(Guid id)
        {
            _context.Regions.Remove(GetRegion(id));
            _context.SaveChanges();
        }

        public int GetCountRegions(RegionsFilters filters)
        {
            return _context.Regions
                .Where(region => EF.Functions.Like(region.Name, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesRegions(string searchString)
        {
            return _context.Regions
                .Where(region => EF.Functions.Like(region.Name, $"%{searchString}%"))
                .OrderBy(region => region.Name)
                .Select(region => region.Name)
                .Take(5)
                .AsNoTracking();
        }

        public RegionInformation GetRegion(Guid id)
        {
            return _context.Regions.FirstOrDefault(region => region.Id == id);
        }

        public IQueryable<RegionInformation> GetRegions(RegionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<RegionInformation> regions = _context.Regions
                .Where(region => EF.Functions.Like(region.Name, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                regions = sorter.Sort(regions);
            }

            return regions
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public bool SaveRegion(RegionInformation region)
        {
            if(region.Id == default)
            {
                if (!ContainsRegion(region.StringId))
                {
                    _context.Entry(region).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetRegion(region.Id);

                if(currentVersion.StringId != region.StringId)
                {
                    if (!ContainsRegion(region.StringId))
                    {
                        _context.Entry(region).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(region).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
