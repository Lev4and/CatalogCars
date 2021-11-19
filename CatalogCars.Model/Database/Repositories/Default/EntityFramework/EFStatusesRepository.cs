using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFStatusesRepository : IStatusesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IStatusesSorter> _sorters;

        public EFStatusesRepository(CatalogCarsDbContext context, IEnumerable<IStatusesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsStatus(string name, string ruName)
        {
            return _context.Statuses.FirstOrDefault(status => status.Name == name ||
                status.RuName == ruName) != null;
        }

        public void DeleteStatus(Guid id)
        {
            _context.Statuses.Remove(GetStatus(id));
            _context.SaveChanges();
        }

        public int GetCountStatuses(StatusesFilters filters)
        {
            return _context.Statuses
                .Where(status => EF.Functions.Like(status.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesStatuses(string searchString)
        {
            return _context.Statuses
                .Where(status => EF.Functions.Like(status.RuName, $"%{searchString}%"))
                .OrderBy(status => status.RuName)
                .Select(status => status.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public Status GetStatus(Guid id)
        {
            return _context.Statuses
                .AsNoTracking()
                .FirstOrDefault(status => status.Id == id);
        }

        public IQueryable<Status> GetStatuses(StatusesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Status> statuses = _context.Statuses
                .Where(status => EF.Functions.Like(status.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                statuses = sorter.Sort(statuses);
            }

            return statuses
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Status> GetStatuses()
        {
            return _context.Statuses
                .AsNoTracking();
        }

        public bool SaveStatus(Status status)
        {
            if (status.Id == default)
            {
                if (!ContainsStatus(status.Name, status.RuName))
                {
                    _context.Entry(status).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetStatus(status.Id);

                if (currentVersion.Name != status.Name)
                {
                    if (!ContainsStatus(status.Name, status.RuName))
                    {
                        _context.Entry(status).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(status).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
