using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFBodyTypesRepository : IBodyTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IBodyTypesSorter> _sorters;

        public EFBodyTypesRepository(CatalogCarsDbContext context, IEnumerable<IBodyTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<BodyType> GetBodyTypes(BodyTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<BodyType> bodyTypes = _context.BodyTypes
                .Include(bodyType => bodyType.BodyTypeGroup)
                .Where(bodyType => EF.Functions.Like((bodyType.BodyTypeGroup.AutoClass != null ?
                    bodyType.BodyTypeGroup.AutoClass + " - " : "") + (bodyType.BodyTypeGroup.RuName != null ?
                        bodyType.BodyTypeGroup.RuName + " - " : "") + bodyType.RuName, $"%{filters.SearchString}%") &&
                    (filters.BodyTypeGroupsIds.Count > 0 ? filters.BodyTypeGroupsIds.Contains(bodyType.BodyTypeGroupId) : true));

            if(sorter != null)
            {
                bodyTypes = sorter.Sort(bodyTypes);
            }

            return bodyTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<BodyType> GetBodyTypesOfBodyTypeGroups(BodyTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<BodyType> bodyTypes = _context.BodyTypes
                .Include(bodyType => bodyType.BodyTypeGroup)
                .Where(bodyType => (filters.BodyTypeGroupsIds.Count > 0 ? 
                    filters.BodyTypeGroupsIds.Contains(bodyType.BodyTypeGroupId) : false));

            if (sorter != null)
            {
                bodyTypes = sorter.Sort(bodyTypes);
            }

            return bodyTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountBodyTypes(BodyTypesFilters filters)
        {
            return _context.BodyTypes
                .Include(bodyType => bodyType.BodyTypeGroup)
                .Where(bodyType => EF.Functions.Like((bodyType.BodyTypeGroup.AutoClass != null ?
                    bodyType.BodyTypeGroup.AutoClass + " - " : "") + (bodyType.BodyTypeGroup.RuName != null ?
                        bodyType.BodyTypeGroup.RuName + " - " : "") + bodyType.RuName, $"%{filters.SearchString}%") &&
                    (filters.BodyTypeGroupsIds.Count > 0 ? filters.BodyTypeGroupsIds.Contains(bodyType.BodyTypeGroupId) : true))
                .Count();
        }

        public int GetCountBodyTypesOfBodyTypeGroups(BodyTypesFilters filters)
        {
            return _context.BodyTypes
                .Include(bodyType => bodyType.BodyTypeGroup)
                .Where(bodyType => (filters.BodyTypeGroupsIds.Count > 0 ? 
                    filters.BodyTypeGroupsIds.Contains(bodyType.BodyTypeGroupId) : false))
                .Count();
        }

        public IQueryable<string> GetNamesBodyTypes(string searchString)
        {
            return _context.BodyTypes
                .Include(bodyType => bodyType.BodyTypeGroup)
                .Where(bodyType => EF.Functions.Like((bodyType.BodyTypeGroup.AutoClass != null ? 
                    bodyType.BodyTypeGroup.AutoClass + " - " : "") + (bodyType.BodyTypeGroup.RuName != null ? 
                        bodyType.BodyTypeGroup.RuName + " - " : "") + bodyType.RuName, $"%{searchString}%"))
                .OrderBy(bodyType => bodyType.BodyTypeGroup.AutoClass)
                    .ThenBy(bodyType => bodyType.BodyTypeGroup.RuName)
                        .ThenBy(bodyType => bodyType.RuName)
                .Select(bodyType => (bodyType.BodyTypeGroup.AutoClass != null ? bodyType.BodyTypeGroup.AutoClass + " - " : "") + 
                    (bodyType.BodyTypeGroup.RuName != null ? bodyType.BodyTypeGroup.RuName +" - " : "") + bodyType.RuName)
                .Take(5)
                .AsNoTracking();
        }
    }
}
