using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyTypeGroup;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFBodyTypeGroupsRepository : IBodyTypeGroupsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IBodyTypeGroupsSorter> _sorters;

        public EFBodyTypeGroupsRepository(CatalogCarsDbContext context, IEnumerable<IBodyTypeGroupsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<BodyTypeGroup> GetBodyTypeGroups(BodyTypeGroupsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<BodyTypeGroup> bodyTypeGroups = _context.BodyTypeGroups
                .Where(bodyTypeGroup => EF.Functions.Like((bodyTypeGroup.AutoClass != null ? bodyTypeGroup.AutoClass :
                    "Не указан") + " - " + (bodyTypeGroup.RuName != null ? bodyTypeGroup.RuName : "Не указано"),
                        $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                bodyTypeGroups = sorter.Sort(bodyTypeGroups);
            }

            return bodyTypeGroups
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
                
        }

        public IQueryable<BodyTypeGroup> GetBodyTypeGroups()
        {
            return _context.BodyTypeGroups
                .OrderBy(bodyTypeGroup => bodyTypeGroup.AutoClass)
                    .ThenBy(bodyTypeGroup => bodyTypeGroup.RuName)
                .AsNoTracking();
        }

        public int GetCountBodyTypeGroups(BodyTypeGroupsFilters filters)
        {
            return _context.BodyTypeGroups
                .Where(bodyTypeGroup => EF.Functions.Like((bodyTypeGroup.AutoClass != null ? bodyTypeGroup.AutoClass :
                    "Не указан") + " - " + (bodyTypeGroup.RuName != null ? bodyTypeGroup.RuName : "Не указано"),
                        $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesBodyTypeGroups(string searchString)
        {
            return _context.BodyTypeGroups
                .Where(bodyTypeGroup => EF.Functions.Like((bodyTypeGroup.AutoClass != null ? bodyTypeGroup.AutoClass : 
                    "Не указан") + " - " + (bodyTypeGroup.RuName != null ? bodyTypeGroup.RuName : "Не указано"), 
                        $"%{searchString}%"))
                .OrderBy(bodyTypeGroup => bodyTypeGroup.AutoClass)
                    .ThenBy(bodyTypeGroup => bodyTypeGroup.RuName)
                .Select(bodyTypeGroup => (bodyTypeGroup.AutoClass != null ? bodyTypeGroup.AutoClass : "Не указан") + 
                    " - " + (bodyTypeGroup.RuName != null ? bodyTypeGroup.RuName : "Не указано"))
                .Take(5)
                .AsNoTracking();
        }
    }
}
