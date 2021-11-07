using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PtsType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPtsTypesRepository : IPtsTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IPtsTypesSorter> _sorters;

        public EFPtsTypesRepository(CatalogCarsDbContext context, IEnumerable<IPtsTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsPtsType(string name, string ruName)
        {
            return _context.PtsTypes.FirstOrDefault(ptsType => ptsType.Name == name ||
                ptsType.RuName == ruName) != null;
        }

        public void DeletePtsType(Guid id)
        {
            _context.PtsTypes.Remove(GetPtsType(id));
            _context.SaveChanges();
        }

        public int GetCountPtsTypes(PtsTypesFilters filters)
        {
            return _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesPtsTypes(string searchString)
        {
            return _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{searchString}%"))
                .OrderBy(ptsType => ptsType.RuName)
                .Select(ptsType => ptsType.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public PtsType GetPtsType(Guid id)
        {
            return _context.PtsTypes.FirstOrDefault(ptsType => ptsType.Id == id);
        }

        public IQueryable<PtsType> GetPtsTypes(PtsTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<PtsType> ptsTypes = _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                ptsTypes = sorter.Sort(ptsTypes);
            }

            return ptsTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public bool SavePtsType(PtsType ptsType)
        {
            if(ptsType.Id == default)
            {
                if(!ContainsPtsType(ptsType.Name, ptsType.RuName))
                {
                    _context.Entry(ptsType).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetPtsType(ptsType.Id);

                if(currentVersion.Name != ptsType.Name || currentVersion.RuName != ptsType.RuName)
                {
                    if (!ContainsPtsType(ptsType.Name, ptsType.RuName))
                    {
                        _context.Entry(ptsType).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(ptsType).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
