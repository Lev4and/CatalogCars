using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFModelsRepository : IModelsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IModelsSorter> _sorters;

        public EFModelsRepository(CatalogCarsDbContext context, IEnumerable<IModelsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountModels(ModelsFilters filters)
        {
            return _context.Models
                .Include(model => model.Mark)
                .Where(model => EF.Functions.Like(model.Mark.Name + " " + model.Name, $"%{filters.SearchString}%") &&
                    (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(model.MarkId) : true))
                .Count();
        }

        public int GetCountModelsOfMarks(ModelsFilters filters)
        {
            return _context.Models
                .Where(model => (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(model.MarkId) : false))
                .Count();
        }

        public IQueryable<Entities.Model> GetModels(ModelsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Entities.Model> models = _context.Models
                .Include(model => model.Mark)
                    .ThenInclude(mark => mark.Logo)
                .Where(model => EF.Functions.Like(model.Mark.Name + " " + model.Name, $"%{filters.SearchString}%") &&
                    (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(model.MarkId) : true));

            if(sorter != null)
            {
                models = sorter.Sort(models);
            }

            return models
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Entities.Model> GetModelsOfMarks(ModelsFilters filters)
        {
            return _context.Models
                .Include(model => model.Mark)
                .Where(model => (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(model.MarkId) : false))
                .OrderBy(model => model.Mark.Name)
                    .ThenBy(model => model.Name)
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesModels(string searchString)
        {
            return _context.Models
                .Include(model => model.Mark)
                .Where(model => EF.Functions.Like(model.Mark.Name + " " + model.Name, $"%{searchString}%"))
                .OrderBy(model => model.Mark.Name)
                    .ThenBy(model => model.Name)
                .Select(model => $"{model.Mark.Name} {model.Name}")
                .Take(5)
                .AsNoTracking();
        }
    }
}
