using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.SteeringWheel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFSteeringWheelsRepository : ISteeringWheelsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ISteeringWheelsSorter> _sorters;

        public EFSteeringWheelsRepository(CatalogCarsDbContext context, IEnumerable<ISteeringWheelsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsSteeringWheel(string name, string ruName)
        {
            return _context.SteeringWheels.FirstOrDefault(steeringWheel => steeringWheel.Name == name ||
                steeringWheel.RuName == ruName) != null;
        }

        public void DeleteSteeringWheel(Guid id)
        {
            _context.SteeringWheels.Remove(GetSteeringWheel(id));
            _context.SaveChanges();
        }

        public int GetCountSteeringWheels(SteeringWheelsFilters filters)
        {
            return _context.SteeringWheels
                .Where(steeringWheel => EF.Functions.Like(steeringWheel.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesSteeringWheels(string searchString)
        {
            return _context.SteeringWheels
                .Where(steeringWheel => EF.Functions.Like(steeringWheel.RuName, $"%{searchString}%"))
                .OrderBy(steeringWheel => steeringWheel.RuName)
                .Select(steeringWheel => steeringWheel.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public SteeringWheel GetSteeringWheel(Guid id)
        {
            return _context.SteeringWheels
                .AsNoTracking()
                .FirstOrDefault(steeringWheel => steeringWheel.Id == id);
        }

        public IQueryable<SteeringWheel> GetSteeringWheels(SteeringWheelsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<SteeringWheel> steeringWheels = _context.SteeringWheels
                .Where(steeringWheel => EF.Functions.Like(steeringWheel.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                steeringWheels = sorter.Sort(steeringWheels);
            }

            return steeringWheels
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<SteeringWheel> GetSteeringWheels()
        {
            return _context.SteeringWheels
                .AsNoTracking();
        }

        public bool SaveSteeringWheel(SteeringWheel steeringWheel)
        {
            if (steeringWheel.Id == default)
            {
                if (!ContainsSteeringWheel(steeringWheel.Name, steeringWheel.RuName))
                {
                    _context.Entry(steeringWheel).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetSteeringWheel(steeringWheel.Id);

                if (currentVersion.Name != steeringWheel.Name)
                {
                    if (!ContainsSteeringWheel(steeringWheel.Name, steeringWheel.RuName))
                    {
                        _context.Entry(steeringWheel).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(steeringWheel).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
