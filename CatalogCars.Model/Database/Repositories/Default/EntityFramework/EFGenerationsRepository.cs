using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Generation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFGenerationsRepository : IGenerationsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IGenerationsSorter> _sorters;

        public EFGenerationsRepository(CatalogCarsDbContext context, IEnumerable<IGenerationsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsGeneration(Guid modelId, int? yearFrom, string name)
        {
            return _context.Generations.FirstOrDefault(generation =>
                generation.ModelId == modelId && generation.YearFrom == yearFrom && generation.Name == name) != null;
        }

        public void DeleteGeneration(Guid id)
        {
            _context.Generations.Remove(GetGeneration(id));
            _context.SaveChanges();
        }

        public int GetCountGenerations(GenerationsFilters filters)
        {
            return _context.Generations
                .Include(generation => generation.Model)
                    .ThenInclude(model => model.Mark)
                .Where(generation => EF.Functions.Like(generation.Model.Mark.Name + " " + generation.Model.Name +
                    (generation.Name != null ? " " + generation.Name : "") + (generation.YearFrom != null ? " " +
                        generation.YearFrom : ""), $"%{filters.SearchString}%") &&
                        (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(generation.Model.MarkId) : true) &&
                            (filters.ModelsIds.Count > 0 ? filters.ModelsIds.Contains(generation.ModelId) : true) &&
                                (filters.RangeYearFrom.To != null || filters.RangeYearFrom.From != null ?
                                    generation.YearFrom >= filters.RangeYearFrom.From && generation.YearFrom <=
                                        filters.RangeYearFrom.To : true) && 
                                            (filters.PriceSegmentId != null ? generation.PriceSegmentId == 
                                                filters.PriceSegmentId : true))
                .Count();
        }

        public int GetCountGenerationsOfModels(GenerationsFilters filters)
        {
            return _context.Generations
                .Where(generation => (filters.ModelsIds.Count > 0 ?
                    filters.ModelsIds.Contains(generation.ModelId) : false))
                .Count();
        }

        public Generation GetGeneration(Guid id)
        {
            return _context.Generations
                .Include(generation => generation.Model)
                    .ThenInclude(model => model.Mark)
                        .ThenInclude(mark => mark.Logo)
                .FirstOrDefault(generation => generation.Id == id);
        }

        public IQueryable<Generation> GetGenerations(GenerationsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Generation> generations = _context.Generations
                .Include(generation => generation.PriceSegment)
                .Include(generation => generation.Model)
                    .ThenInclude(model => model.Mark)
                        .ThenInclude(mark => mark.Logo)
                .Where(generation => EF.Functions.Like(generation.Model.Mark.Name + " " + generation.Model.Name +
                    (generation.Name != null ? " " + generation.Name : "") + (generation.YearFrom != null ? " " +
                        generation.YearFrom : ""), $"%{filters.SearchString}%") && 
                        (filters.MarksIds.Count > 0 ? filters.MarksIds.Contains(generation.Model.MarkId) : true) &&
                            (filters.ModelsIds.Count > 0 ? filters.ModelsIds.Contains(generation.ModelId) : true) &&
                                (filters.RangeYearFrom.To != null || filters.RangeYearFrom.From != null ? 
                                    generation.YearFrom >= filters.RangeYearFrom.From && generation.YearFrom <= 
                                        filters.RangeYearFrom.To : true) &&
                                            (filters.PriceSegmentId != null ? generation.PriceSegmentId ==
                                                filters.PriceSegmentId : true));

            if(sorter != null)
            {
                generations = sorter.Sort(generations);
            }

            return generations
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Generation> GetGenerationsOfModels(GenerationsFilters filters)
        {
            return _context.Generations
                .Include(generation => generation.Model)
                    .ThenInclude(model => model.Mark)
                .Where(generation => (filters.ModelsIds.Count > 0 ? 
                    filters.ModelsIds.Contains(generation.ModelId) : false))
                .OrderBy(generation => generation.Model.Mark.Name)
                    .ThenBy(generation => generation.Model.Name)
                        .ThenBy(generation => generation.Name)
                            .ThenBy(generation => generation.YearFrom)
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int? GetMaxYearFromGeneration()
        {
            return _context.Generations.Max(generation => generation.YearFrom);
        }

        public int? GetMinYearFromGeneration()
        {
            return _context.Generations.Min(generation => generation.YearFrom);
        }

        public IQueryable<string> GetNamesGenerations(string searchString)
        {
            return _context.Generations
                .Include(generation => generation.Model)
                    .ThenInclude(model => model.Mark)
                .Where(generation => EF.Functions.Like(generation.Model.Mark.Name + " " + generation.Model.Name +
                    (generation.Name != null ? " " + generation.Name : "") + (generation.YearFrom != null ? " " + 
                        generation.YearFrom : ""), $"%{searchString}%"))
                .OrderBy(generation => generation.Model.Mark.Name)
                    .ThenBy(generation => generation.Model.Name)
                        .ThenBy(generation => generation.Name)
                            .ThenBy(generation => generation.YearFrom)
                .Select(generation => generation.Model.Mark.Name + " " + generation.Model.Name +
                    (generation.Name != null ? " " + generation.Name : "") + (generation.YearFrom != null ? " " +
                        generation.YearFrom : ""))
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveGeneration(Generation generation)
        {
            if(generation.Id == default)
            {
                if(!ContainsGeneration(generation.ModelId, generation.YearFrom, generation.Name))
                {
                    _context.SaveEntity(generation, EntityState.Added);

                    return true;
                }
            }
            else
            {
                var currentVersion = GetGeneration(generation.Id);

                if(currentVersion.ModelId != generation.ModelId || currentVersion.YearFrom != generation.YearFrom || 
                    currentVersion.Name != generation.Name)
                {
                    if (!ContainsGeneration(generation.ModelId, generation.YearFrom, generation.Name))
                    {
                        _context.SaveEntity(generation, EntityState.Modified);

                        return true;
                    }
                }
                else
                {
                    _context.SaveEntity(generation, EntityState.Modified);

                    return true;
                }
            }

            return false;
        }
    }
}
