using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Availability;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFAvailabilitiesRepository : IAvailabilitiesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IAvailabilitiesSorter> _sorters;

        public EFAvailabilitiesRepository(CatalogCarsDbContext context, IEnumerable<IAvailabilitiesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<Availability> GetAvailabilities(AvailabilitiesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Availability> availabilities = _context.Availabilities
                .Where(availability => EF.Functions.Like(availability.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                availabilities = sorter.Sort(availabilities);
            }

            return availabilities
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountAvailabilities(AvailabilitiesFilters filters)
        {
            return _context.Availabilities
                .Where(availability => EF.Functions.Like(availability.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesAvailabilities(string searchString)
        {
            return _context.Availabilities
                .Where(availability => EF.Functions.Like(availability.RuName, $"%{searchString}%"))
                .OrderBy(availability => availability.RuName)
                .Select(availability => availability.RuName)
                .Take(5)
                .AsNoTracking();
        }
    }
}
