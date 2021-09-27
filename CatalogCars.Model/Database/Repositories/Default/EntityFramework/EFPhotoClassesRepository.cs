using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PhotoClass;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPhotoClassesRepository : IPhotoClassesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IPhotoClassesSorter> _sorters;

        public EFPhotoClassesRepository(CatalogCarsDbContext context, IEnumerable<IPhotoClassesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountPhotoClasses(PhotoClassesFilters filters)
        {
            return _context.PhotoClasses
                .Where(photoClass => EF.Functions.Like(photoClass.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesPhotoClasses(string searchString)
        {
            return _context.PhotoClasses
                .Where(photoClass => EF.Functions.Like(photoClass.RuName, $"%{searchString}%"))
                .OrderBy(photoClass => photoClass.RuName)
                .Select(photoClass => photoClass.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<PhotoClass> GetPhotoClasses(PhotoClassesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<PhotoClass> photoClasses = _context.PhotoClasses
                .Where(photoClass => EF.Functions.Like(photoClass.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                photoClasses = sorter.Sort(photoClasses);
            }

            return photoClasses
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
