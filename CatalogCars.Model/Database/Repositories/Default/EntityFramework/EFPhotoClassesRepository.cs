using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PhotoClass;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool ContainsPhotoClass(string name, string ruName)
        {
            return _context.PhotoClasses.FirstOrDefault(photoClass => photoClass.Name == name ||
                photoClass.RuName == ruName) != null;
        }

        public void DeletePhotoClass(Guid id)
        {
            _context.PhotoClasses.Remove(GetPhotoClass(id));
            _context.SaveChanges();
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

        public PhotoClass GetPhotoClass(Guid id)
        {
            return _context.PhotoClasses.FirstOrDefault(photoClass => photoClass.Id == id);
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

        public bool SavePhotoClass(PhotoClass photoClass)
        {
            if(photoClass.Id == default)
            {
                if(!ContainsPhotoClass(photoClass.Name, photoClass.RuName))
                {
                    _context.Entry(photoClass).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetPhotoClass(photoClass.Id);

                if(currentVersion.Name != photoClass.Name || currentVersion.RuName != photoClass.RuName)
                {
                    if (!ContainsPhotoClass(photoClass.Name, photoClass.RuName))
                    {
                        _context.Entry(photoClass).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(photoClass).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
