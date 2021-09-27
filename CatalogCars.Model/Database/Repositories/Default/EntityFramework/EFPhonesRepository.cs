using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Phone;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPhonesRepository : IPhonesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IPhonesSorter> _sorters;

        public EFPhonesRepository(CatalogCarsDbContext context, IEnumerable<IPhonesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountPhones(PhonesFilters filters)
        {
            return _context.Phones
                .Where(phone => EF.Functions.Like(phone.Value, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesPhones(string searchString)
        {
            return _context.Phones
                .Where(phone => EF.Functions.Like(phone.Value, $"%{searchString}%"))
                .OrderBy(phone => phone.Value)
                .Select(phone => phone.Value)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Phone> GetPhones(PhonesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Phone> phones = _context.Phones
                .Where(phone => EF.Functions.Like(phone.Value, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                phones = sorter.Sort(phones);
            }

            return phones
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
