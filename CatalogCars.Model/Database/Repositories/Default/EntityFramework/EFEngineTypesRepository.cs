using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.EngineType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFEngineTypesRepository : IEngineTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IEngineTypesSorter> _sorters;

        public EFEngineTypesRepository(CatalogCarsDbContext context, IEnumerable<IEngineTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsEngineType(string name, string ruName)
        {
            return _context.EngineTypes.FirstOrDefault(engineType => engineType.Name == name ||
                engineType.RuName == ruName) != null;
        }

        public void DeleteEngineType(Guid id)
        {
            _context.EngineTypes.Remove(GetEngineType(id));
            _context.SaveChanges();
        }

        public int GetCountEngineTypes(EngineTypesFilters filters)
        {
            return _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public EngineType GetEngineType(Guid id)
        {
            return _context.EngineTypes
                .AsNoTracking()
                .FirstOrDefault(engineType => engineType.Id == id);
        }

        public IQueryable<EngineType> GetEngineTypes(EngineTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<EngineType> engineTypes = _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                engineTypes = sorter.Sort(engineTypes);
            }

            return engineTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<EngineType> GetEngineTypes()
        {
            return _context.EngineTypes
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesEngineTypes(string searchString)
        {
            return _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{searchString}%"))
                .OrderBy(engineType => engineType.RuName)
                .Select(engineType => engineType.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveEngineType(EngineType engineType)
        {
            if(engineType.Id == default)
            {
                if(!ContainsEngineType(engineType.Name, engineType.RuName))
                {
                    _context.Entry(engineType).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetEngineType(engineType.Id);

                if(currentVersion.Name != engineType.Name || currentVersion.RuName != engineType.RuName)
                {
                    if (!ContainsEngineType(engineType.Name, engineType.RuName))
                    {
                        _context.Entry(engineType).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(engineType).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
