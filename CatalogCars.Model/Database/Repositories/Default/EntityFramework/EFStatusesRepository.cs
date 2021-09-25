using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Status;
using Microsoft.EntityFrameworkCore;
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
                .Select(status => status.RuName);
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
    }
}
