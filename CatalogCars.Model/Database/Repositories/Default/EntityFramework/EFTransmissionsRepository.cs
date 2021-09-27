using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFTransmissionsRepository : ITransmissionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ITransmissionsSorter> _sorters;

        public EFTransmissionsRepository(CatalogCarsDbContext context, IEnumerable<ITransmissionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountTransmissions(TransmissionsFilters filters)
        {
            return _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesTransmissions(string searchString)
        {
            return _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{searchString}%"))
                .OrderBy(transmission => transmission.RuName)
                .Select(transmission => transmission.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Transmission> GetTransmissions(TransmissionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Transmission> transmissions = _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                transmissions = sorter.Sort(transmissions);
            }

            return transmissions
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
