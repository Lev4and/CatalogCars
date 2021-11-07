using CatalogCars.Model.Database.AnonymousTypes;
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

        public bool ContainsModel(Guid markId, string name)
        {
            return _context.Models.FirstOrDefault(model => model.MarkId == markId && model.Name == name) != null;
        }

        public void DeleteModel(Guid id)
        {
            _context.Models.Remove(GetModel(id));
            _context.SaveChanges();
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

        public Entities.Model GetModel(Guid id)
        {
            return _context.Models
                .Include(model => model.Mark)
                    .ThenInclude(mark => mark.Logo)
                .FirstOrDefault(model => model.Id == id);
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

        public IQueryable<Entities.Model> GetModelsOfMarks(List<Guid> marksIds)
        {
            return _context.Models
                .Include(model => model.Mark)
                .Where(model => (marksIds.Count > 0 ? marksIds.Contains(model.MarkId) : false))
                .OrderBy(model => model.Mark.Name)
                    .ThenBy(model => model.Name)
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

        public IQueryable<PopularityModels> GetPopularityModelsOfMark(Guid markId)
        {
            return _context.Announcements
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Generation)
                        .ThenInclude(generation => generation.Model)
                .Where(announcement => announcement.Vehicle.Generation.Model.MarkId == markId)
                .GroupBy(announcement => announcement.Vehicle.Generation.Model.Name)
                .Select(group => new PopularityModels
                {
                    Count = group.Count(),
                    ModelName = group.Key
                })
                .OrderByDescending(popularityModels => popularityModels.Count)
                .AsNoTracking();
        }

        public bool SaveModel(Entities.Model model)
        {
            if(model.Id == default)
            {
                if (!ContainsModel(model.MarkId, model.Name))
                {
                    _context.Entry(model).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetModel(model.Id);

                if(currentVersion.MarkId != model.MarkId || currentVersion.Name != model.Name)
                {
                    if (!ContainsModel(model.MarkId, model.Name))
                    {
                        _context.Entry(model).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
