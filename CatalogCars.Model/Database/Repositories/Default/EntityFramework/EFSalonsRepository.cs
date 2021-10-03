using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Salon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFSalonsRepository : ISalonsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ISalonsSorter> _sorters;

        public EFSalonsRepository(CatalogCarsDbContext context, IEnumerable<ISalonsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountSalons(SalonsFilters filters)
        {
            return _context.Salons
                .Include(salon => salon.Location)
                    .ThenInclude(location => location.Region)
                .Where(salon => EF.Functions.Like(salon.Name, $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)salon.Location.RegionId) : true) &&
                        salon.RegistrationDate >= filters.RangeRegistrationDate.From &&
                            salon.RegistrationDate <= filters.RangeRegistrationDate.To &&
                                (filters.IsOfficial != null ? salon.IsOfficial == filters.IsOfficial : true) &&
                                    (filters.ActualStock != null ? salon.ActualStock == filters.ActualStock : true) &&
                                        (filters.LoyaltyProgram != null ? salon.LoyaltyProgram == filters.LoyaltyProgram : true))
                .Count();
        }

        public DateTime GetMaxRegistrationDate()
        {
            return _context.Salons
                .Max(salon => salon.RegistrationDate);
        }

        public DateTime GetMinRegistrationDate()
        {
            return _context.Salons
                .Min(salon => salon.RegistrationDate);
        }

        public IQueryable<string> GetNamesSalons(string searchString)
        {
            return _context.Salons
                .Where(salon => EF.Functions.Like(salon.Name, $"%{searchString}%"))
                .OrderBy(salon => salon.Name)
                .Select(salon => salon.Name)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Salon> GetSalons(SalonsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Salon> salons = _context.Salons
                .Include(salon => salon.Location)
                    .ThenInclude(location => location.Region)
                .Where(salon => EF.Functions.Like(salon.Name, $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)salon.Location.RegionId) : true) &&
                        salon.RegistrationDate >= filters.RangeRegistrationDate.From &&
                            salon.RegistrationDate <= filters.RangeRegistrationDate.To &&
                                (filters.IsOfficial != null ? salon.IsOfficial == filters.IsOfficial : true) &&
                                    (filters.ActualStock != null ? salon.ActualStock == filters.ActualStock : true) &&
                                        (filters.LoyaltyProgram != null ? salon.LoyaltyProgram == filters.LoyaltyProgram : true));

            if(sorter != null)
            {
                salons = sorter.Sort(salons);
            }

            return salons
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
