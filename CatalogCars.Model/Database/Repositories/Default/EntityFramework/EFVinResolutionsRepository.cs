using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.VinResolution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFVinResolutionsRepository : IVinResolutionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IVinResolutionsSorter> _sorters;

        public EFVinResolutionsRepository(CatalogCarsDbContext context, IEnumerable<IVinResolutionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsVinResolution(string name, string ruName)
        {
            return _context.VinResolutions.FirstOrDefault(vinResolution => vinResolution.Name == name ||
                vinResolution.RuName == ruName) != null;
        }

        public void DeleteVinResolution(Guid id)
        {
            _context.VinResolutions.Remove(GetVinResolution(id));
            _context.SaveChanges();
        }

        public int GetCountVinResolutions(VinResolutionsFilters filters)
        {
            return _context.VinResolutions
                .Where(vinResolution => EF.Functions.Like(vinResolution.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesVinResolutions(string searchString)
        {
            return _context.VinResolutions
                .Where(vinResolution => EF.Functions.Like(vinResolution.RuName, $"%{searchString}%"))
                .OrderBy(vinResolution => vinResolution.RuName)
                .Select(vinResolution => vinResolution.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public VinResolution GetVinResolution(Guid id)
        {
            return _context.VinResolutions.FirstOrDefault(vinResolution => vinResolution.Id == id);
        }

        public IQueryable<VinResolution> GetVinResolutions(VinResolutionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<VinResolution> vinResolutions = _context.VinResolutions
                .Where(vinResolution => EF.Functions.Like(vinResolution.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                vinResolutions = sorter.Sort(vinResolutions);
            }

            return vinResolutions
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public bool SaveVinResolution(VinResolution vinResolution)
        {
            if (vinResolution.Id == default)
            {
                if (!ContainsVinResolution(vinResolution.Name, vinResolution.RuName))
                {
                    _context.Entry(vinResolution).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetVinResolution(vinResolution.Id);

                if (currentVersion.Name != vinResolution.Name || currentVersion.RuName != vinResolution.RuName)
                {
                    if (!ContainsVinResolution(vinResolution.Name, vinResolution.RuName))
                    {
                        _context.Entry(vinResolution).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(vinResolution).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
