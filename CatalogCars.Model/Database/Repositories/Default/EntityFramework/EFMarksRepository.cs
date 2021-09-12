using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFMarksRepository : IMarksRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IMarksSorter> _sorters;

        public EFMarksRepository(CatalogCarsDbContext context, IEnumerable<IMarksSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountMarks(MarksFilters filters)
        {
            return _context.Marks
                .Where(mark => mark.Name.ToLower().Contains(filters.SearchString))
                .Count();
        }

        public IQueryable<string> GetNamesMarks(string searchString)
        {
            return _context.Marks
                .Where(mark => mark.Name.ToLower().Contains(searchString))
                .Select(mark => mark.Name)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Mark> GetMarks(MarksFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Mark> marks = _context.Marks
                .Include(mark => mark.Logo)
                .Where(mark => mark.Name.ToLower().Contains(filters.SearchString.ToLower()));

            if(sorter != null)
            {
                marks = sorter.Sort(marks);
            }

            return marks
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
